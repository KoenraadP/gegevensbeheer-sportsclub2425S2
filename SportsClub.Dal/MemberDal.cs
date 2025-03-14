using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
