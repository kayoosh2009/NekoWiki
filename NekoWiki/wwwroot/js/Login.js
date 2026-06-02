document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('loginForm');
    const userInput = document.getElementById('inputUsername');
    const passInput = document.getElementById('inputPassword');
    const togglePass = document.getElementById('togglePass');

    // Показываем глазик, только если в поле пароля что-то ввели
    if (passInput && togglePass) {
        passInput.addEventListener('input', function () {
            if (this.value.length > 0) {
                togglePass.style.display = 'block';
            } else {
                togglePass.style.display = 'none';
                passInput.setAttribute('type', 'password');
                togglePass.classList.remove('is-visible');
            }
        });

        // Переключение видимости пароля по клику на глазик
        togglePass.addEventListener('click', function () {
            const isPassword = passInput.getAttribute('type') === 'password';
            passInput.setAttribute('type', isPassword ? 'text' : 'password');
            this.classList.toggle('is-visible', isPassword);
        });
    }

    // Простая валидация перед отправкой формы
    if (form) {
        form.addEventListener('submit', function (e) {
            const userVal = userInput ? userInput.value.trim() : "";
            const passVal = passInput ? passInput.value : "";

            if (!userVal || !passVal) {
                e.preventDefault(); // Тормозим отправку, если пусто
                alert("❌ Заполните логин и пароль!");
            }
        });
    }
});