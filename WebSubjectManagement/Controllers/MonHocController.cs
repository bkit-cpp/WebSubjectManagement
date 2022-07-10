using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSubjectManagement.Models;

namespace WebSubjectManagement.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHoc
        public ActionResult Index(string strSearch)
        {
            ListMonHoc dsmonhoc = new ListMonHoc();
            List<MonHoc> obj = dsmonhoc.getds(string.Empty).OrderBy(x => x.TenMH).ToList();
            if(!String.IsNullOrEmpty(strSearch))
            {
                obj = obj.Where(x => x.TenMH.Contains(strSearch)).ToList();
            }
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MonHoc mh)
        {
            if (ModelState.IsValid)
            {
                ListMonHoc dsmonhoc = new ListMonHoc();
                dsmonhoc.InsertMH(mh);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id="")
        {
            ListMonHoc dsmonhoc = new ListMonHoc();
            List<MonHoc> obj = dsmonhoc.getds(id);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(MonHoc mh)
        {
           
                ListMonHoc dsmonhoc = new ListMonHoc();
                dsmonhoc.EditMH(mh);
                return RedirectToAction("Index");

        }
        public ActionResult Details(string id="")
        {
            ListMonHoc dsmonhoc = new ListMonHoc();
            List<MonHoc> obj = dsmonhoc.getds(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id="")
        {
           
            ListMonHoc dsmonhoc = new ListMonHoc();
            List<MonHoc> obj = dsmonhoc.getds(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(MonHoc mh)
        {
           
                ListMonHoc dsmonhoc = new ListMonHoc();
                dsmonhoc.DeleteMH(mh);
                return RedirectToAction("Index");
            
        }
    }
}