// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Función notificaciones Tipo puede ser "error", "alerta", "exito"
function NotificaFn($not_tipo, $not_titulo, $not_texto, $custom_id, $forever) {
    var $new_notif = $("#notif-gen").clone();
    $new_notif.removeAttr('id');
    switch ($not_tipo.toLowerCase()) {
        case "exito":
            $new_notif.addClass("alert-success-govco");
            $new_notif.attr("aria-label", "Alerta: caso de éxito");
            $new_notif.find(".govco-icon").addClass("govco-icon-check-cn");
            break;
        case "alerta":
            $new_notif.addClass("alert-warning-govco");
            $new_notif.attr("aria-label", "Alerta: caso de alerta");
            $new_notif.find(".govco-icon").addClass("govco-icon-exclamation-cn");
            break;

        case "error":
            $new_notif.addClass("alert-wrong-govco");
            $new_notif.attr("aria-label", "Alerta: caso de error");
            $new_notif.find(".govco-icon").addClass("govco-icon-sad-face-n");
            break;
    }
    if ($not_titulo) {
        $new_notif.find(".headline-l-govco").text($not_titulo);
    }

    if ($not_texto) {
        $new_notif.find("p").text($not_texto);
    } else { $new_notif.find("p").addClass("d-none"); }
    if ($custom_id) {
        $("#" + $custom_id).prepend($new_notif);
    } else {
        $("#notif-zone").prepend($new_notif);
    }
    if ($forever) {
        $($new_notif).removeClass("d-none").addClass("show").fadeIn();
    } else {
        $($new_notif).removeClass("d-none").addClass("show").fadeIn().delay(5000).fadeOut();
    }
}
