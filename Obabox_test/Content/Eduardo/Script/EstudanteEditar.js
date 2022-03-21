
$("#Salvar").on("click", function (e) {
    e.preventDefault()
    let url = $(this).attr("href")
    let Estudante = {
        "Identificador": $("#Identificador").val(),
        "Nome": $("#Nome").val(),
        "Curso": $("#Curso").val(),
        "DataNascimento": $("#DataNascimento").val(),
        "Status": $("#Status").val()==1,
    }
    $.post({
        url: url,
        data: { Estudante },
        success: function (data) {
            console.log(data)
            if (Estudante.Identificador == data)
                alert("alterado Com sucesso")
            else
                window.location = "/Eduardo/EstudanteEditar/" + data
        }
    })
    
})