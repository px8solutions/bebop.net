/* Init.js */

var asm = Bebop.open(Windows.Editor,"Test.asm");
asm.move(0, 0);
asm.resize(400, 475);

var output=Bebop.open(Windows.Output);
output.move(400, 270);
output.resize(700, 200);

var ram = Bebop.open(Windows.RAM);
ram.move(775, 0);
ram.resize(350, 250);

Pause(2000);

asm.assemble();

Pause(2000);

ram.scrollTo(0x4000);

