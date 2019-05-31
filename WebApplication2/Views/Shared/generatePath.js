function generatePath(firstLon, firstLat, locations, canvas) {
    canvas.beginPath();
    canvas.moveTo(firstLon, firstLat);
    for (var i = 0; i < locations.length; i++) {
        myCanvas.lineTo(locations[i].x, locations[i].y);
        myCanvas.strokeStyle = "red";
        myCanvas.stroke();
    }
}

function drawCircle(Lon, Lat, canvas) {
    canvas.lineWidth = '3';
    canvas.strokeStyle = "white";
    canvas.beginPath();
    canvas.arc(Lon, Lat, 5, 0, 2 * Math.PI);
    canvas.fillStyle = "red";
    canvas.fill();
    canvas.stroke();
}
