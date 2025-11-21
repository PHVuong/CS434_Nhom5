// Xử lý đăng nhập demo
document.getElementById("btnLogin").addEventListener("click", function() {
    const username = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();

    // Kiểm tra rỗng
    if (!username || !password) {
        alert("Vui lòng nhập đầy đủ thông tin!");
        return;
    }

    // Demo kiểm tra tài khoản
    const demoUser = "admin";
    const demoPass = "123";

    if (username === demoUser && password === demoPass) {
        alert("Đăng nhập thành công!");
        // Lưu token demo (nếu muốn)
        localStorage.setItem("token", "demo123");
        // Chuyển sang trang khác
        window.location.href = "DatThueXe.html";
    } else {
        alert("Sai tài khoản hoặc mật khẩu!");
    }
});
