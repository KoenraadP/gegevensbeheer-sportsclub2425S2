using SportsClub.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsClub.Entities;

namespace SportsClub.WebApp.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: Activities
        public ActionResult Index()
        {
            // using SportsClub.Entities 
            // en using SportsClub.Bll niet vergeten
            // lijst met activities uit databank opvragen
            // try catch gebruiken om eventuele problemen op te vangen
            try
            {
                List<Activity> lstActivities = ActivityBll.ReadAll();
                // list doorgeven aan view
                return View(lstActivities); // ga naar de Index view
            }
            catch (Exception ex)
            {
                // hier vangen we de fout (Exception) op die we 'gooien' (throw)
                // in de Bll class wanneer er iets fout loopt met het ophalen
                // van de activities uit de databank
                // we geven de foutboodschap mee aan de view
                // zodat de gebruiker weet wat er fout liep
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}