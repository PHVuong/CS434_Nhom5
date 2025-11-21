namespace SmartMotoRental.Models;

public enum UserRole
{
    Admin = 1,      // Quản trị viên
    Staff = 2,      // Nhân viên
    Customer = 3    // Khách hàng   
}

public enum ChatSender
{
    System = 0,      // Thông báo từ hệ thống
    Admin = 1,
    User = 2        // Thông báo từ người dùng
}

public enum RentalStatus
{
    Pending = 0,     // Đơn hàng đang chờ xử lý
    Active = 1,      // Đơn hàng đang được thuê
    Completed = 2,   // Đơn hàng đã hoàn thành
    Cancelled = 3    // Đơn hàng đã hủy
}

public enum PaymentMethod
{
    Cash = 0,        // Thanh toán bằng tiền mặt
    Card = 1,        // Thanh toán bằng thẻ
    BankTransfer = 2, // Thanh toán bằng chuyển khoản
    EWallet = 3      // Thanh toán bằng ví điện tử
}

public enum MotorbikeCondition
{
    New = 0,         // Moto mới    
    Good = 1,        // Moto tốt
    Fair = 2,        // Moto trung bình
    Poor = 3         // Moto xấu
}

public enum MotorbikeStatus
{
    Available = 0,  // Moto đang sẵn sàng cho thuê
    Unavailable = 1, // Moto đang được thuê
    Maintenance = 2, // Moto đang được sửa chữa
    Rented = 3       // Moto đang được thuê
}

public enum NotificationType
{
    System = 0,      // Thông báo từ hệ thống
    Rental = 1,      // Thông báo về việc thuê máy
    Payment = 2,     // Thông báo về việc thanh toán
    Promotion = 3    // Thông báo về việc khuyến mãi
}


