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
    public partial class DoiTTHVForm : Form
    {
        private string userRole;
        private HOCVIEN hocVien;
        private HocVienBLL hocVienBLL = new HocVienBLL();
        public DoiTTHVForm()
        {
            InitializeComponent();
        }

        public void LoadData(object user, string role)
        {
            hocVien = (HOCVIEN)user;
            txtRole.Text = role;
            txtRole.ReadOnly = true;
            txtuserid.Text = hocVien.UserID;
            txtHoten.Text = hocVien.HoTen;
            txtSDT.Text = hocVien.SDT;
            dateTimePicker1.Value = hocVien.NgaySinh ?? DateTime.Now;
            radioButton1.Checked = hocVien.Gender.GetValueOrDefault();
            radioButton2.Checked = !hocVien.Gender.GetValueOrDefault();
            
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string userid = txtuserid.Text.Trim();
            string fullName = txtHoten.Text.Trim();
            string phone = txtSDT.Text.Trim();
            DateTime dob = dateTimePicker1.Value;
            bool gender = radioButton1.Checked;
            hocVien.UserID = userid;
            hocVien.HoTen = fullName;
            hocVien.SDT = phone;
            hocVien.NgaySinh = dob;
            hocVien.Gender = gender;
            hocVienBLL.UpdateHocVien(hocVien);
            MessageBox.Show("Cập nhật thông tin học viên thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
