function otpInputKey() {
    $('.digit-group').find('input').each(function () {
        $(this).attr('maxlength', 1);
        $(this).on('keyup', function (e) {
            var parent = $($(this).parent());

            if (e.keyCode === 8 || e.keyCode === 37) {
                var prev = parent.find('input#' + $(this).data('previous'));

                if (prev.length) {
                    $(prev).select();
                }
            } else if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode === 39) {
                var next = parent.find('input#' + $(this).data('next'));

                if (next.length) {
                    $(next).select();
                } else {
                    if (parent.data('autosubmit')) {
                        parent.submit();
                    }
                }
            }
        });
    });

    /** Funcion para ver contraseña */
}

function showPassword() {

    var contrasena = document.getElementById("contrasena");

    if (contrasena.type === "password") {
        contrasena.type = "text";
        $('#iconContrasena').addClass("iconContrasena")
    } else {
        contrasena.type = "password";
        $('#iconContrasena').removeClass("iconContrasena")
    }
}

function showConfPassword() {

    var contrasena = document.getElementById("confcontrasena");
    if (contrasena.type === "password") {
        contrasena.type = "text";
        $('#iconConfContrasena').addClass("iconContrasena");
    } else {
        contrasena.type = "password";
        $('#iconConfContrasena').removeClass("iconContrasena");
    }
}


function activeStep(step) {

    if (step == 1) {
        $('#step1').addClass('activeStep');
        $('#activeLine1').addClass('activeLine');
    }
    if (step == 2) {
        $('#step2').addClass('activeStep');
        $('#activeLine2').addClass('activeLine');
    }
}

function activeStepAsist(step) {

    if (step == 1) {
        $('#step1').addClass('activeStepAsist');
        $('#activeLineAsist1').addClass('activeLineAsist');
    }
}


function activedTerminos() {
    $('#scrollTerminos').bind('scroll', function () {
        var scrollBottom = $(this).scrollTop();
        var scrollInner = $(this).innerHeight();
        if (scrollBottom + scrollInner + 1 >= $(this)[0].scrollHeight) {
            $("#btnTerminos").prop('disabled', false);
            $("#btnDeclinar").prop('disabled', false);
        }
    })
}

function activedPagare() {
    $('#scrollPagare').bind('scroll', function () {
        var scrollBottom = $(this).scrollTop();
        var scrollInner = $(this).innerHeight();
        if (scrollBottom + scrollInner + 1 >= $(this)[0].scrollHeight) {
            $("#btnPagare").prop('disabled', false);
            $(".btnDeclinarPagare").prop('disabled', false);
        }
    })
}



function SumarCampo() {
    $('.btn-number').click(function (e) {
        e.preventDefault();

        var input = $("input[name='cantidad']");
        var currentVal = parseInt(input.val());
        if (!isNaN(currentVal)) {
            if (currentVal < input.attr('max')) {
                input.val(currentVal + 1).change();
            }
            if (parseInt(input.val()) == input.attr('max')) {
                $(this).attr('disabled', true);
            }
        } else {
            input.val(0);
        }
    });
}
function RestarCampo() {
    $('.btn-number').click(function (e) {
        e.preventDefault();

        var input = $("input[name='cantidad']");
        var currentVal = parseInt(input.val());
        if(type == 'minus') {
            
            if(currentVal > input.attr('min')) {
                input.val(currentVal - 1).change();
            } 
            if(parseInt(input.val()) == input.attr('min')) {
                $(this).attr('disabled', true);
            }
        } else {
            input.val(0);
        }
    });
}

$(".input-number").keydown(function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
        // Allow: Ctrl+A
        (e.keyCode == 65 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});