using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
 

    class NganHang
    {
        private List<TaiKhoan> danhSachTaiKhoan;

        public NganHang()
        {
            danhSachTaiKhoan = new List<TaiKhoan>();
        }

        public TaiKhoan MoTaiKhoan(string soTaiKhoan, string tenChuSoHuu, string cmnd)
        {
            TaiKhoan taiKhoan = new TaiKhoan(soTaiKhoan, tenChuSoHuu, cmnd);
            danhSachTaiKhoan.Add(taiKhoan);
            return taiKhoan;
        }

        public List<TaiKhoan> LayDanhSachTaiKhoan()
        {
            return danhSachTaiKhoan;
        }
    }

    class TaiKhoan
    {
        public string SoTaiKhoan { get; }
        public string TenChuSoHuu { get; }
        public string CMND { get; }
        public decimal SoDu { get; private set; }

        private List<GiaoDich> danhSachGiaoDich;

        public TaiKhoan(string soTaiKhoan, string tenChuSoHuu, string cmnd)
        {
            SoTaiKhoan = soTaiKhoan;
            TenChuSoHuu = tenChuSoHuu;
            CMND = cmnd;
            SoDu = 0;
            danhSachGiaoDich = new List<GiaoDich>();
        }

        public void NapTien(decimal soTien)
        {
            if (soTien > 0)
            {
                SoDu += soTien;
                GiaoDich giaoDich = new GiaoDich(DateTime.Now, GiaoDich.LoaiGiaoDich.NapTien, soTien);
                danhSachGiaoDich.Add(giaoDich);
                Console.WriteLine("Nạp tiền thành công. Số dư mới: " + SoDu);
            }
            else
            {
                Console.WriteLine("Số tiền nạp vào phải lớn hơn 0.");
            }
        }

        public void RutTien(decimal soTien)
        {
            if (soTien > 0 && SoDu >= soTien)
            {
                SoDu -= soTien;
                GiaoDich giaoDich = new GiaoDich(DateTime.Now, GiaoDich.LoaiGiaoDich.RutTien, soTien);
                danhSachGiaoDich.Add(giaoDich);
                Console.WriteLine("Rút tiền thành công. Số dư mới: " + SoDu);
            }
            else
            {
                Console.WriteLine("Số tiền rút không hợp lệ hoặc không đủ số dư.");
            }
        }

        public void InThongTinTaiKhoan()
        {
            Console.WriteLine("Số tài khoản: " + SoTaiKhoan);
            Console.WriteLine("Tên chủ sở hữu: " + TenChuSoHuu);
            Console.WriteLine("Số dư: " + SoDu);
            Console.WriteLine("-------------------------");
        }
    }

    class GiaoDich
    {
        public enum LoaiGiaoDich
        {
            NapTien,
            RutTien
        }

        public DateTime ThoiGian { get; }
        public LoaiGiaoDich Loai { get; }
        public decimal SoTien { get; }

        public GiaoDich(DateTime thoiGian, LoaiGiaoDich loai, decimal soTien)
        {
            ThoiGian = thoiGian;
            Loai = loai;
            SoTien = soTien;
        }
    }

    class BaoCaoNganHang
    {
        private NganHang nganHang;

        public BaoCaoNganHang(NganHang nganHang)
        {
            this.nganHang = nganHang;
        }

        public void TaoBaoCao()
        {
            List<TaiKhoan> danhSachTaiKhoan = nganHang.LayDanhSachTaiKhoan();

            foreach (TaiKhoan taiKhoan in danhSachTaiKhoan)
            {
                taiKhoan.InThongTinTaiKhoan();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NganHang nganHang = new NganHang();

            // Mở tài khoản
            TaiKhoan taiKhoan1 = nganHang.MoTaiKhoan("123456789", "Nguyen Van A", "0123456789");
            TaiKhoan taiKhoan2 = nganHang.MoTaiKhoan("987654321", "Nguyen Thi B", "9876543210");

            // Nạp tiền
            taiKhoan1.NapTien(1000000);
            taiKhoan2.NapTien(5000000);

            // Rút tiền
            taiKhoan1.RutTien(500000);
            taiKhoan2.RutTien(2000000);

            // Tạo báo cáo
            BaoCaoNganHang baoCao = new BaoCaoNganHang(nganHang);
            baoCao.TaoBaoCao();

            Console.ReadLine();
        }
    }
}
