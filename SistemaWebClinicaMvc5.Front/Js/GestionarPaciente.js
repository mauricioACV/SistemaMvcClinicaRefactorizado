
$(document).ready(function () {
    $("#tbl_pacientes").DataTable({
        "processing": true,
        "serverSide": true,
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
            { "data": "Telefono", "name": "Telefono", "autoWidth": true }
        ]
    });
});