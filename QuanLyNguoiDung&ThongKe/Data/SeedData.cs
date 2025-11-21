using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Models;

namespace SmartMotoRental.Data;

public static class SeedData
{
    public static async Task SeedAsync(SmartMotoRentalContext context)
    {
        await context.Database.EnsureCreatedAsync();
        if (!await context.Motorbikes.AnyAsync())
        {
            var motorbikes = new List<Motorbike>
            {
                new Motorbike
                {
                    Name = "Honda Vision 2024",
                    Type = "Tay ga",
                    Brand = "Honda",
                    Year = 2024,
                    PlateNumber = "43A-11111",
                    Condition = MotorbikeCondition.New,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 40000,
                    PricePerDay = 140000,
                    Location = "Thanh Khê, Đà Nẵng",
                    Description = "Xe mới 100%, động cơ êm ái, tiết kiệm nhiên liệu. Phù hợp cho việc di chuyển trong thành phố.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762582737/main-vision-tt-xam_ljmisd.jpg"
                },
                new Motorbike
                {
                    Name = "Honda Vision 2025",
                    Type = "Tay ga",
                    Brand = "Honda",
                    Year = 2025,
                    PlateNumber = "43A-11112",
                    Condition = MotorbikeCondition.New,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 40000,
                    PricePerDay = 140000,
                    Location = "Hải Châu, Đà Nẵng",
                    Description = "Xe mới 100%, động cơ êm ái, tiết kiệm nhiên liệu. Phù hợp cho việc di chuyển trong thành phố.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762583042/honda-vision2025-cao-cap-do-den_zyowip.png"
                },
                new Motorbike
                {
                    Name = "Honda Vision 2025",
                    Type = "Tay ga",
                    Brand = "Honda",
                    Year = 2025,
                    PlateNumber = "43A-11113",
                    Condition = MotorbikeCondition.New,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 40000,
                    PricePerDay = 140000,
                    Location = "Hải Châu, Đà Nẵng",
                    Description = "Xe mới 100%, động cơ êm ái, tiết kiệm nhiên liệu. Phù hợp cho việc di chuyển trong thành phố.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762583041/scv-grey-2-front-right-360-17321662006091361119024_bkfkso.webp"
                },
                new Motorbike
                {
                    Name = "Yamaha Exciter 2023",
                    Type = "Xe số",
                    Brand = "Yamaha",
                    Year = 2023,
                    PlateNumber = "43A-11114",
                    Condition = MotorbikeCondition.Good,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 35000,
                    PricePerDay = 135000,
                    Location = "Thanh Khê, Đà Nẵng",
                    Description = "Xe số thể thao, động cơ mạnh mẽ, phù hợp cho những ai yêu thích tốc độ.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762584068/exciter_155_vva_dark_red_smk_002.png_qwviuc.webp"
                },
                new Motorbike
                {
                    Name = "Yamaha NMax 2024",
                    Type = "Xe số",
                    Brand = "Yamaha",
                    Year = 2023,
                    PlateNumber = "43A-11115",
                    Condition = MotorbikeCondition.Good,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 35000,
                    PricePerDay = 135000,
                    Location = "Thanh Khê, Đà Nẵng",
                    Description = "Xe số thể thao, động cơ mạnh mẽ, phù hợp cho những ai yêu thích tốc độ.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762584143/yamaha-exciter-155-vva-1-123127_leznty.jpg"
                },
                new Motorbike
                {
                    Name = "SYM Elite 2023",
                    Type = "Tay ga",
                    Brand = "SYM",
                    Year = 2023,
                    PlateNumber = "43A-11116",
                    Condition = MotorbikeCondition.Good,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 40000,
                    PricePerDay = 140000,
                    Location = "Hải Châu, Đà Nẵng",
                    Description = "Xe tay ga thân thiện với môi trường, thiết kế hiện đại, giá cả phải chăng.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762584928/063adfb2ee84c07e4be850b4c60096fd-2921584872041764397_gf8f1o.jpg"
                },
                new Motorbike
                {
                    Name = "Vinfast Evo 200",
                    Type = "Xe điện",
                    Brand = "Vinfast",
                    Year = 2024,
                    PlateNumber = "43A-11117",
                    Condition = MotorbikeCondition.Good,
                    Status = MotorbikeStatus.Available,
                    PricePerHour = 45000,
                    PricePerDay = 145000,
                    Location = "Hải Châu, Đà Nẵng",
                    Description = "Xe điện thân thiện với môi trường, thiết kế hiện đại, giá cả phải chăng.",
                    ImageUrl = "https://res.cloudinary.com/dmbjv3e5f/image/upload/v1762585193/xe-may-dien-vinfast-evo-200-trang_pond8e.webp"
                }
            };
            await context.Motorbikes.AddRangeAsync(motorbikes);
            await context.SaveChangesAsync();
        }
    }
}