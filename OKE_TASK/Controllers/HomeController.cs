using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using Oke_task.Helpers;
using Oke_task.Models;

namespace Oke_task.Controllers
{
    public class HomeController : Controller
    {
	    public ViewResult Index(string message = "Add a country to XML File") {
		    ViewBag.message = message;
		    return View();
	    }

        [HttpPost]
		[AcceptVerbs(HttpVerbs.Post)]
		[ValidateAntiForgeryToken]
        public ViewResult Index(Models.Country model)
        {
	        if (ModelState.IsValid) {
				ViewBag.Message = "Your country has been added";
				var XMLReader = new XMLReader(model);
				XMLReader.Writer();
				return View();
			}
			return View();

        }

	    public ViewResult ListOfCountries(Models.Country model) {

		    XMLReader readXML = new XMLReader(model);

		    var data = readXML.ReturnListofCountries();
		    return View(data);
	    }

	    public ViewResult SpecificCountry(Models.Country model) {
			XMLReader readXML = new XMLReader(model);

		    var data = readXML.ReturnSpecificCountry();
		    return View(data);
	    }
    }
}