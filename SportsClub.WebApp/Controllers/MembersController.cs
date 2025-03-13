using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsClub.Bll;

namespace SportsClub.WebApp.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            // using SportsClub.Entities 
            // en using SportsClub.Bll niet vergeten
            // lijst met members uit databank opvragen
            // try catch gebruiken om eventuele problemen op te vangen
            try
            {
                List<Member> lstMembers = new MemberBll().ReadAll();
                // list doorgeven aan view
                return View(lstMembers); // ga naar de Index view
            }
            catch (Exception ex)
            {
                // hier vangen we de fout (Exception) op die we 'gooien' (throw)
                // in de Bll class wanneer er iets fout loopt met het ophalen
                // van de members uit de databank
                // we geven de foutboodschap mee aan de view
                // zodat de gebruiker weet wat er fout liep
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}