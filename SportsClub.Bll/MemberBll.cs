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
            if (lstMembers == null)
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
            // spaties voor en na de namen verwijderen
            firstName = firstName.Trim();
            lastName = lastName.Trim();

            // nog eens extra controleren of de namen
            // niet 'null' of volledig leeg zijn
            if (!string.IsNullOrEmpty(firstName)
                && !string.IsNullOrEmpty(lastName))
            {
                // Member aanmaken met data
                Member member = new Member(firstName, lastName);
                // Dal methode uitvoeren
                bool memberCreated = MemberDal.Create(member);
                // waarde van memberCreated als return (true of false)
                return memberCreated;
            }

            // als het toch ergens fout gelopen is met de if voorwaarde
            // geef dan false als resultaat
            return false;
        }

        // Delete
        // we krijgen het id van de te deleten member binnen
        public static bool Delete(int id)
        {
            try
            {
                // Member opzoeken via id --> member nodig bij Dal methode
                Member member = MemberDal.ReadOne(id);
                // Member verwijderen via Dal
                bool memberDeleted = MemberDal.Delete(member);
                // waarde van memberDeleted als return (true of false)
                return memberDeleted;
            }
            catch
            {
                return false;
            }
        }

        // UPDATE
        // we krijgen de id van de te updaten member binnen
        // dit is nodig omdat we een bestaande record moeten aanpassen
        // de nieuwe voornaam en achternaam komen ook binnen als parameters
        public static bool Update(int id, string updatedFirstName,
            string updatedLastName)
        {
            // Member opzoeken via id --> member nodig bij Dal methode
            Member member = MemberDal.ReadOne(id);

            // eerst weer eventuele spaties verwijderen net als bij Create
            updatedFirstName = updatedFirstName.Trim();
            updatedLastName = updatedLastName.Trim();

            // controleren of de nieuwe namen niet leeg of null zijn
            if (!string.IsNullOrEmpty(updatedFirstName)
                && !string.IsNullOrEmpty(updatedLastName))
            {
                // Member updaten met nieuwe data
                member.FirstName = updatedFirstName;
                member.LastName = updatedLastName;
                // Dal methode uitvoeren
                bool memberUpdated = MemberDal.Update(member);
                // waarde van memberUpdated als return (true of false)
                return memberUpdated;
            }

            // toch nog iets mislukt? return false
            return false;
        }
    }
}
