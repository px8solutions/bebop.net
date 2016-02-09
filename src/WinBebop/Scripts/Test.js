/* Test.js */

console.log('testing!!!');

Bebop.closeAll();

output=Bebop.open(Windows.Output);
output.move(400, 50);

ram = Bebop.open(Windows.RAM);
ram.move(0, 0);
ram.resize(400, 500);
ram.scrollTo(0x4000);
