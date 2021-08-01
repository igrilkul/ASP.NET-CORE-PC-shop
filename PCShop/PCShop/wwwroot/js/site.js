// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function myFunction(pageName) {
    if (pageName == "Carts")
    {
        var myobj = document.getElementById("cart");
        myobj.remove();
    }
    
}