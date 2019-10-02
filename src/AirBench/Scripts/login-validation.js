(function () {
    const form = document.getElementById('LoginForm')
    const username = document.getElementById('Username');
    const password = document.getElementById('Password');
    const submit = document.getElementById('Submit');

    form.addEventListener('input', () => {
        if (username.validity.valid && password.validity.valid) {
            submit.setAttribute('class', 'btn btn-primary');
            submit.removeAttribute('disabled');
        } else {
            submit.setAttribute('class', 'btn btn-primary disabled');
            submit.setAttribute('disabled', 'disabled');
        }
    });
})()