(function () {
    const form = document.getElementById('RegisterForm')
    const username = document.getElementById('Username');
    const password = document.getElementById('Password');
    const firstName = document.getElementById('FirstName');
    const lastName = document.getElementById('LastName');
    const submit = document.getElementById('Submit');

    form.addEventListener('input', () => {
        if (username.validity.valid && password.validity.valid &&
            firstName.validity.valid && lastName.validity.valid) {
            submit.setAttribute('class', 'btn btn-primary');
            submit.removeAttribute('disabled');
        } else {
            submit.setAttribute('class', 'btn btn-primary disabled');
            submit.setAttribute('disabled', 'disabled');
        }
    });
})()