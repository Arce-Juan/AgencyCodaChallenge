
function Global_SetCookie(name, value) {
    let date = new Date();
    date.setTime(date.getTime() + 3600000);
    let expires = date.toUTCString();
    document.cookie = name + "=" + (value || "") + ";expires=" + expires + ";path=/";
}

function Global_GetCookie(name) {
    let nameEQ = name + "=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}