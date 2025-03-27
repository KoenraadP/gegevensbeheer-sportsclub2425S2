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

        // [HttpPost] duidt aan dat dit de methode is
        // die moet aangesproken worden bij het verzenden van
        // onze POST form
        // parameters moeten exact gespeld zijn zoals de properties van de Member class
        [HttpPost]
        public ActionResult Create(string firstName, string lastName)
        {
            // de Create methode uit de Bll uitvoeren en resultaat (true/false opslaan)
            bool memberCreated = MemberBll.Create(firstName, lastName);

            // als het aanmaken van de member gelukt is
            if (memberCreated)
            {
                // Feedback boodschap plaatsen in de ViewBag
                ViewBag.Feedback = firstName + " " + lastName + " added.";
            }
            else
            {
                // Feedback boodschap plaatsen in de ViewBag
                ViewBag.Feedback = "Something went wrong - failed to add member.";
            }

            // opnieuw naar de Create view gaan en 
            // feedback boodschap tonen
            return View();
        }

        // DELETE
        // twee methodes nodig, eentje om de
        // link naar de view te te doen werken (bevestigings pagina)
        // en eentje om de delete actie uit te voeren

        public ActionResult Delete(int id)
        {
            // code is dezelfde als bij Details
            try
            {
                // member opvragen via Bll
                Member m = MemberBll.ReadOne(id);
                // member doorgeven aan view
                // View aanmaken met RMK op View, add view
                // template Delete - model Member
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // [HttpPost] duidt aan dat dit de methode is
        // die moet aangesproken worden bij het verzenden van
        // het Delete <form> op de view
        // let op: type parameter id is hier string
        // omdat we geen twee Delete methodes met dezelfde
        // parameter type kunnen hebben
        [HttpPost]
        public ActionResult Delete(string id)
        {
            // id omzetten naar int
            int memberId = Convert.ToInt32(id);
            // member verwijderen via Bll
            bool memberDeleted = MemberBll.Delete(memberId);

            // als het verwijderen van de member gelukt is
            if (memberDeleted)
            {
                // feedback plaatsen in TempData
                // TempData kan doorgegven worden via RedirectToAction
                TempData["Feedback"] = "Member deleted.";
                // terug keren naar de Index view
                // we moeten dit doen met RedirectToAction
                // omdat de volledige Index methode opnieuw moet uitgevoerd worden
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        // UPDATE
        // twee methodes nodig, eentje om de
        // link naar de view te te doen werken (formulier)
        // en eentje om de update actie uit te voeren
        public ActionResult Edit(int id)
        {
            // code is dezelfde als bij Details
            try
            {
                // member opvragen via Bll
                Member m = MemberBll.ReadOne(id);
                // member doorgeven aan view
                // View aanmaken met RMK op View, add view
                // template Edit - model Member
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}