using DataAccess;
using HOC_VIEN.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HocVienApp.VIEW
{
    public partial class hocVienForm : Form
    {
        private HOCVIEN hocVien;
        private HocVienBLL hocVienBLL = new HocVienBLL();
        public hocVienForm(HOCVIEN HV)
        {
            InitializeComponent();
            this.hocVien = HV;
            LoadInforHV();
        }
        public void LoadInforHV()
        {
            lblhoten.Text = hocVien.HoTen;
            lblusername.Text = hocVien.UserID;
            lblgender.Text = hocVien.Gender.GetValueOrDefault() ? "Nam" : "Nữ";
            lblNS.Text = hocVien.NgaySinh.HasValue ? hocVien.NgaySinh.Value.ToString("dd/MM/yyyy") : "N/A";
            lblSDT.Text = hocVien.SDT;
            var goiTap = hocVienBLL.GetGoiTapByID(hocVien.GoTapID ?? 0);
            if (hocVien.GoTapID > 0)
            {

                lblGT.Text = goiTap?.TenGoTap ?? "Chưa đăng ký";
                lblNDK.Text = hocVien.NgayBatDau.HasValue ? hocVien.NgayBatDau.Value.ToString("dd/MM/yyyy") : "N/A";
                lblNHH.Text = hocVien.NgayHetHan.HasValue ? hocVien.NgayHetHan.Value.ToString("dd/MM/yyyy") : "N/A";
            }
            else
            {
                lblGT.Text = "Chưa đăng ký";
                lblNDK.Text = "N/A";
                lblNHH.Text = "N/A";
            }

            if (hocVien.IsPaid.GetValueOrDefault() && goiTap?.TenGoTap != null)
            {
                lblThanhToan.Text = "Đã thanh toán";
                lblThanhToan.ForeColor = Color.Blue;
            }
            else
            {
                lblThanhToan.Text = "Chưa thanh toán";
                lblThanhToan.ForeColor = Color.Red;
            }


            if (hocVien.IsPaid.GetValueOrDefault() && hocVien.IsRegistered.GetValueOrDefault())
            {
                lblthanhtoanPT.Text = "Đã thanh toán";
                lblthanhtoanPT.ForeColor = Color.Blue;
            }
            else
            {
                lblthanhtoanPT.Text = "Chưa thanh toán";
                lblthanhtoanPT.ForeColor = Color.Red;
            }
            //var lichHoc = lichHocBLL.GetLichHocByHocVienID(hocVien.HocVienID);
            //LichHocHV_View firstLichHoc = lichHoc.FirstOrDefault();

            //if (firstLichHoc != null)
            //{
            //    lblBD.Text = firstLichHoc.NgayDangKy.HasValue ? firstLichHoc.NgayDangKy.Value.ToString("dd/MM/yyyy") : "N/A";
            //    DateTime? ngayKetThuc = firstLichHoc.NgayDangKy?.AddMonths(1);
            //    lblKT.Text = ngayKetThuc.HasValue ? ngayKetThuc.Value.ToString("dd/MM/yyyy") : "N/A";
            //}
            //else
            //{
            //    lblBD.Text = "N/A";
            //    lblKT.Text = "N/A";
            //}
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
