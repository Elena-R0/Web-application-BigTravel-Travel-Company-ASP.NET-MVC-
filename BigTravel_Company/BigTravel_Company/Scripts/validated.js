$(document).ready(function () {
    $('#signIN').click(function (e) {
       

        _valid = true;
        var email_st = $('#email_st').val();
        var pass_st = $('#pass_st').val();

        $(".error").remove();


        if (email_st < 1) {
            $('#email_st')
                .after('<span class="error_pas_em">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (pass_st.length < 1) {
            $('#pass_st')
                .after('<span class="error_pas_em">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

    

        if (!_valid) {
            e.preventDefault(); 
        }
    });


    $('#vouch').click(function (e) {
          

        var _valid = true;
        var name_vouchers = $('#name_vouchers').val();
        var Information_vouchers = $('#Information_vouchers').val();
        var Excursions = $('#Excursions').val();
        var Departure_date = $('#Departure_date').val();
        var Date_arrival = $('#Date_arrival').val();
        var Cost = $('#Cost').val();
        var number_trips = $('#number_trips').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');
        $(".error_name").removeClass('error-input');


        if (Date_arrival.length < 1) {
            $('#Date_arrival')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (Departure_date.length < 1) {
            $('#Departure_date')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Excursions.length < 1) {
            $('#Excursions')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (name_vouchers.length < 1) {
            $('#name_vouchers')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if ($('#image').get(0).files.length == 0) {
            console.log($('#image').get(0).files.length);
            $('#divfile').after('<span class="error_name">Файл не выбран!</span>')
                .addClass('error-inf');
            _valid = false;
        }
        if (Cost.replace(/\s/g, '').length < 1) {
            $('#Cost').after('<span class="error">Введите стоимость путевки числом!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }  
        if (number_trips.replace(/\s/g, '').length < 1) {
            $('#number_trips').after('<span class="error">Введите количество человек числом!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (Information_vouchers.length < 1) {
            $('#Information_vouchers')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (!_valid) {
            e.preventDefault();
        }

    });

    $('#rout').click(function (e) {
            _valid = true;
            var Place = $('#Place').val();
            var Place_description = $('#Place_description').val();

            $(".error").remove();
            $(".cont_inf").removeClass('error-input');
            $(".error_name").removeClass('error-input');

            if (Place.length < 1) {
                $('#Place')
                    .after('<span class="error">Это обязательное поле!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }

            if (Place_description.length < 1) {
                $('#Place_description')
                    .after('<span class="error">Это обязательное поле!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }

            if ($('#Place_image').get(0).files.length == 0) {
                console.log($('#Place_image').get(0).files.length);
                $('#divfile').after('<span class="error_name">Файл не выбран!</span>')
                    .addClass('error-inf');
                _valid = false;
            }

        if (!_valid) {
            e.preventDefault();
            }
        });
      

    $('#reis').submit(function (e) {
        _valid = true;
        var Point_departure = $('#Point_departure').val();
        var Destination = $('#Destination').val();
        var Date_arrival = $('#Date_arrival').val();
        var Departure_date = $('#Departure_date').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');


        if (Point_departure.length < 1) {
            $('#Point_departure')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Destination.length < 1) {
            $('#Destination')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Date_arrival.length < 1) {
            $('#Date_arrival')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Departure_date.length < 1) {
            $('#Departure_date')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (!_valid) {
            e.preventDefault();
        }
    });

    $('#Payment').submit(function (e) {
        _valid = true;
        var Customer_sername = $('#Customer_sername').val();
        var Customer_name = $('#Customer_name').val();
        var Customer_patronymic = $('#Customer_patronymic').val();
        var bank_card_num = $('#bank_card_num').val();
        var date_payment = $('#date_payment').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');


        if (Customer_sername.length < 1) {
            $('#Customer_sername')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Customer_patronymic.length < 1) {
            $('#Customer_patronymic')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Customer_name.length < 1) {
            $('#Customer_name')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (date_payment.length < 1) {
            $('#date_payment')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (bank_card_num.replace(/\s/g, '').length < 1) {
            $('#bank_card_num')
                .after('<span class="error">Введите номер банковской карты!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (!_valid) {
            e.preventDefault();
        }
    });

    $('#Orders').submit(function (e) {
        _valid = true;
        var Customer_sername = $('#Customer_sername').val();
        var Customer_name = $('#Customer_name').val();
        var Customer_patronymic = $('#Customer_patronymic').val();
        var Employes_sername = $('#Employes_sername').val();
        var Employes_name = $('#Employes_name').val();
        var Employes_patronymic = $('#Customer_patronymic').val();
        var Number = $('#Number').val();
        var Date_registration = $('#Date_registration').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');


        if (Customer_sername.length < 1) {
            $('#Customer_sername')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Customer_patronymic.length < 1) {
            $('#Customer_patronymic')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Customer_name.length < 1) {
            $('#Customer_name')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Employes_sername.length < 1) {
            $('#Employes_sername')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Employes_patronymic.length < 1) {
            $('#Employes_patronymic')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Employes_name.length < 1) {
            $('#Employes_name')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Date_registration.length < 1) {
            $('#Date_registration')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Number.replace(/\s/g, '').length < 1) {
            $('#Number')
                .after('<span class="error">Введите числом количество человек!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (!_valid) {
            e.preventDefault();
        }
    });

 
    $('#Hotelt').click(function (e) {

            _valid = true;
            var Namehotel = $('#Namehotel').val();
            var description_hotel = $('#description_hotel').val();

            $(".error").remove();
            $(".cont_inf").removeClass('error-input');
            $(".error_name").removeClass('error-input');


            if (Namehotel.length < 1) {
                $('#Namehotel').after('<span class="error">Это обязательное поле!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }
            if (description_hotel.length < 1) {
                $('#description_hotel').after('<span class="error">Это обязательное поле!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }

            if ($('#image').get(0).files.length == 0) {
                console.log($('#image').get(0).files.length);
                $('#divfile').after('<span class="error_name">Файл не выбран!</span>')
                    .addClass('error-inf');
                _valid = false;
            }

        if (!_valid) {
            e.preventDefault();
            }
        });

    $('#countries_inf').click(function (e) {
        _valid = true;
        var Name_country = $('#Name_country').val();
        var Description_country = $('#Description_country').val();
       
        $(".error").remove();
        $(".cont_inf").removeClass('error-input');

        if (Name_country.length < 1) {
            $('#Name_country').after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
             
        if (Description_country.length < 1) {
            $('#Description_country').after('<span class="error">Это обязательное поле!</span>')
             .closest('.cont_inf')
             .addClass('error-input');
            _valid = false;
        }
        if ($('#image').get(0).files.length == 0) {
            console.log($('#image').get(0).files.length);
            $('#divfile').after('<span class="error_name">Файл не выбран!</span>')
                .addClass('error-inf');
            _valid = false;
        }

        if (!_valid) {
            e.preventDefault();

        }
    });

    $('#Employes').submit(function (e) {

        var _valid = true;
        var sername = $('#sername').val();
        var name = $('#name').val();
        var patronymic = $('#patronymic').val();
        var date_of_birth = $('#date_of_birth').val();
        var phone = $('#phone').val();
        var Email = $('#Email').val();
        var salary = $('#salary').val();
        var Password = $('#Password').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');


        if (date_of_birth.length < 1) {
            $('#date_of_birth')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (patronymic.length < 1) {
            $('#patronymic')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (sername.length < 1) {
            $('#sername')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (salary.replace(/\s/g, '').length < 1) {
            $('#salary').after('<span class="error">Введите зарплату числом!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (name.length < 1) {
            $('#name')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (Password.length < 8) {
            $('#Password')
                .after('<span class="error">Пароль должен быть не менее 8 символов!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (phone.length < 1) {
            $('#phone')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        else {
            var regEx = /^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/;
            var validtelephone = regEx.test(phone);
            if (!validtelephone) {
                $('#phone')
                    .after('<span class="error">Некорректно введен номер!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }
        }
        if (Email.length < 1) {
            $('#Email')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        else {
            var regEx = /^([a-z0-9_-]+\.)*[a-z0-9_-]+.[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/;
            var validEmail = regEx.test(Email);
            if (!validEmail) {
                $('#Email').after('<span class="error">Некорректно введена электронная почта!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }
        }


        if (!_valid) {
            e.preventDefault();
        }

    });

    $('#customers').submit(function (e) {
        var _valid = true;
        var sername = $('#sername').val();
        var name = $('#name').val();
        var patronymic = $('#patronymic').val();
        var Series = $('#Series').val();
        var Number = $('#Number').val();
        var date_of_birth = $('#date_of_birth').val();
        var phone = $('#phone').val();
        var Email = $('#Email').val();
        var adress = $('#adress').val();
        var Password = $('#Password').val();

        $(".error").remove();
        $(".cont_inf").removeClass('error-input');

        
        if (date_of_birth.length < 1) {
            $('#date_of_birth')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (patronymic.length < 1) {
            $('#patronymic')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (sername.length < 1) {
            $('#sername')
                .after('<span class="error">Это обязательное поле!</span>')
            .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
       
        if (adress.length < 1) {
            $('#adress')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (name.length < 1) {
            $('#name')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (Series.replace(/\s/g, '').length < 4) {
            $('#Series')
                .after('<span class="error">Введите 4 числа серии паспорта!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        if (Number.replace(/\s/g, '').length < 6) {
            $('#Number')
                .after('<span class="error">Введите 6 числа номера паспорта!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }

        if (Password.length < 8) {
            $('#Password')
                .after('<span class="error">Пароль должен быть не менее 8 символов!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
      
        if (phone.length < 1) {
            $('#phone')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        else {
            var regEx = /^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/;
            var validtelephone = regEx.test(phone);
            if (!validtelephone) {
                $('#phone')
                    .after('<span class="error">Некорректно введен номер!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }
        }
        if (Email.length < 1) {
            $('#Email')
                .after('<span class="error">Это обязательное поле!</span>')
                .closest('.cont_inf')
                .addClass('error-input');
            _valid = false;
        }
        else {
            var regEx = /^([a-z0-9_-]+\.)*[a-z0-9_-]+.[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/;
            var validEmail = regEx.test(Email);
            if (!validEmail) {
                $('#Email').after('<span class="error">Некорректно введена электронная почта!</span>')
                    .closest('.cont_inf')
                    .addClass('error-input');
                _valid = false;
            }
        }
     
        if (!_valid) {
            e.preventDefault();
        }
    
    });
});