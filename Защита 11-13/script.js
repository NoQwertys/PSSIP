let S1 = "Я люблю Беларусь";

let S2 = "Я учусь в Политехническом колледже";

document.write("Длина S1: " + S1.length + '<br>');

S2 = S2.replace('учусь', '');
document.write("Измененный S2: " + S2 + '<br>');

S1 = S1.replace('ю', '*');
document.write("Измененный S1: " + S1 + '<br>');

function performCalculation() {
    var a = document.getElementById('inputA').value;
    var x = document.getElementById('inputX').value;
    try {
        const result = calculateFormula(x,a);
        document.getElementById('resultDisplay').innerText = "Ответ: " + result;
    } catch (error) {
        alert(error.message);
    }
}

function calculateFormula(x,a) {
    x = parseInt(x); 
    a = parseInt(a);

    if (x >= 2) {
        if ( x+a < 0 ) {
            throw new Error('Отрицательное число под корнем');
        }
        if (Math.pow(x,2) == 1.5) {
            throw new Error("Деление на ноль"); 
        }
        return a / ( Math.pow(x,2) - 1.5 ) + Math.sqrt(a+x);
    }
    if (x < 2 && x >=0) {
        if ( a < 0 ) {
            throw new Error('Отрицательное число под корнем');
        }
        return 2*Math.sqrt(a)-x/4;
    }
    if (x < 0) {
        return 0.3*x;
    }
}