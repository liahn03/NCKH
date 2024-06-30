using DocumentSharing.DAL;
using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DocumentSharing.Controllers
{
    public class DocumentController : Controller
    {
        DocumentDAO docDAO = new DocumentDAO();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocumentList(int pageNumber = 1)
        {
            DataTable dt = docDAO.GetDocument(pageNumber);
            List<Models.Document> listDoc = new List<Models.Document>();
            listDoc = JsonConvert.DeserializeObject<List<Models.Document>>(JsonConvert.SerializeObject(dt));
            int totalRow = docDAO.RowCountDocument();
            int totalPage = (int)Math.Ceiling((decimal)totalRow / 5);
            ViewBag.TotalPage = totalPage;
            ViewBag.PageActive = pageNumber;
            ViewBag.Delete = TempData["delete"];
            return View(listDoc);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Document doc)
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string id, int pageNumber)
        {
            int result = docDAO.DeleteDoc(id);
            //if(result > 0)
            //{
            //    TempData["delete"] = "true";
            //    return RedirectToAction("DocumentList", pageNumber);
            //}
            //else
            //{
            //    TempData["delete"] = "false";
            //    return RedirectToAction("DocumentList", pageNumber);
            //}    

            if (result > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }  
    }
}
