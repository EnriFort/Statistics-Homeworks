document.addEventListener("DOMContentLoaded", function () {
    const canvas = document.getElementById("myCanvas");
    const ctx = canvas.getContext("2d");
    const shapeSelector = document.getElementById("shapeSelector");
    const drawButton = document.getElementById("drawButton");

    drawButton.addEventListener("click", drawShape);

    function drawShape() {
        const selectedShape = shapeSelector.value;
        ctx.clearRect(0, 0, canvas.width, canvas.height); // Clear the canvas

        switch (selectedShape) {
            case "line":
                ctx.beginPath();
                ctx.moveTo(50, 50);
                ctx.lineTo(200, 200);
                ctx.stroke();
                break;

            case "point":
                ctx.beginPath();
                ctx.arc(100, 100, 5, 0, Math.PI * 2);
                ctx.fillStyle = "red";
                ctx.fill();
                break;

            case "circle":
                ctx.beginPath();
                ctx.arc(200, 200, 50, 0, Math.PI * 2);
                ctx.stroke();
                break;

            case "rectangle":
                ctx.beginPath();
                ctx.rect(150, 150, 100, 80);
                ctx.stroke();
                break;
        }
    }
});
