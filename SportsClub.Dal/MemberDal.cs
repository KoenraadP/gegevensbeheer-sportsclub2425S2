using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SportsClub.Entities;

namespace SportsClub.Dal
{
    // moet public zijn want moet bereikbaar zijn in Bll
    // static --> uitleg bij MemberBll
    public static class MemberDal
    {
        // CRUD operaties
        // Create, Read, Update, Delete

        // Read All

        // alle members ophalen uit databank
        // niet vergeten bovenaan using SportsClub.Entities te plaatsen
        // indien nodig om Member te kunnen gebruiken
        public static List<Member> ReadAll()
        {
            // using --> wanneer de code in dit blokje
            // klaar is met uitvoeren, wordt de verbinding met 
            // de databank weer gesloten
            // verbinding wordt geregeld via de DbContext
            using (var db = new SportsClubDbContext())
            {
                // lijst van members uit db ophalen
                // entityframework zal voor onderstaande code
                // automatisch de juiste sql query maken en uitvoeren
                // (select * from Members)
                List<Member> lstMembers = db.Members.ToList();
                // lijst van members als return
                return lstMembers;
            }
        }

        // Read One
        // methode om één member op te halen uit de db
        public static Member ReadOne(int id)
        {
            using (var db = new SportsClubDbContext())
            {
                // member ophalen uit db
                // entityframework zal voor onderstaande code
                // automatisch de juiste sql query maken en uitvoeren
                // (select * from Members where Id = id)
                // met de .Find() methode kun je naar één specifieke
                // record gaan zoeken op basis van de primary key (id)
                Member member = db.Members.Find(id);
                // member als return
                return member;
            }
        }

        // Create
        // bool omdat we willen weten op het einde
        // of het gelukt (true) of niet gelukt (false) is
        // de Member die binnenkomt krijgen we van de Bll
        public static bool Create(Member member)
        {
            using (var db = new SportsClubDbContext())
            {
                // laatste redmiddel als er toch iemand in slaagt
                // om iets fout door te voeren --> try catch
                try
                {
                    // db Add methode zet de bewerking klaar
                    db.Members.Add(member);
                    // db SaveChanges methode voert de bewerking uit
                    int numberOfchanges = db.SaveChanges();
                    // als er 1 of meer records gewijzigd zijn
                    // is de Create gelukt
                    if (numberOfchanges > 0) return true;
                    // niet gelukt --> return false
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        // Delete
        // bool omdat we willen weten op het einde
        // of het gelukt (true) of niet gelukt (false) is
        public static bool Delete(Member member)
        {
            using (var db = new SportsClubDbContext())
            {
                try
                {
                    // db.Members.Remove(member); --> werkt niet in deze versie
                    // de status van de member op 'deleted' zetten
                    // using System.Data.Entity; nodig bovenaan
                    db.Entry(member).State = EntityState.Deleted;
                    // db SaveChanges methode voert de bewerking uit
                    int numberOfchanges = db.SaveChanges();
                    // als er 1 of meer records gewijzigd zijn
                    // is de Delete gelukt
                    if (numberOfchanges > 0) return true;
                    return false;
                }
                catch 
                {
                    return false;
                }
            }
        }

        // Update
        // bool omdat we willen weten op het einde
        // of het gelukt (true) of niet gelukt (false) is
        // naam parameter mag je zelf kiezen maar voor de duidelijkheid
        // noem ik deze hier updatedMember
        public static bool Update(Member updatedMember)
        {
            // db verbinding
            using (var db = new SportsClubDbContext())
            {
                try
                {
                    // methode om record aan te passen
                    // de AddOrUpdate zoekt naar een record met dezelfde primary key
                    // als de updatedMember en past dan de nodige informatie aan
                    db.Members.AddOrUpdate(updatedMember);
                    // effectief wijzigingen in db uitvoeren met savechanges
                    // en ook controleren of er effectief iets gewijzigd is
                    int numberOfchanges = db.SaveChanges();
                    if (numberOfchanges > 0) return true;
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
