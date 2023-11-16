$(document).ready(function () {
    $('#emprestimo').DataTable({
        language: {
            "lengthMenu":"Mostrar _MENU_ entradas",
            "search": "Procurar:",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Proximo",
                "previous":"Anterior"
                }
            }
        });
});