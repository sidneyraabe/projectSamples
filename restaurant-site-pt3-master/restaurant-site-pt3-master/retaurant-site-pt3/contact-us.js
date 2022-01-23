function validateItems() {
    if (document.getElementById("Name").value == "")
    {
        alert("Name field is empty.")
        return false;
    }
    if (document.getElementById("Email").value == "")
    {
        alert("Email field is empty.")
        return false;
    }
    if (document.getElementById("Phone").value == "")
    {
        alert("Phone field is empty.")
        return false;
    } else {
    if (document.getElementById("Phone").value.length != 12) /* 12 char includes hyphens as specified in placeholder, 
    * this still allows for "numbers" such as 1-------10, but I do not know how to specify a certain string of numbers and hyphens in a particular order*/
    {
        alert("Phone field is not a valid phone number")
        return false;
    }
    }
    if (document.getElementById("M").checked == false && document.getElementById("T").checked == false &&  document.getElementById("W").checked == false &&  document.getElementById("Th").checked == false &&  document.getElementById("F").checked == false)
    {
        alert("Please check at least one day of the week.")
        return false;
    }
}