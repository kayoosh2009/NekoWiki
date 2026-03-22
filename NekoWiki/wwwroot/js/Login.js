document.addEventListener('DOMContentLoaded', function () {
    // Элементы формы
    const form = document.getElementById('loginForm');
    const emailInput = document.getElementById('email');
    const passInput = document.getElementById('password');
    const togglePass = document.getElementById('togglePass');

    // Блоки для текста ошибок
    const emailErr = document.getElementById('emailError');
    const passErr = document.getElementById('passwordError');

    // Кнопки
    const submitBtn = document.getElementById('submitBtn');
    const resetBtn = document.getElementById('resetBtn');
    const forgotBtn = document.getElementById('forgotBtn');

    // Регулярное выражение для проверки Email
    const emailReg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;

    /**
     * 1. УПРАВЛЕНИЕ ВИДИМОСТЬЮ ГЛАЗИКА
     * Показываем иконку только если в поле есть текст
     */
    passInput.addEventListener('input', function () {
        if (this.value.length > 0) {
            togglePass.style.display = 'block';
        } else {
            togglePass.style.display = 'none';
            // Если поле очистили, возвращаем тип "password"
            passInput.setAttribute('type', 'password');
            togglePass.classList.remove('is-visible');
        }
    });

    /**
     * 2. ПЕРЕКЛЮЧЕНИЕ ТИПА ПАРОЛЯ (Глаз)
     */
    if (togglePass) {
        togglePass.addEventListener('click', function () {
            const isPassword = passInput.getAttribute('type') === 'password';

            if (isPassword) {
                passInput.setAttribute('type', 'text');
                this.classList.add('is-visible'); // Меняет картинку на открытый глаз
            } else {
                passInput.setAttribute('type', 'password');
                this.classList.remove('is-visible'); // Возвращает закрытый глаз
            }
        });
    }

    /**
     * 3. ВАЛИДАЦИЯ ПРИ ОТПРАВКЕ
     */
    if (form) {
        form.addEventListener('submit', function (e) {
            e.preventDefault();

            let isValid = true;
            const emailVal = emailInput.value.trim();
            const passVal = passInput.value;

            // Проверка Email
            if (!emailVal) {
                showError(emailInput, emailErr, "❌ Enter your email address");
                isValid = false;
            } else if (emailVal.includes('/') || emailVal.includes('\\')) {
                showError(emailInput, emailErr, "❌ Slashes are prohibited");
                isValid = false;
            } else if (!emailReg.test(emailVal)) {
                showError(emailInput, emailErr, "❌ Invalid mail format");
                isValid = false;
            } else {
                clearError(emailInput, emailErr);
            }

            // Проверка Пароля
            if (!passVal) {
                showError(passInput, passErr, "❌Enter your password");
                isValid = false;
            } else if (passVal.length < 6) {
                showError(passInput, passErr, "❌ Minimum 6 characters");
                isValid = false;
            } else {
                clearError(passInput, passErr);
            }

            // Если всё прошло успешно
            if (isValid) {
                submitBtn.disabled = true;
                const originalText = submitBtn.innerHTML;
                submitBtn.innerHTML = 'Logging in... 🐾';

                setTimeout(() => {
                    alert("Meow! You have successfully logged in.");
                    submitBtn.disabled = false;
                    submitBtn.innerHTML = originalText;
                    // form.submit(); // Раскомментируй для реальной отправки
                }, 1000);
            }
        });
    }

    /**
     * 4. СБРОС ФОРМЫ
     */
    if (resetBtn) {
        resetBtn.addEventListener('click', function () {
            form.reset();
            clearError(emailInput, emailErr);
            clearError(passInput, passErr);

            // Скрываем глазик и возвращаем тип пароля
            togglePass.style.display = 'none';
            passInput.setAttribute('type', 'password');
            togglePass.classList.remove('is-visible');
        });
    }

    /**
     * 5. ЗАБЫЛИ ПАРОЛЬ
     */
    if (forgotBtn) {
        forgotBtn.addEventListener('click', (e) => {
            e.preventDefault();
            alert("The recovery feature is in development! 🐾");
        });
    }

    // Вспомогательные функции
    function showError(input, errorDiv, message) {
        input.classList.add('is-invalid');
        errorDiv.textContent = message;
    }

    function clearError(input, errorDiv) {
        input.classList.remove('is-invalid');
        errorDiv.textContent = "";
    }
});