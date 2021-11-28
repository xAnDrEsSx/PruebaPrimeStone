function buscarEstudiante() {

    var DocumentNumber = document.getElementById("DocumentNumber").value;

    if (DocumentNumber > 0) {


        document.getElementById('IdStudent').value = 0;
        document.getElementById('Name').value = "";
        document.getElementById('LastName').value = "";
        document.getElementById('Name').hidden = true;
        document.getElementById('LastName').hidden = true;
        document.getElementById('IdStudent').hidden = true;

        $.ajax({
            type: "GET",
            url: '/Enroll/GetStudent?documentNumber=' + DocumentNumber,
            success: function (data) {
                if (data.statusCode == 200) {
                    window.location.href = '/Enroll/IndexConsulta?IdStudent=' + data.response.Id;
                } else {
                    swal("", "No se ha encontrado estudiante!", "error");
                    return false;
                }
            },
            error: function (xhr) {
                alert("Se ha presentado un error inesperado");
            }
        });

    } else {
        swal("", "Documento no válido!", "success");
    }
}

function limpiar() {

    document.getElementById('IdStudent').value = 0;
    document.getElementById('Name').value = "";
    document.getElementById('LastName').value = "";
    document.getElementById('DocumentNumber').value = "";

    document.getElementById('Name').hidden = true;
    document.getElementById('LastName').hidden = true;
    document.getElementById('IdStudent').hidden = true;

    document.getElementById('DocumentNumber').disabled = false;
    document.getElementById('limpiar').hidden = true;
}

function Matricular(Id) {

    var IdStudent = document.getElementById('IdStudent').value;
    if (!validarCampos(Id, IdStudent)) {
        return false;
    }

    $.ajax({
        type: "POST",
        dataType: 'json',
        data: { "IdCourse": Id, "IdStudent": IdStudent},
        url: "/Enroll/Index",
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: "¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Enroll/IndexConsulta?IdStudent=' + IdStudent;
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

function validarCampos(Id, IdStudent) {

    if (Id == null || Id <= 0 || Id == "") {
        swal("", "Curso no válido!", "error");
        return false;
    }

    if (IdStudent == null || IdStudent <= 0 || IdStudent == "") {
        swal("", "Curso no válido!", "error");
        return false;
    }

    return true;

}

function CancelarMatricula(Id) {

    var IdStudent = document.getElementById('IdStudent').value;
    if (!validarCampos(Id, IdStudent)) {
        return false;
    }

    $.ajax({
        type: "POST",
        dataType: 'json',
        data: { "IdCourse": Id, "IdStudent": IdStudent },
        url: "/Enroll/DeleteEnroll",
        success: function (data) {
            if (data.statusCode == 200) {
                swal({
                    title: "Mensaje",
                    text: "¡Bien! " + data.message,
                    type: "success"
                }).then(function () {
                    window.location.href = '/Enroll/IndexConsulta?IdStudent=' + IdStudent;
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