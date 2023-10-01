using System;
using System.Collections.Generic;
using System.Text;

public class NhanVien
{
    public string Ten { get; set; }
    // Các thuộc tính khác của nhân viên
}

public class MatHang
{
    public string Ten { get; set; }
    public double Gia { get; set; }
    public double GiamGia { get; set; }

    public MatHang(string ten, double gia, double giamGia)
    {
        Ten = ten;
        Gia = gia;
        GiamGia = giamGia;
    }

    public double LayGia()
    {
        return Gia;
    }

    public double LayGiamGia()
    {
        return GiamGia;
    }
}

public class DongHoaDon
{
    public int SoLuong { get; set; }
    public MatHang MatHang { get; set; }
}

public class HoaDonTienMat
{
    private List<DongHoaDon> danhSachDongHoaDon;
    private NhanVien nhanVien;

    public HoaDonTienMat(NhanVien nhanVien)
    {
        this.nhanVien = nhanVien;
        danhSachDongHoaDon = new List<DongHoaDon>();
    }

    public void Them(DongHoaDon dongHoaDon)
    {
        danhSachDongHoaDon.Add(dongHoaDon);
    }

    public double TinhTongTien()
    {
        double tongTien = 0;
        foreach (var dongHoaDon in danhSachDongHoaDon)
        {
            tongTien += dongHoaDon.SoLuong * dongHoaDon.MatHang.LayGia();
        }
        return tongTien;
    }

    public void InHoaDon()
    {
        Console.WriteLine("Hóa đơn:");
        foreach (var dongHoaDon in danhSachDongHoaDon)
        {
            Console.WriteLine($"{dongHoaDon.MatHang.Ten} - Số lượng: {dongHoaDon.SoLuong}, Giá: {dongHoaDon.MatHang.LayGia()}");
        }
        Console.ReadLine();
    }
}

public class ChuongTrinhDemo
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding= UTF8Encoding.UTF8;
        // Tạo nhân viên
        NhanVien nhanVien = new NhanVien { Ten = "Nguyen Van A" };

        // Tạo mặt hàng
        MatHang matHang = new MatHang("Kẹo", 1.35, 0.25);

        // Tạo đơn hàng
        DongHoaDon dongHoaDon = new DongHoaDon { SoLuong = 3, MatHang = matHang };

        // Tạo hóa đơn tiền mặt
        HoaDonTienMat hoaDon = new HoaDonTienMat(nhanVien);
        hoaDon.Them(dongHoaDon);

        // Tính và in tổng tiền
        Console.WriteLine("Tổng tiền: " + hoaDon.TinhTongTien());
        hoaDon.InHoaDon();
    }
}
