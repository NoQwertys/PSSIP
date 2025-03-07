// 3. Пример синтаксиса класса в JS:
class Car {
    constructor(brand, model) {
      this.brand = brand;
      this.model = model;
    }
  
    getInfo() {
      return `${this.brand} ${this.model}`;
    }
}

// 4. Как осуществляется создание объектов класса?
const myCar = new Car('Toyota', 'Corolla');

// 5. Как происходит обращение к полям и методам внутри класса?
document.writeln(myCar.model); // обращение к полю
document.writeln(myCar.getInfo()); // обращение к методу

// 6. Как обозначаются в JS публичные, приватные и защищённые поля и методы?
class User {
    #id; // Приватное поле
    constructor(name, id) {
      this.name = name; // Публичное поле
      this.#id = id; // Приватное поле
    }
    getId() {
        return this.#id; // Инкапсуляция
    }
    // 7. Для чего в ООП в JS используется служебное слово static?
    static add(a, b) {
        return a + b;
    }
}
document.writeln(User.add(5, 3)); // принадлежат самому классу, а не его экземплярам

// 8. Что такое геттеры и сеттеры? Для чего и как они используются в ООП в JS?
class Rectangle {
    constructor(width, height) {
      this._width = width;
      this._height = height;
    }
    // Геттер для площади
    get area() {
      return this._width * this._height;
    }
    // Сеттер для ширины
    set width(newWidth) {
      this._width = newWidth;
    }
}
  
const rect = new Rectangle(5, 10);
document.writeln(rect.area); // 50
rect.width = 7; // Используется сеттер для изменения ширины
document.writeln(rect.area); // 70

// Наследование
class Admin extends User {
    constructor(root) {
    this.root = root;
    }
}
// Полиморфизм
class Shape {
    draw() {
      document.writeln('Рисуем фигуру');
    }
  }
  
  class Circle extends Shape {
    draw() {
      document.writeln('Рисуем круг');
    }
  }
  
  class Square extends Shape {
    draw() {
      document.writeln('Рисуем квадрат');
    }
  }
  
  const shapes = [new Shape(), new Circle(), new Square()];
  
  shapes.forEach(shape => shape.draw());
  