﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranThiThanhTam
{
    // Xây dựng ứng dụng dạng Console Application cho phép người dùng quản lý, ghi chú các việc cần làm với một số yêu cầu như sau

    // Xây dựng lớp việc cần làm với các thông tin sau
    class ViecCanLam
    {
        // 1. Tên việc cần làm.
        public string TenViecLam { get; set; } 

        // 2. Độ ưu tiên (Điểm số 1 đến 5 với 1 là ít ưu tiên nhất).
        public int MucDoUuTien { get; set; }

        // 3. Mô tả thông tin việc cần làm.
        public string ThongTin { get; set; }

        // 4. Trạng thái của việc cần làm.
        public string TrangThai { get; set; }
    }

    class QuanLyViecCanLam
    {
        private List<ViecCanLam> ListViecCanLam = null;

        public QuanLyViecCanLam()
        {
            ListViecCanLam = new List<ViecCanLam>();
        }

        public int SoLuongViecCanLam()
        {
            int Count = 0;
            if (ListViecCanLam != null)
            {
                Count = ListViecCanLam.Count;
            }
            return Count;
        }

        // Khai bao viec can lam
        public void KhaiBaoViecCanLam()
        {
            ViecCanLam vcl = new ViecCanLam();

            Console.Write("Khai bao ten viec can lam: ");
            vcl.TenViecLam = Convert.ToString(Console.ReadLine());

            Console.Write("Khai bao muc do uu tien cua viec can lam (tu 1 den 5): ");
            vcl.MucDoUuTien = Convert.ToInt32(Console.ReadLine());

            Console.Write("Khai bao thong tin ve viec can lam: ");
            vcl.ThongTin = Convert.ToString(Console.ReadLine());

            Console.Write("Trang thai cua viec can lam: ");
            vcl.TrangThai = Convert.ToString(Console.ReadLine());

            ListViecCanLam.Add(vcl);

        }

        // Tim viec can lam dua vao index
        public ViecCanLam TimVclDuaVaoViTri(int viTri)
        {
            ViecCanLam ketQua = null;
            if (ListViecCanLam != null && ListViecCanLam.Count > 0 && viTri <= SoLuongViecCanLam())
            {
                ketQua = ListViecCanLam.ElementAt(viTri);
            }
            return ketQua;
        }


        // Xoa thong tin viec can lam dua vao index - vi tri
        public bool XoaVclDuaVaoViTri(int viTri)
        {
            bool IsDeleted = false;
            // tìm kiếm sinh viên theo ID
            ViecCanLam vcl = TimVclDuaVaoViTri(viTri);
            if (vcl != null)
            {
                ListViecCanLam.RemoveAt(viTri);
                IsDeleted = true;
            }
            return IsDeleted;
        }

        // Tim viec can lam dua vao ten
        public ViecCanLam TimVclDuaVaoTen(String keyword)
        {
            ViecCanLam ketQua = null;
            if (ListViecCanLam != null && ListViecCanLam.Count > 0)
            {
                foreach (ViecCanLam vcl in ListViecCanLam)
                {
                    if (vcl.TenViecLam.ToUpper().Contains(keyword.ToUpper()))
                    {
                        ketQua = vcl;
                    }
                }
            }
            return ketQua;
        }

        // Cap nhat trang thai cua viec can lam
        public void CapNhatTrangThaiVcl(String keyword)
        {
            ViecCanLam vcl = TimVclDuaVaoTen(keyword);

            if (vcl != null)
            {
                Console.Write("Nhap trang thai moi cua viec can lam: ");
                string trangThaiMoi = Convert.ToString(Console.ReadLine());
                
                if (trangThaiMoi != null && trangThaiMoi.Length > 0)
                {
                    vcl.TrangThai = trangThaiMoi;
                }
            }
        }

        // Tim viec can lam dua vao muc do uu tien
        public List<ViecCanLam> TimVclDuaVaoMucDoUuTien(int mucDo)
        {
            List<ViecCanLam> ketQua = new List<ViecCanLam>();
            if (ListViecCanLam != null && ListViecCanLam.Count > 0)
            {
                foreach (ViecCanLam vcl in ListViecCanLam)
                {
                    if (vcl.MucDoUuTien == mucDo)
                    {
                        ketQua.Add(vcl);
                    }
                }
            }
            return ketQua;
        }

        // Sap xep danh sach viec can lam theo muc do uu tien giam dan
        public List<ViecCanLam> XepTheoMucDoUuTienGiamDan()
        {
            //ListSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2) {
            //    return sv1.DiemTB.CompareTo(sv2.DiemTB);
            //});

            return ListViecCanLam.OrderByDescending(o => o.MucDoUuTien).ToList();

        }

        // Truy xuat danh sach viec can lam hien tai
        public List<ViecCanLam> getListViecCanLam()
        {
            return ListViecCanLam;
        }

        // Hien thi danh sach viec can lam
        public void HienThiDanhSachVcl(List<ViecCanLam> dsViecCanLam)
        {
            // hien thi tieu de cot
            Console.WriteLine("Danh sach viec can lam");
            // hien thi danh sach viec can lam
            if (dsViecCanLam != null && dsViecCanLam.Count > 0)
            {
                foreach (ViecCanLam vcl in dsViecCanLam)
                {
                    Console.WriteLine("Viec lam: {0}; Muc do uu tien: {1}, Thong tin: {2}, Trang thai: {3}",
                                      vcl.TenViecLam, vcl.MucDoUuTien, vcl.ThongTin, vcl.TrangThai);
                }
            }
            Console.WriteLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLyViecCanLam quanLyViecCanLam = new QuanLyViecCanLam();

            // 1. Cho phép khai báo thông tin các việc cần làm.

            // 2. Cho phép xóa thông tin việc cần làm dựa vào vị trí.

            // 3. Cho phép cập nhật trạng thái dựa vào tên việc cần làm.

            // 4. Hỗ trợ tìm kiếm việc cần dựa vào tên hoặc độ ưu tiên.

            // 5. Hiển thị danh sách các việc cần làm theo độ ưu tiên giảm dần.

            // 6. Hiển thị toàn bộ danh sách việc cần làm mà người dùng đã khai báo.

            while (true)
            {
                Console.WriteLine("\nUNG DUNG QUAN LY VIEC CAN LAM C#");
                Console.WriteLine("*************************MENU**************************************************");
                Console.WriteLine("**  1. Khai bao thong tin cac viec can lam.                                  **");
                Console.WriteLine("**  2. Xoa thong tin viec can lam dua vao vi tri.                            **");
                Console.WriteLine("**  3. Cap nhat trang thai viec can lam dua vao ten viec can lam.            **");
                Console.WriteLine("**  4. Ho tro tim kiem viec can lam dua vao muc do uu tien.                  **");
                Console.WriteLine("**  5. Hien thi danh sach cac viec can lam dua theo do uu tien giam dan.    **");
                Console.WriteLine("**  6. Hien thi toan bo danh sach viec can lam ma nguoi dung da khai bao.    **");
                Console.WriteLine("**  0. Thoat                                                                 **");
                Console.WriteLine("*******************************************************************************");
                
                Console.Write("Nhap tuy chon: ");

                int key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Khai bao thong tin cac viec can lam.");
                        quanLyViecCanLam.KhaiBaoViecCanLam();
                        Console.WriteLine("\nThem viec can lam thanh cong!");
                        break;
                    case 2:
                        if (quanLyViecCanLam.SoLuongViecCanLam() > 0)
                        {
                            int viTri;
                            Console.WriteLine("\n2. Xoa thong tin viec can lam dua vao vi tri.");
                            Console.Write("\nNhap vi tri (thu tu): ");
                            viTri = Convert.ToInt32(Console.ReadLine());
                            if (quanLyViecCanLam.XoaVclDuaVaoViTri(viTri))
                            {
                                Console.WriteLine("\nViec can lam co vi tri - thu tu = {0} da bi xoa.", viTri);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach viec can lam rong!");
                        }
                        break;
                    case 3:
                        if (quanLyViecCanLam.SoLuongViecCanLam() > 0)
                        {
                            string viecCanLam;
                            Console.WriteLine("\n3. Cap nhat trang thai dua vao ten viec can lam. ");
                            Console.Write("\nNhap ten viec can lam: ");
                            viecCanLam = Convert.ToString(Console.ReadLine());
                            quanLyViecCanLam.CapNhatTrangThaiVcl(viecCanLam);
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach viec can lam rong!");
                        }
                        break;
                    case 4:
                        if (quanLyViecCanLam.SoLuongViecCanLam() > 0)
                        {
                            Console.WriteLine("\n4.  Ho tro tim kiem viec can lam dua vao muc do uu tien.");
                            Console.Write("\nNhap muc do uu tien de tim kiem: ");
                            int mucDoUuTien = Convert.ToInt32(Console.ReadLine());
                            List<ViecCanLam> ketQua = quanLyViecCanLam.TimVclDuaVaoMucDoUuTien(mucDoUuTien);
                            quanLyViecCanLam.HienThiDanhSachVcl(ketQua);
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach viec can lam rong!");
                        }
                        break;
                    case 5:
                        if (quanLyViecCanLam.SoLuongViecCanLam() > 0)
                        {
                            Console.WriteLine("\n5. Hien thi danh sach viec can lam theo do uu tien giam dan.");
                            List<ViecCanLam> ketQua = quanLyViecCanLam.XepTheoMucDoUuTienGiamDan();
                            quanLyViecCanLam.HienThiDanhSachVcl(ketQua);
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach sinh vien trong!");
                        }
                        break;
                    case 6:
                        if (quanLyViecCanLam.SoLuongViecCanLam() > 0)
                        {
                            Console.WriteLine("\n6. Hien thi toan bo danh sach viec can lam ma nguoi dung da khai bao");
                            quanLyViecCanLam.HienThiDanhSachVcl(quanLyViecCanLam.getListViecCanLam());
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach sinh vien rong!");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nBan da chon thoat khoi ung dung!");
                        return;
                    default:
                        Console.WriteLine("\nKhong co chuc nang nay!");
                        Console.WriteLine("\nHay chon chuc nang trong hop menu.");
                        break;
                }
            }
        }
    }
}
