
function validateVehicleData()
{

    if (document.getElementById("<%=TextBoxBrandOfVehicle.ClientID%>").value == "") {
        alert("Porfavor ingrese una marca");
        document.getElementById("<%=TextBoxBrandOfVehicle.ClientID%>").focus();
        return false;
    }
    var plate = document.getElementById("<%=TextBoxIdOfVehicle.ClientID%>").value;
    if (plate == "") {
        alert("Porfavor ingrese una placa");
        document.getElementById("<%=TextBoxIdOfVehicle.ClientID%>").focus();
        return false;
    }
    return true;
}
