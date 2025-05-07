using DataAccess;
using HOC_VIEN.DAL;
using HocVienApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HOC_VIEN.BLL
{
    public class HocVienBLL
    {
        private readonly HocVienDAL _hocVienDAL = new HocVienDAL();
        private string GetGioHoc(string buoiHoc)
        {
            switch (buoiHoc)
            {
                case "Sáng":
                    return "07:00";
                case "Chiều":
                    return "14:00";
                case "Tối":
                    return "19:00";
                default:
                    return "N/A";
            }
        }

        public void UpdateHocVien(HOCVIEN hocVien)
        {
            _hocVienDAL.UpdateHV(hocVien);  
        }

        public void AddHocVien(HOCVIEN hocVien) => _hocVienDAL.InsertHocVien(hocVien);

        public HOCVIEN GetHocVienByUserID(string userID) => _hocVienDAL.GetHocVienByUserID(userID);

        public List<HOCVIEN> GetHocVienList() => _hocVienDAL.GetHocVienList();

        public List<HOCVIEN> SearchHocVien(string keyword) => _hocVienDAL.SearchHocVien(keyword);

        public void DeleteHocVienAndAccount(string userID) => _hocVienDAL.DeleteHocVienAndAccount(userID);

        public List<HOCVIEN> GetHocVienByPaymentStatus(bool isPaid) => _hocVienDAL.GetHocVienByPaymentStatus(isPaid);

        public HOCVIEN GetHocVienByID(int hocVienID) => _hocVienDAL.GetHocVienByID(hocVienID);

        public void RegisterGoiTap(int hocVienID, int goTapID, DateTime ngayDangKy, DateTime ngayHetHan)
        {
            var hocVien = _hocVienDAL.GetHocVienByID(hocVienID);  
            if (hocVien != null)
            {
                hocVien.GoTapID = goTapID;
                hocVien.NgayBatDau = ngayDangKy;
                hocVien.NgayHetHan = ngayHetHan;
                 _hocVienDAL.UpdateRegisterHocVien(hocVien);  
            }
            else
            {
                throw new Exception("Học viên không tồn tại.");
            }
        }

        public List<LichHocHV_View> GetLichHocByHocVienID(int hocVienID)
        {
            String Giohoc;
            var lichHocs = _hocVienDAL.GetLichHocByHocVienID(hocVienID);

            var lichHocViews = lichHocs.Select(lh => new LichHocHV_View(
                lh.HOCVIEN.HoTen,
                lh.PT.HoTen,
                lh.ThuHoc,
                lh.BuoiHoc,
                lh.NgayDangKy ?? DateTime.MinValue,
                Giohoc = GetGioHoc(lh.BuoiHoc)

            )).ToList();

            return lichHocViews;
        }

        public GOITAP GetGoiTapByID(int goTapID)
        {
            return _hocVienDAL.GetGoiTapByID(goTapID);
        }

        public USER GetUserByHocVienID(int hocVienID)
        {
            return _hocVienDAL.GetUserByHocVienID(hocVienID);
        }
        public void UpdateHocVienStatus(HOCVIEN hocVien)
        {
            _hocVienDAL.UpdateHocVienStatus(hocVien);
        }

        public void UpdateIsPaid(int hocVienID)
        {
            _hocVienDAL.UpdateIsPaid(hocVienID);
        }
        public bool ChangePassword(string userID, string newPassword)
        {

            return _hocVienDAL.ChangePassword(userID, newPassword);
        }

        public List<Cbb_Item_GT> GetAllGoiTapForComboBox()
        {
            var goiTaps = _hocVienDAL.GetAll();
            List<Cbb_Item_GT> cbbItems = new List<Cbb_Item_GT>();

            foreach (var gt in goiTaps)
            {
                cbbItems.Add(new Cbb_Item_GT(gt.GoTapID, gt.TenGoTap, gt.Gia, gt.ThoiLuong));
            }

            return cbbItems;
        }

        public List<PT_View_DK> GetAllPT()
        {
            var ptList = _hocVienDAL.GetAllPT();
            var ptViewList = ptList.Select(pt => new PT_View_DK(
                pt.PTID,
                pt.HoTen,
                pt.SDT,
                pt.NgaySinh,
                pt.Gender.GetValueOrDefault() ? "Nam" : "Nữ",
                pt.UserID
            )).ToList();

            return ptViewList;
        }

        public void SaveLichHocToDatabase(List<LICH_HOC> lichHocList)
        {
            if (lichHocList != null && lichHocList.Count > 0)
            {
                _hocVienDAL.SaveLichHoc(lichHocList);
            }
            else
            {
                throw new Exception("Danh sách lịch học rỗng.");
            }
        }
    }
}
