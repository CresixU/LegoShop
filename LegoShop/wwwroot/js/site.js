let cropper;
document.querySelector('.custom-file-input').addEventListener('click', function () {
    document.getElementById('fileInput').click();
});

document.getElementById('fileInput').addEventListener('change', function (e) {
    let file = e.target.files[0];
    if (!file) {
        return;
    }
    document.querySelector('.file-status').textContent = 'Obraz został załadowany';
    let reader = new FileReader();
    reader.onload = function (event) {
        let img = document.getElementById('image');
        img.src = event.target.result;
        if (cropper) {
            cropper.destroy();
        }
        cropper = new Cropper(img, {
            aspectRatio: 1,
            viewMode: 1,
        });
    }
    reader.readAsDataURL(file);
});

document.getElementById('cropButton').addEventListener('click', function () {
    if (cropper) {
        let canvas = cropper.getCroppedCanvas({
            width: 500,
            height: 500
        });
        createMosaic(canvas);
    }
});

function createMosaic(canvas) {
    let ctx = canvas.getContext('2d');
    let imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    let pixels = imageData.data;
    let mosaicContainer = document.getElementById('mosaicContainer');
    mosaicContainer.innerHTML = ''; // Czyści kontener przed tworzeniem nowej mozaiki

    let circleSize = Math.floor(Math.min(canvas.width, canvas.height) / 48);

    // Ustawienie rozmiaru kontenera mozaiki
    mosaicContainer.style.width = `${circleSize * 48}px`;
    mosaicContainer.style.height = `${circleSize * 48}px`;

    for (let y = 0; y < 48; y++) {
        for (let x = 0; x < 48; x++) {
            let i = ((y * circleSize) * canvas.width + (x * circleSize)) * 4;
            let color = `rgb(${pixels[i]}, ${pixels[i + 1]}, ${pixels[i + 2]})`;
            let circle = document.createElement('div');
            circle.style.width = `${circleSize}px`;
            circle.style.height = `${circleSize}px`;
            circle.style.backgroundColor = color;
            circle.style.borderRadius = '50%';
            circle.style.position = 'absolute';
            circle.style.left = `${x * circleSize}px`;
            circle.style.top = `${y * circleSize}px`;
            mosaicContainer.appendChild(circle);
        }
    }
}
