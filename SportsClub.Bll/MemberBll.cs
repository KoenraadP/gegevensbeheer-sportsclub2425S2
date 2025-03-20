using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsClub.Entities;
using SportsClub.Dal;

namespace SportsClub.Bll
{
    // als je een class 'static' maakt
    // dan kun je deze class gewoon overal gebruiken als bvb MemberBll.ReadAll()
    // je moet nooit een variabele maken of met 'new' werken
    // maar je moet ook ALLE methodes die erin staan static maken
    public static class MemberBll
    {
        // Read All
        // opnieuw de using SportsClub.Entities niet vergeten
        // en using SportsClub.Dal
        public static List<Member> ReadAll()
        {
            // methode uit Dal gebruiken
            List<Member> lstMembers = MemberDal.ReadAll();

            // controleren of we effectief een correcte lijst krijgen
            // en of deze lijst niet leeg is
            if (lstMembers == null || lstMembers.Count == 0)
            {
                // eigen exception boodschap aanmaken
                // throw stopt ook de methode
                throw new Exception("No members found");
            }

            // lijst van members als return
            return lstMembers;
        }

        // methode om één member op te halen via de Dal 
        // hierin gaan we ook controleren of we effectief
        // een member terug krijgen, anders exception aanmaken
        public static Member ReadOne(int id)
        {
            Member m = MemberDal.ReadOne(id);
            if (m == null)
            {
                throw new Exception("Member not found");
            }
            return m;
        }

        // Create
        // hier moeten we parameters doorgeven die overeenstemmen
        // met de properties van de Member class die ingesteld worden
        // via het Create formulier
        public static bool Create(string firstName, string lastName)
        {
            // Member aanmaken met data
            Member member = new Member(firstName, lastName);
            // Dal methode uitvoeren
            bool memberCreated = MemberDal.Create(member);
            // waarde van memberCreated als return (true of false)
            return memberCreated;
        }
    }
}
