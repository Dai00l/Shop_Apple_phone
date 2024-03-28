using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DienthoaiApple.Models
{
    public class GioHang
    {
        DataCuahangdienthoaiDataContext data = new DataCuahangdienthoaiDataContext();
        public int madt { get; set; }
        [Display(Name = "Mã điện thoại")]
        public string tendt { get; set; }
        [Display(Name = "Tên điện thoại")]
        public string hinhdt { get; set; }

        [Display(Name = "Giá Bán")]
        public double giaban { get; set; }
        [Display(Name = "Số Lượng")]
        public int iSoluong { get; set; }
        [Display(Name = "Thành Tiền")]
        public double dThanhtien
        {
            get { return iSoluong * giaban; }
        }
        public GioHang(int id)
        {
            madt = id;
            Dienthoai dienthoai = data.Dienthoais.Single(n => n.madt == madt);
            tendt = dienthoai.tendt;
            hinhdt = dienthoai.hinhdt;
            giaban = double.Parse(dienthoai.giaban.ToString());
            iSoluong = 1;
        }
    }
}