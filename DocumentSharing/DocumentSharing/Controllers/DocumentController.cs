
﻿using DocumentSharing.DAL;
using DocumentSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace DocumentSharing.Controllers
{    
    public class DocumentController : Controller
    {
        DocumentDAO docDAO = new DocumentDAO();
        public IActionResult Index()
        {
            DataTable dt = docDAO.GetDocument();
            List<Models.Document> listDoc = new List<Models.Document>();
            listDoc = JsonConvert.DeserializeObject<List<Models.Document>>(JsonConvert.SerializeObject(dt));
            return View(listDoc);

        }

    }
}
