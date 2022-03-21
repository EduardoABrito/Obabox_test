$(document).ready(function () {
    Consultar()
})

function Consultar() {
    let Filtro = {
        "Identificador": $("#Identificador").val(),
        "Nome": $("#Nome").val(),
        "Curso": $("#Curso").val(),
        "Status": $("#Status").val(),
    }

    $('#table_estudantes').DataTable({
        "destroy":true,
        "ajax": {
            "url": "/Eduardo/Estudante_SelecionarFiltro",
            "type": "POST",
            "data": { Filtro },
            "dataSrc": "Data"
        },
        "columns": [
            { "data": "Identificador" },
            { "data": "Nome" },
            { "data": "Curso" },
            { "data": "DataNascimento", "render": function (data) { return new Date(data.toString().replace("/\D+/g", "")).toDateString() } },
            { "data": "Status", "render": function (data) { return data ? "Sim" : "Não" } },
            { "data": "Acoes", "render": function (data, type,row) { return `<a href="/Eduardo/EstudanteEditar/${row["Identificador"]}" class="btn btn-danger">Editar</a>` } },
        ]
    });
}

$("#buscar").on("click", function (e) {
    e.preventDefault()
    Consultar()
})
