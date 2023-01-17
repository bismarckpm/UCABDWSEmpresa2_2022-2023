const buscador = document.getElementById('search');
const keys = [
    { keyCode: 'AltLeft', isTriggered: false },
    { keyCode: 'ControlLeft', isTriggered: false },
];

// Script para mostrar ventana Agregar Departamento

$(function () {
    var PlaceHolderElement = $('#PlaceHolderAgregarDepartamento');
    $('button[data-toggle="agregarDepartamento-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para mostrar ventana Editar Departamento

$(function () {
    var PlaceHolderElement = $('#PlaceHolderModificarDepartamento');
    $('button[data-toggle="editarDepartamento-modal"]').click(function (event) {
        var id = $(this).closest('tr').find('.id').text();
        console.log(id);
        var url = $(this).data('url').replace("idDepartamento", id);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para mostrar ventana Eliminar Departamento

$(function () {
    var PlaceHolderElement = $('#PlaceHolderEliminarDepartamento');
    $('button[data-toggle="eliminarDepartamento-modal"]').click(function (event) {
        var id = $(this).closest('tr').find('.id').text();
        var url = $(this).data('url').replace("idDepartamento", id);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})


//Script para el buscador
buscador.addEventListener("keyup", function () {
    var keyword = this.value;
    keyword = keyword.toUpperCase();
    var table = document.getElementById("table");
    var all_tr = table.getElementsByTagName("tr");
    for (var i = 0; i < all_tr.length; i++) {
        var name_column = all_tr[i].getElementsByTagName("td")[1];
        var description_column = all_tr[i].getElementsByTagName("td")[2];
        if (name_column && description_column) {
            var name_value = name_column.textContent || name_column.innerText;
            var description_value = description_column.textContent || description_column.innerText;
            name_value = name_value.toUpperCase();
            description_value = description_value.toUpperCase();
            if ((name_value.indexOf(keyword) > -1) || (description_value.indexOf(keyword) > -1)) {
                all_tr[i].style.display = "";
            } else {
                all_tr[i].style.display = "none"; 
            }
        }
    }
})

//Script para activar el buscador con Alt+Ctrl

window.addEventListener('keydown', (e) => {
    keys.forEach((obj) => {
        if (obj.keyCode === e.code) {
            obj.isTriggered = true;
        }
    });

    const shortcutTriggered = keys.filter((obj) => obj.isTriggered).length === keys.length;

    if (shortcutTriggered) {
        buscador.focus();
    }
});

window.addEventListener('keyup', (e) => {
    keys.forEach((obj) => {
        if (obj.keyCode === e.code) {
            obj.isTriggered = false;
        }
    });
});