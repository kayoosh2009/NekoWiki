document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('loginForm');
    const userInput = document.getElementById('inputUsername');
    const passInput = document.getElementById('inputPassword');
    const togglePass = document.getElementById('togglePass');

    // Показ/скрытие пароля (глазик)
    if (togglePass && passInput) {
        togglePass.addEventListener('click', function () {
            const isPassword = passInput.getAttribute('type') === 'password';
            passInput.setAttribute('type', isPassword ? 'text' : 'password');
            this.classList.toggle('is-visible', isPassword);
        });
    }

    // Простая валидация перед отправкой
    if (form) {
        form.addEventListener('submit', function (e) {
            const userVal = userInput.value.trim();
            const passVal = passInput.value;

            if (!userVal || !passVal) {
                e.preventDefault();
                alert("❌ Заполните логин и пароль!");
            }
        });
    }
});