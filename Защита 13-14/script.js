// Задание 2.1: Получить информацию о цвете гиперссылок на странице.
function getLinkColor() {
    const link = document.querySelector('a');
    const linkColor = window.getComputedStyle(link).color;
    alert('Цвет гиперссылки:', linkColor);
}

// Задание 2.2: Вывести информацию через 5 секунд после запуска страницы.
setTimeout(getLinkColor, 5000); 

// Задание 2.3: Переместить элементы 2 и 3 по местам по нажатию на кнопку "Переместить".
function swapElements() {

    const el2 = document.body.children[1];
    const el3 = document.body.children[2];
    
    const linkParent = el2.parentNode;

    linkParent.insertBefore(el3, el2);
}

// Задание 3.1: Изменение стиля элемента №1.
function styleElement() {
    const el1 = document.body.children[0];
    el1.style.color = 'yellow';
    el1.style.backgroundColor = 'red';
    el1.style.position = 'absolute';
    el1.style.right = '0';
    el1.style.bottom = '0';
}

// Задание 4.1: Получить информацию о названии и версии браузера.
function getBrowserInfo() {
    const userAgent = navigator.userAgent;
    console.log('Информация о браузере:', userAgent);
    return userAgent;
}

// Задание 4.2: Отображать информацию в новом окне.
function displayBrowserInfo() {
    const browserInfo = getBrowserInfo();
    const newWindow = window.open('', '', 'width=300,height=200');
    newWindow.document.write(`<p>${browserInfo}</p>`);
}

// Запускаем отображение информации каждые 3 секунды.
//setInterval(displayBrowserInfo, 3000);

// Задание 5: Валидация форм.
document.addEventListener('DOMContentLoaded', function() {
    // Function to validate phone number fields
    function validatePhoneNumber(field) {
        if (!/^\d*$/.test(field.value)) {
            field.style.borderColor = 'red';
        } else {
            field.style.borderColor = '';
        }
    }

    // Function to validate file size
    function validateFileSize(field) {
        if (field.files.length > 0) {
            let file = field.files[0];
            if (file.size > 1024 * 1024) {
                field.style.backgroundColor = 'red';
            } else {
                field.style.backgroundColor = '';
            }
        }
    }

    // Function to validate message length
    function validateMessageLength(field) {
        if (field.value.length > 100) {
            field.style.borderColor = 'red';
        } else {
            field.style.borderColor = '';
        }
    }

    // Add event listeners for phone number fields
    let phoneFields = document.querySelectorAll('#order-number, #mobile-phone, #home-phone, #kodmobile-phone, #kodhome-phone');
    phoneFields.forEach(function(field) {
        field.addEventListener('input', function() {
            validatePhoneNumber(field);
        });
    });

    // Add event listener for file input field
    let fileInput = document.getElementById('file-upload');
    fileInput.addEventListener('change', function() {
        validateFileSize(fileInput);
    });

    // Add event listener for message textarea
    let messageField = document.getElementById('message');
    messageField.addEventListener('input', function() {
        validateMessageLength(messageField);
    });

    // Prevent form submission if there are validation errors
    document.getElementById('myForm').addEventListener('submit', function(event) {
        phoneFields.forEach(function(field) {
            validatePhoneNumber(field);
        });
        validateFileSize(fileInput);
        validateMessageLength(messageField);

        // Check for any field with a red border
        let invalidFields = document.querySelectorAll('input[style*="red"], textarea[style*="red"]');
        if (invalidFields.length > 0) {
            event.preventDefault();
        }
    });
});
