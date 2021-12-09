document.addEventListener("DOMContentLoaded", () => {

    const body = $('body');
    const loginButton = $('.modal__login-trigger');
    const contactsButton = $('.modal__contacts-trigger');
    const overflow = $('.overflow');
    const loginFormButton = $('#login-form__submit');
    const contactsFormButton = $('#contacts-close');

    $(loginButton).click(() => {
        $(body).toggleClass('modal-open');
    });

    $(contactsButton).click(() => {
        $(body).toggleClass('contacts-open');
    });

    $(overflow).click(() => {
        $(body).removeClass('modal-open');
        $(body).removeClass('contacts-open');
    });

    $(loginFormButton).click(() => {
        $(body).removeClass('modal-open');
    });

    $(contactsFormButton).click(() => {
        $(body).removeClass('contacts-open');
    });


    $(".modal__login-trigger, .modal__contacts-trigger").click(() => {
        $(".menu-popup").slideUp(200);
    });

    $(".header__hamburger,  .menu-close").click(() => {
        $(".menu-popup").slideToggle(200);
    });

    $('#input_name input[type="text"]').blur(function () {
        console.log($(this).val().length);
        if ($(this).val().length > 0) {
            $(this).closest('.input').addClass('white');
        } else {
            $(this).closest('.input').removeClass('white');
        }
    });

    $('#input_password input[type="password"]').blur(function () {
        if ($(this).val().length > 0) {
            $(this).closest('.input').addClass('white');
        } else {
            $(this).closest('.input').removeClass('white');
        }
    });

});
