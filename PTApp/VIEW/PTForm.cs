using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTApp.VIEW
{
    public partial class PTForm : Form
    {
        private PT pt=new PT();
        public PTForm(PT pt)
        {
            InitializeComponent();
            this.pt = pt;
            LoadTTPT();
        }
        //private void LoadLichHoc()
        //{

        //    var lichHocList = lichHocBLL.GetAllLichPTByPTID(pt.PTID);


        //    dataGridView1.DataSource = lichHocList.Select(lh => new
        //    {
        //        lh.HoTenPT,
        //        lh.ThuHoc,
        //        lh.BuoiHoc,
        //        lh.SoLuongHocVien,
        //        lh.GioHoc
        //    }).ToList();
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dataGridView1.Columns["HoTenPT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView1.Columns["ThuHoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView1.Columns["BuoiHoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView1.Columns["SoLuongHocVien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView1.Columns["GioHoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView1.RowTemplate.Height = 30;
        //}

        void LoadTTPT()
        {
            lblhoten.Text = pt.HoTen;
            lblusername.Text = pt.UserID;
            lblgender.Text = pt.Gender.GetValueOrDefault() ? "Nam" : "Nữ";
            lblNS.Text = pt.NgaySinh.HasValue ? pt.NgaySinh.Value.ToString("dd/MM/yyyy") : "N/A";
            lblSDT.Text = pt.SDT;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
