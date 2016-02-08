using System;
using System.Drawing;
using System.Windows.Forms;
using WinBebop.Core;

namespace WinBebop
{
   public partial class MemoryWalker : Form
   {
      private ushort _start = 0;
      private int _cW = 50;

      int _nX = 1;
      int _nY = 1;

      public MemoryWalker()
      {
         InitializeComponent();
         Beboputer.Bebop.Loaded += Bebop_Loaded;
      }

      private void Bebop_Loaded()
      {
         panel1.Invalidate();
      }

      private void MemoryWalker_Load(object sender, EventArgs e)
      {
         ClampSize();
         SendKeys.Send("{up}");
      }

      private void MemoryWalker_Resize(object sender, EventArgs e)
      {
         ClampSize();
      }

      public void ClampSize()
      {
         _nX = (int)Math.Round(((double)(this.ClientSize.Width - vScrollBar1.Width)) / _cW);
         if (_nX < 4) _nX = 4;
         Width = (_nX * _cW) + (Width - this.ClientSize.Width) + vScrollBar1.Width + 1;

         int cY = this.ClientSize.Height - this.toolStrip1.Height;
         _nY = (int)Math.Round(((double)cY) / _cW);
         if (_nY < 1) _nY = 1;
         Height = (_nY * _cW) + this.toolStrip1.Height + (Height - this.ClientSize.Height) + 1;

         vScrollBar1.SmallChange = _nX;
         vScrollBar1.LargeChange = _nX * _nY;
         vScrollBar1.Maximum = 65536;

      }


      private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
      {
         _start = (ushort)e.NewValue;
         panel1.Invalidate();
      }

      private void panel1_Resize(object sender, EventArgs e)
      {
         panel1.Invalidate();
      }


      private void panel1_Paint(object sender, PaintEventArgs e)
      {
         e.Graphics.Clear(Color.White);

         Font af= new Font(FontFamily.GenericMonospace, 10.0F);
         Font df = new Font(FontFamily.GenericMonospace, 12.0F, FontStyle.Bold);

         int nX = Width / _cW;
         int nY = Height / _cW;

         ushort address = _start;

         for (int i = 0; i < nY; ++i)
         {
            for (int j = 0; j < nX; ++j)
            {
               e.Graphics.DrawRectangle(Pens.Black, j * _cW, i * _cW, _cW, _cW);

               if (Beboputer.Bebop.RAM.HasValue(address))
               {
                  e.Graphics.FillRectangle(Brushes.Gray, j * _cW+1, i * _cW+1, _cW-2, _cW-2);
                  e.Graphics.DrawString(string.Format("${0:X02}",Beboputer.Bebop.RAM.Read(address)), df, Brushes.Black, j * _cW+10, i * _cW+20);
               }

               e.Graphics.DrawString(string.Format("${0:X02}",address), af, Brushes.Black, j * _cW, i * _cW);

               ++address;
            }
         }

      }


   }
}
