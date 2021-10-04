var ta;
var ws = null;
var bstart;
var bsstop;

window.onload = function () {
    if (Modernizr.websockets) {
        WriteMessage('support', 'да ');
        ta = document.getElementById('ta');
        bstart = document.getElementById('bstart');
        bstop = document.getElementById('bstop');
        bstart.disabled = false;
        bstop.disabled = true;
    }
}

function WriteMessage(idspan, txt) {
    var span = document.getElementById(idspan);
    span.innerHTML = txt;
}

function exe_start() {
    if (ws == null) {
        ws = new WebSocket('wss://localhost:4002/websocketHandler');
        ws.onopen = function () {//для устновки соединеня
            ws.send('Соединение');//Для посылки данных используется метод socket.send(data). Пересылать можно любые данные.
        }
        ws.onclose = function (s) {// для обрыва соединения
            console.log('onclose ', s);
        }
        ws.onmessage = function (evt) {// для получения данных
            ta.innerHTML += '\n' + evt.data;
        }
        bstart.disabled = true;
        bstop.disabled = false;
    }
}
function exe_stop() {
    ws.close(3001, 'stopapplication');
    ws = null;
    bstart.disabled = false;
    bstop.disabled = true;
}