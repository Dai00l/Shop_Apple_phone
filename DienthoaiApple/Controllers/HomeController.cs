using DienthoaiApple.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DienthoaiApple.Controllers
{
    public class HomeController : Controller
    {
        DataCuahangdienthoaiDataContext data = new DataCuahangdienthoaiDataContext();
        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            var all_dienthoai =( from s in data.Dienthoais select s).OrderBy(m => m.madt);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_dienthoai.ToPagedList(pageNum, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}