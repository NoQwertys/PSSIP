alert('Второй');

console.log("if");
let year = prompt('Сколько дней в неделе?', '');
if (year == 7) console.log( 'Вы правы!' )
else console.log('Вы не правы');

console.log("switch,break")
let a = prompt('Какой по счету четверг?', '');
a = parseInt(a)
switch (a) {
  case 1,2,3:
    console.log( 'Маловато' );
    break;
  case 4:
    console.log( 'Правильно' );
    break;
  case 5,6,7:
    console.log( 'Перебор' );
    break;
  default:
    console.log( "Нет таких значений" );
}

console.log("while");
var i = 0;
while (i < 5) { 
    console.log( i );
  i++;
}

console.log("do..while");
let g = 0;
do {
    console.log( g );
  g++;
} while (g < 4);

console.log("for");
for (let f = 0; i < 3; f++) { 
    console.log(f);
  }

console.log("continue");
for (let a = 0; a < 10; a++) {
    if (a % 2 == 0) continue;
  
    console.log(a);
}

console.log("return");
function func1(x) {
    return function func2(x) {
      return x * 2;
    };
  }
  var answer = func1();
  console.log(answer(10));

document.write("Вывод информации");
document.writeln("Вывод информации");