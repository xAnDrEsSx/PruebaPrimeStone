function estaSeguroCrear() {

    swal({
        title: "Esta seguro?",
        text: "Desea continuar con el registro!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                registrarCurso();
            } else {
            }
        });
}

function registrarCurso() {

    if (!validarCampos()) {
        return;
    }

    var jsonData = {};
    //converting to formname:formvalue format
    $.each($("#FormApp").serializeArray(), function (i, field) {
        jsonData[field.name] = field.value || '';
    });

    //$("#mensajeResp").html("<div class='ui active inline loader myLoader' style='margin-bottom:1%;'></div>");

    $.ajax({
        type: "POST",
        dataType: 'json',
        data: jsonData,
        url: "/Course/Index",
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: "¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Course/Index';
                })
                return false;

            } else {
                swal("", data.message, "error");
            }
        },
        error: function (xhr) {
            alert("Se ha presentado un error inesperado");
        }
    });

}

function estaSeguroBorrar(Id) {

    if (Id > 0) {

        swal({
            title: "Esta seguro?",
            text: "Desea proceder con la eliminación del registro",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    borrarCurso(Id);
                } else {
                }
            });

    }
}

function borrarCurso(Id) {

    $.ajax({
        type: "GET",
        dataType: 'json',
        url: '/Course/DeleteCourse?Id=' + Id,
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: " ¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Course/Index';
                })
                return false;

            } else {
                swal("", data.message, "error");
            }
        },
        error: function (xhr) {
            alert("Se ha presentado un error inesperado");
        }
    });

}

function limpiar() {
    document.getElementById('Id').value = 0;
    document.getElementById('Name').value = "";
    document.getElementById('Hours').value = "";
    document.getElementById('StartDate').value = fechaActual();
}

function fechaActual() {

    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    today = yyyy + '/' + mm + '/' + dd;

    return today;
}

function validarCampos() {

    // Valida Fecha
    var fecha = document.getElementById('StartDate').value;
    var name = document.getElementById('Name').value;
    var horas = document.getElementById('Hours').value;
    var fechaNow = fechaActual();

    if (fecha == null || fecha == "") {
        swal("", "Fecha no Valida!", "error");
        return false;
    }

    if (name == "" || name == null) {
        swal("", "Nombre Curso no Valido!", "error");
        return false;
    }
    if (horas == "" || horas == null || horas <= 0) {
        swal("", "Horas no Validas!", "error");
        return false;
    }

    if (fecha < fechaNow) {
        swal("", "La fecha debe ser mayor o igual a Hoy!", "error");
        return false;
    }

    return true;

}