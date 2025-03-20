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
                List<Member> lstMembers = MemberBll.ReadAll();
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

        // Details methode om info over 
        // één member specifiek op te vragen
        // deze MOET de naam Details hebben omdat dit zo al
        // vastgelegd werd in de Index view bij de links
        public ActionResult Details(int id)
        {
            try
            {
                // member opvragen via Bll
                Member m = MemberBll.ReadOne(id);
                // member doorgeven aan view
                // View aanmaken met RMK op View, add view
                // template Details - model Member
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // Create
        // twee methodes nodig: de eerste maakt de link naar
        // de view aan, de tweede verwerkt de gegevens die
        // via het formulier verstuurd worden om zo een Member
        // met voornaam en achternaam in de databank aan te maken

        public ActionResult Create()
        {
            return View();
        }
    }
}