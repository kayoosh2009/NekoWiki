document.addEventListener('DOMContentLoaded', function () {
    // Элементы формы
    const form = document.getElementById('registerForm');
    const loginInput = document.getElementById('inputLogin');
    const emailInput = document.getElementById('inputEmail');
    const confirmEmailInput = document.getElementById('confirmEmail');
    const passInput = document.getElementById('inputPassword');
    const confirmPassInput = document.getElementById('confirmPassword');
    const dobInput = document.getElementById('inputDOB');
    const termsCheck = document.getElementById('checkTerms');

    // Радио и чекбоксы
    const catLoverYes = document.getElementById('catLoverYes');
    const catLoverNo = document.getElementById('catLoverNo');

    // Глазики
    const togglePass = document.getElementById('togglePass');
    const toggleConfirmPass = document.getElementById('toggleConfirmPass');

    // Блоки для текста ошибок
    const loginErr = document.getElementById('loginHelp');
    const emailErr = document.getElementById('emailHelp');
    const confirmEmailErr = document.getElementById('confirmEmailHelp');
    const passErr = document.getElementById('passwordHelp');
    const confirmPassErr = document.getElementById('confirmPasswordHelp');
    const dobErr = document.getElementById('dobHelp');
    const catErr = document.getElementById('catHelp');
    const termsErr = document.getElementById('termsHelp');

    // Кнопки
    const submitBtn = document.getElementById('submitButton');
    const resetBtn = document.getElementById('resetButton');

    // Регулярные выражения
    const emailReg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
    const loginReg = /^[a-zA-Z][a-zA-Z0-9]+$/;

    /**
     * 1. УПРАВЛЕНИЕ ВИДИМОСТЬЮ ГЛАЗИКА (как в логине)
     */
    function handleToggleVisibility(input, toggle) {
        input.addEventListener('input', function () {
            if (this.value.length > 0) {
                toggle.style.display = 'block';
            } else {
                toggle.style.display = 'none';
                input.setAttribute('type', 'password');
                toggle.classList.remove('is-visible');
            }
        });
    }

    handleToggleVisibility(passInput, togglePass);
    handleToggleVisibility(confirmPassInput, toggleConfirmPass);

    /**
     * 2. ПЕРЕКЛЮЧЕНИЕ ТИПА ПАРОЛЯ
     */
    function setupToggleClick(input, toggle) {
        if (toggle) {
            toggle.addEventListener('click', function () {
                const isPassword = input.getAttribute('type') === 'password';
                input.setAttribute('type', isPassword ? 'text' : 'password');
                this.classList.toggle('is-visible', isPassword);
            });
        }
    }

    setupToggleClick(passInput, togglePass);
    setupToggleClick(confirmPassInput, toggleConfirmPass);

    /**
     * 3. ВАЛИДАЦИЯ ПРИ ОТПРАВКЕ
     */
    if (form) {
        form.addEventListener('submit', function (e) {
            e.preventDefault();
            let isValid = true;

            // Проверка Логина
            const loginVal = loginInput.value.trim();
            if (!loginVal) {
                showError(loginInput, loginErr, "❌ Enter login");
                isValid = false;
            } else if (!loginReg.test(loginVal)) {
                showError(loginInput, loginErr, "❌ Only letters and numbers allowed");
                isValid = false;
            } else {
                clearError(loginInput, loginErr);
            }

            // Проверка Email
            const emailVal = emailInput.value.trim();
            if (!emailVal) {
                showError(emailInput, emailErr, "❌ Email required");
                isValid = false;
            } else if (emailVal.includes('/') || emailVal.includes('\\')) {
                showError(emailInput, emailErr, "❌ Slashes are prohibited");
                isValid = false;
            } else if (!emailReg.test(emailVal)) {
                showError(emailInput, emailErr, "❌ Invalid format");
                isValid = false;
            } else {
                clearError(emailInput, emailErr);
            }

            // Подтверждение Email
            if (confirmEmailInput.value.trim() !== emailVal) {
                showError(confirmEmailInput, confirmEmailErr, "❌ Emails don't match");
                isValid = false;
            } else {
                clearError(confirmEmailInput, confirmEmailErr);
            }

            // Проверка Пароля
            const passVal = passInput.value;
            if (!passVal) {
                showError(passInput, passErr, "❌ Enter password");
                isValid = false;
            } else if (passVal.length < 6) {
                showError(passInput, passErr, "❌ Minimum 6 characters");
                isValid = false;
            } else {
                clearError(passInput, passErr);
            }

            // Подтверждение Пароля
            if (confirmPassInput.value !== passVal) {
                showError(confirmPassInput, confirmPassErr, "❌ Passwords don't match");
                isValid = false;
            } else {
                clearError(confirmPassInput, confirmPassErr);
            }

            // Проверка даты
            if (!dobInput.value) {
                showError(dobInput, dobErr, "❌ Select birth date");
                isValid = false;
            } else {
                clearError(dobInput, dobErr);
            }

            // Проверка "Любишь котиков"
            if (!catLoverYes.checked && !catLoverNo.checked) {
                catErr.textContent = "❌ Answer the question!";
                isValid = false;
            } else if (catLoverNo.checked) {
                catErr.textContent = "❌ You must love cats! 😿";
                isValid = false;
            } else {
                catErr.textContent = "";
            }

            // Проверка Условий
            if (!termsCheck.checked) {
                termsErr.textContent = "❌ Accept terms";
                isValid = false;
            } else {
                termsErr.textContent = "";
            }

            if (isValid) {
                submitBtn.disabled = true;
                const originalText = submitBtn.innerHTML;
                submitBtn.innerHTML = 'Creating account... 🐾';

                setTimeout(() => {
                    alert("Meow! Registration successful.");
                    window.location.href = '/Login';
                }, 1500);
            }
        });
    }

    /**
     * 4. СБРОС ФОРМЫ
     */
    if (resetBtn) {
        resetBtn.addEventListener('click', function () {
            form.reset();
            const inputs = [loginInput, emailInput, confirmEmailInput, passInput, confirmPassInput, dobInput];
            const errs = [loginErr, emailErr, confirmEmailErr, passErr, confirmPassErr, dobErr];

            inputs.forEach(i => i.classList.remove('is-invalid'));
            errs.forEach(e => e.textContent = "");
            catErr.textContent = "";
            termsErr.textContent = "";

            [togglePass, toggleConfirmPass].forEach(t => {
                t.style.display = 'none';
                t.classList.remove('is-visible');
            });
            [passInput, confirmPassInput].forEach(p => p.setAttribute('type', 'password'));
        });
    }

    function showError(input, errorDiv, message) {
        input.classList.add('is-invalid');
        errorDiv.textContent = message;
    }

    function clearError(input, errorDiv) {
        input.classList.remove('is-invalid');
        errorDiv.textContent = "";
    }
});