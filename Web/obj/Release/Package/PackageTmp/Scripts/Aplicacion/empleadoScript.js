function AbrirModalEliminarEmpleado(_idCodeEmp) {
    $("#CODEMP_ELI").val(_idCodeEmp);
$("#ModalEliminarEmpleado").modal("show");
}

function AbrirModalCrear() {
    $("#ModalCrearEmpleado").modal("show");
}

function AbrirModalActualizar(_idCodeEmp, _nombreEmp) {
    $("#CODEMP").val(_idCodeEmp);
$("#nombreEmp").html(_nombreEmp);
$("#ModalActualizarEmpleado").modal("show");
}

function CrearEmpleado() {
    $("#notificacionCrearEmpleado").empty();

var empleadoDTO = {
    NOMEMP: $("#NOMEMP_CRE").val(),
SEXOEMP: $("#SEXOEMP_CRE").val(),
EDADEMP: $("#EDADEMP_CRE").val(),
SUELDOEMP: $("#SUELDOEMP_CRE").val()
    };

$.ajax({
    type:'POST',
async:'false',
url: '@Url.Action("Crear","Empleado")',
dataType:'json',
data: empleadoDTO,
beforeSend: function () {
    $("#notificacionCrearEmpleado").html('<div class="alert alert-success alert-dismissible> Cargando . . .></div>');
            },
success: function (response) {
                if (response.ok == true) {
    $("#notificacionCrearEmpleado").html('<div class="alert alert-info alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
setTimeout(function () {
    $("#notificacionCrearEmpleado").empty();
location.reload();
                    }, 1000);
                } else {
    $("#notificacionCrearEmpleado").html('<div class= "alert alert-warning alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
                }
            },
error: function (ex) {
    $("#notificacionCrearEmpleado").html('<div class= "alert alert-danger alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div >');
            }
        });
}

function ActualizarEmpleado() {
    $("#notificacionActualEmpleado").empty();

var empleadoDTO = {
    CODEMP: $("#CODEMP_ACT").val(),
EDADEMP: $("#EDADEMP_ACT").val(),
SUELDOEMP: $("#SUELDOEMP_ACT").val()
    };

$.ajax({
    type:'POST',
async:'false',
url: '@Url.Action("Actualizar","Empleado")',
dataType:'json',
data: empleadoDTO,
beforeSend: function () {
    $("#notificacionActualizarEmpleado").html('<div class="alert alert-success alert-dismissible> Cargando . . .></div>');
        },
success: function (response) {
            if (response.ok == true) {
    $("#notificacionActualizarEmpleado").html('<div class="alert alert-info alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
setTimeout(function () {
    $("#notificacionActualizarEmpleado").empty();
location.reload();
                }, 1000);
            } else {
    $("#notificacionActualizarEmpleado").html('<div class= "alert alert-warning alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
            }
        },
error: function (ex) {
    $("#notificacionActualizarEmpleado").html('<div class= "alert alert-danger alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div >');
        }
    });
}

function EliminarLogicoEmpleado() {
    $("#notificacionEliminarEmpleado").empty();

$.ajax({
    type:'POST',
async:'false',
url: '@Url.Action("EliminarLogico", "Empleado")',
dataType:'json',
data: {_id:$("#CODEMP_ELI").val()},
beforeSend: function () {
    $("#notificacionEliminarEmpleado").html('<div class="alert alert-success alert-dismissible> Cargando . . .></div>');
        },
success: function (response) {
            if (response.ok == true) {
    $("#notificacionEliminarEmpleado").html('<div class="alert alert-info alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
setTimeout(function () {
    $("#notificacionEliminarEmpleado").empty();
location.reload();
                }, 1000);
            } else {
    $("#notificacionEliminarEmpleado").html('<div class= "alert alert-warning alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
            }
        },
error: function (ex) {
    $("#notificacionEliminarEmpleado").html('<div class= "alert alert-danger alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div >');
        }
    });
}

function EliminarFisicoEmpleado() {
    $("#notificacionEliminarEmpleado").empty();

$.ajax({
    type:'POST',
async:'false',
url: '@Url.Action("EliminarFisico", "Empleado")',
dataType:'json',
data: {_id:$("#CODEMP_ELI").val()},
beforeSend: function () {
    $("#notificacionEliminarEmpleado").html('<div class="alert alert-success alert-dismissible> Cargando . . .></div>');
    },
success: function (response) {
        if (response.ok == true) {
    $("#notificacionEliminarEmpleado").html('<div class="alert alert-info alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
setTimeout(function () {
    $("#notificacionEliminarEmpleado").empty();
location.reload();
            }, 1000);
        } else {
    $("#notificacionEliminarEmpleado").html('<div class= "alert alert-warning alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div>');
        }
    },
error: function (ex) {
    $("#notificacionEliminarEmpleado").html('<div class= "alert alert-danger alert-dismissible><h4 class="text-center">' + response.mensaje + '</h4></div >');
    }
});
}
