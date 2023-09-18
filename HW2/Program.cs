using System;

class Nguoi
{
    private string ten;
    private string diaChi;
    private double luong;

    public Nguoi(string ten, string diaChi, double luong)
    {
        this.ten = ten;
        this.diaChi = diaChi;
        this.luong = luong;
    }

    public string LayTen()
    {
        return ten;
    }

    public void DatTen(string ten)
    {
        this.ten = ten;
    }

    public string LayDiaChi()
    {
        return diaChi;
    }

    public void DatDiaChi(string diaChi)
    {
        this.diaChi = diaChi;
    }

    public double LayLuong()
    {
        return luong;
    }

    public void DatLuong(double luong)
    {
        this.luong = luong;
    }

    public static Nguoi NhapThongTinNguoi(string ten, string diaChi, string sLuong)
    {
        double luong;
        if (!double.TryParse(sLuong, out luong) || luong < 0)
        {
            throw new Exception("Lương phải là một số dương.");
        }
        return new Nguoi(ten, diaChi, luong);
    }

    public static void HienThiThongTinNguoi(Nguoi nguoi)
    {
        Console.WriteLine("Họ và tên: " + nguoi.LayTen());
        Console.WriteLine("Địa chỉ: " + nguoi.LayDiaChi());
        Console.WriteLine("Lương: $" + nguoi.LayLuong());
    }

    public static Nguoi[] SapXepTheoLuong(Nguoi[] danhSachNguoi)
    {
        if (danhSachNguoi == null)
        {
            throw new Exception("Không thể sắp xếp mảng null.");
        }

        Nguoi[] danhSachDaSapXep = (Nguoi[])danhSachNguoi.Clone();

        for (int i = 0; i < danhSachDaSapXep.Length - 1; i++)
        {
            for (int j = 0; j < danhSachDaSapXep.Length - i - 1; j++)
            {
                if (danhSachDaSapXep[j].LayLuong() > danhSachDaSapXep[j + 1].LayLuong())
                {
                    // Hoán đổi
                    Nguoi temp = danhSachDaSapXep[j];
                    danhSachDaSapXep[j] = danhSachDaSapXep[j + 1];
                    danhSachDaSapXep[j + 1] = temp;
                }
            }
        }

        return danhSachDaSapXep;
    }
}

class ChuongTrinhChinh
{
    static void Main(string[] args)
    {
        try
        {
            Nguoi[] danhSachNguoi = new Nguoi[3];

            for (int i = 0; i < 3; i++)
            {
                // Nhập thông tin người
                danhSachNguoi[i] = Nguoi.NhapThongTinNguoi("Người " + (i + 1), "Địa chỉ " + (i + 1), "5000");
            }

            // Hiển thị thông tin người
            foreach (var nguoi in danhSachNguoi)
            {
                Nguoi.HienThiThongTinNguoi(nguoi);
            }

            // Sắp xếp theo lương
            Nguoi[] danhSachDaSapXep = Nguoi.SapXepTheoLuong(danhSachNguoi);

            // Hiển thị thông tin người đã sắp xếp
            foreach (var nguoi in danhSachDaSapXep)
            {
                Nguoi.HienThiThongTinNguoi(nguoi);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Đã xảy ra lỗi: " + e.Message);
        }
    }
}
