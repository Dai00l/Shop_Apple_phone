using DienthoaiApple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DienthoaiApple.Controllers
{
    public class DienthoaiController : Controller
    {
        // GET: Dienthoai
        // Khai bao bien Data do du lieu vao models
        DataCuahangdienthoaiDataContext data = new DataCuahangdienthoaiDataContext();
        // lay danh sach tat ca dien thoai tu Data
        public ActionResult ListDienthoai()
        {
            var all_dienthoai = from ss in data.Dienthoais select ss;
            return View(all_dienthoai);
        }
        public ActionResult Detail(int id)
        {
            var D_Dienthoai = data.Dienthoais.Where(m => m.madt == id).First();
            return View(D_Dienthoai);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var E_Dienthoai = data.Dienthoais.First(m => m.madt == id);
            return View(E_Dienthoai);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)

        {
            var E_Dienthoai = data.Dienthoais.First(m => m.madt == id);
            var E_tendienthoai = collection["tendt"];
            var E_hinh = collection["hinhdt"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_Dienthoai.madt = id;
            if (string.IsNullOrEmpty(E_tendienthoai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Dienthoai.tendt = E_tendienthoai;
                E_Dienthoai.hinhdt = E_hinh;
                E_Dienthoai.giaban = E_giaban;
                E_Dienthoai.ngaycapnhat = E_ngaycapnhat;
                E_Dienthoai.soluongton = E_soluongton;
                UpdateModel(E_Dienthoai);
                data.SubmitChanges();
                return RedirectToAction("ListDienthoai");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(int id)
        {
            var D_Dienthoai = data.Dienthoais.First(m => m.madt == id);
            return View(D_Dienthoai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_Dienthoai = data.Dienthoais.Where(m => m.madt == id).First();
            data.Dienthoais.DeleteOnSubmit(D_Dienthoai);
            data.SubmitChanges();
            return RedirectToAction("ListDienthoai");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Img/" + file.FileName));
            return "/Content/Img/" + file.FileName;
        }

    }
}