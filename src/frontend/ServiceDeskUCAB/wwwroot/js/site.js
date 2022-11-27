// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetSelected() {
    console.log("Entre en el ");
    //Array de checkboxs.
    var selectedCheckbox = new Array();

    //Reference the Table.
    var tablaDepartamentos = document.getElementById("DeptTable");

    //Reference all the CheckBoxes in Table.
    var checks = tablaDepartamentos.getElementsByTagName("Input");

    // Loop and push the checked CheckBox value in Array.
    for (var i = 0; i < checks.length; i++) {
        if (checks[i].checked) {
            selected.push(checks[i].value);
            console.log("Entre en el if");
        }
    }

    //Display the selected CheckBox values.
    if (selectedCheckbox.length > 0) {
        alert("Selected values: " + selected.join(","));
    }
};
