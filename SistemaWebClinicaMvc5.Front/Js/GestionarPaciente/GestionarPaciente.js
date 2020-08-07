
const formulario = document.getElementById('form1');
var idPaciente;

//Iniciar Datatable Listar Pacientes al cargar pagina
$(document).ready(function () {
    Tabla = $("#tbl_pacientes").DataTable({

        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "ajax": {
            "url": "/GestionarPaciente/ListarPacientes",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "IdPaciente", "name": "IdPaciente", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "ApPaterno", "name": "ApPaterno", "autoWidth": true },
            { "data": "ApMaterno", "name": "ApMaterno", "autoWidth": true },
            { "data": "Edad", "name": "Edad", "autoWidth": true },
            { "data": "Sexo", "name": "Sexo", "autoWidth": true },
            { "data": "NroDocumento", "name": "NroDocumento", "autoWidth": true },
            { "data": "Direccion", "name": "Direccion", "autoWidth": true },
            { "data": "Telefono", "name": "Telefono", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-xs btn-edit" data-target="#editmodal" data-toggle="modal"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></button>&nbsp;' +
                    '<Button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-xs btn-delete"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>'
            }
        ]
    });
});

//Registrar Paciente (accion ajax llamada por boton registrar)
function RegistrarPacienteAjax(data) {
    $.ajax({
        type: "POST",
        url: "/GestionarPaciente/RegistrarPaciente",
        data: {
            NroDocumento: data[0],
            Nombres: data[1],
            ApPaterno: data[2],
            ApMaterno: data[3],
            Sexo: data[4],
            Edad: data[5],
            Telefono: data[6],
            Direccion: data[7],
            Estado: data[8]
        },
        dataType: "json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            Tabla.ajax.reload(null, false);
            if (response) {                
                console.log(response);
            }
            else {
                console.log(response);
            }
        }
    });
};

//Actualizar Paciente (accion ajax llamada por boton Actualizar modal)
function ActualizaDatosPaciente(data) {
    $.ajax({
        type: "POST",
        url: "/GestionarPaciente/ActualizarPaciente",
        data: {
            IdPaciente: idPaciente,
            Nombres: data[0],
            ApPaterno: data[1],
            ApMaterno: data[2],
            Telefono: data[3],
            Direccion: data[4],
        },
        dataType: "json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response) {
                $('#editmodal').modal('hide');
                Tabla.ajax.reload(null, false);
                alert("Registro actualizado con exito");
            }
            else {
                alert("Problemas para actualizar...")
            }
        }
    });
}

function LlenaCamposModalEdita(data) {
    idPaciente = data[0];
    $("#txtModalNombre").val(data[1]);
    $("#txtModalNombre").val(data[1]);
    $("#txtModalApPaterno").val(data[2]);
    $("#txtModalApMaterno").val(data[3]);
    $("#txtModalTelefono").val(data[8]);
    $("#txtModalDireccion").val(data[7]);
}

//botón registrar paciente Formulario
$("#btnRegistrar").click(function (e) {
    e.preventDefault();
    var objPaciente = [];
    var NroDocumento = $("#txtNroDocumento").val();
    var Nombre = $("#txtNombres").val();
    var ApPaterno = $("#txtApPaterno").val();
    var ApMaterno = $("#txtApMaterno").val();
    var Sexo = $("#ddlSexo").val();
    var Edad = $("#txtEdad").val();
    var Telefono = $("#txtTelefono").val();
    var Direccion = $("#txtDireccion").val();
    var Estado = true;

    objPaciente.push(NroDocumento, Nombre, ApPaterno, ApMaterno, Sexo, Edad, Telefono, Direccion, Estado);

    RegistrarPacienteAjax(objPaciente);
});

// evento click boton actualizar registro en Datatable
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    LlenaCamposModalEdita(valores);

});

//botón actualizar paciente en Modal
$("#btnActualizar").click(function (e) {
    e.preventDefault();
    var objActualizaPaciente = [];
    var Nombre = $("#txtModalNombre").val();
    var ApPaterno = $("#txtModalApPaterno").val();
    var ApMaterno = $("#txtModalApMaterno").val();
    var Telefono = $("#txtModalTelefono").val();
    var Direccion = $("#txtModalDireccion").val();

    objActualizaPaciente.push(Nombre, ApPaterno, ApMaterno, Telefono, Direccion);

    ActualizaDatosPaciente(objActualizaPaciente);
});

// evento click boton Eliminar registro Datatable
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    console.log(valores);

});

$("#btnCancelar").click(function (e) {
    e.preventDefault();
    formulario.reset();
    //RegistrarPacienteAjax();
});