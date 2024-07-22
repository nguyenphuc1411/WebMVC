document.getElementById("btnMoMenu").addEventListener("click", function () {
    var aside = document.getElementById('aside');
    if (aside.classList.contains('d-none')) {
        aside.classList.remove('d-none');
        aside.classList.add('hienthi');
    } else {
        aside.classList.add('d-none');
        aside.classList.remove('hienthi');
    }
    // Sử dụng setTimeout để thêm lớp CSS và thực hiện hiệu ứng sau khi div đã hiển thị
    setTimeout(function () {
        aside.style.opacity = 1;
    }, 100);
});





