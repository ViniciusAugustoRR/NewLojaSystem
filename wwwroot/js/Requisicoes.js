
async function Requisicao(tipo, url, funcao, dados) {
    await $.ajax({
        type: tipo,
        url: url,
        dataType: 'json',
        cache: false,
        async: true,
        data: dados,
        success: funcao,
        error: function (xhr, ajaxOptions, thrownError) {
            removePreload()
            Swal.fire('Atenção!', 'Um erro ocorreu, tente novamente!', 'error');
            throw 'Erro requisição'
        }
    });
}
