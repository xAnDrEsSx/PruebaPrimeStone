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
                registrarEstudiante();
            } else {
            }
        });
}

function registrarEstudiante() {

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
        url: "/Student/Index",
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: "¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Student/Index';
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

function actualizarEstudiante() {

    if (!validarCampos()) {
        return;
    }

    document.getElementById('DocumentNumber').disabled = false;
    var jsonData = {};

    //converting to formname:formvalue format
    $.each($("#FormApp").serializeArray(), function (i, field) {
        jsonData[field.name] = field.value || '';
    });

    var Id = document.getElementById("Id").value;

    $.ajax({
        type: "POST",
        dataType: 'json',
        data: jsonData,
        url: "/Student/UpdateStudent",
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: "¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Student/IndexUpdate?Id=' + Id;
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
                    borrarEstudiante(Id);
                } else {
                }
            });

    }
}

function borrarEstudiante(Id) {

    $.ajax({
        type: "GET",
        dataType: 'json',
        url: '/Student/DeleteStudent?Id=' + Id,
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: " ¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Student/Index';
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

function validar() {

    var DocumentNumber = document.getElementById("DocumentNumber").value;

    document.getElementById('save').hidden = true;
    document.getElementById('update').hidden = true;

    document.getElementById('Email').disabled = true;
    document.getElementById('LastName').disabled = true;
    document.getElementById('Name').disabled = true;

    if (DocumentNumber > 0) {
        $.ajax({
            type: "GET",
            url: '/Student/ValidateStudent?documentNumber=' + DocumentNumber,
            success: function (data) {
                if (data.statusCode == 200) {
                    swal({
                        title: "Mensaje",
                        text: "Estudiante ya existe, puede Actualizar sus datos",
                        type: "success"
                    }).then(function () {
                        document.getElementById('Id').value = data.response.Id;
                        document.getElementById('Email').value = data.response.Email;
                        document.getElementById('Name').value = data.response.Name;
                        document.getElementById('LastName').value = data.response.LastName;
                        document.getElementById('update').hidden = false;


                        document.getElementById('Email').disabled = false;
                        document.getElementById('LastName').disabled = false;
                        document.getElementById('Name').disabled = false;
                        document.getElementById('DocumentNumber').disabled = true;


                    })
                    return false;

                } else {
                    document.getElementById('Id').value = 0;
                    document.getElementById('Email').value = "";
                    document.getElementById('Name').value = "";
                    document.getElementById('LastName').value = "";
                    document.getElementById('save').hidden = false;

                    document.getElementById('Email').disabled = false;
                    document.getElementById('LastName').disabled = false;
                    document.getElementById('Name').disabled = false;

                    swal("", "Estudiante no existe, puede registrarlo", "success");


                }
            },
            error: function (xhr) {
                alert("Se ha presentado un error inesperado");
            }
        });
    }

}

function limpiar() {

    document.getElementById('save').hidden = true;
    document.getElementById('update').hidden = true;

    document.getElementById('Email').disabled = true;
    document.getElementById('LastName').disabled = true;
    document.getElementById('Name').disabled = true;
    document.getElementById('DocumentNumber').disabled = false;

    document.getElementById('Id').value = 0;
    document.getElementById('DocumentNumber').value = "";
    document.getElementById('Email').value = "";
    document.getElementById('Name').value = "";
    document.getElementById('LastName').value = "";

}

function validarCampos() {

    var DocumentNumber = document.getElementById('DocumentNumber').value;
    var Email = document.getElementById('Email').value;
    var Name = document.getElementById('Name').value;
    var LastName = document.getElementById('LastName').value;

    if (DocumentNumber == null || DocumentNumber <= 0 || DocumentNumber == "") {
        swal("", "Número de Documento no válido!", "error");
        return false;
    }

    if (Email == null || Email == "") {
        swal("", "Email no válido!", "error");
        return false;
    }

    if (Name == null || Name == "") {
        swal("", "Nombre no válido!", "error");
        return false;
    }

    if (LastName == null || LastName == "") {
        swal("", "Apellido no válido!", "error");
        return false;
    }

    return true;

}