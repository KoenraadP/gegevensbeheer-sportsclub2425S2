using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Dal
{
    public static class ActivityDal
    {
        public static List<Activity> ReadAll()
        {
            // using --> wanneer de code in dit blokje
            // klaar is met uitvoeren, wordt de verbinding met 
            // de databank weer gesloten
            // verbinding wordt geregeld via de DbContext
            using (var db = new SportsClubDbContext())
            {
                // lijst van activities uit db ophalen
                // entityframework zal voor onderstaande code
                // automatisch de juiste sql query maken en uitvoeren
                // (select * from Members)
                List<Activity> lstActivities = db.Activities.ToList();
                // lijst van activities als return
                return lstActivities;
            }
        }

        // Read One
        // methode om één activity op te halen uit de db
        public static Activity ReadOne(int id)
        {
            using (var db = new SportsClubDbContext())
            {
                // activity ophalen uit db
                // entityframework zal voor onderstaande code
                // automatisch de juiste sql query maken en uitvoeren
                // (select * from Activities where Id = id)
                // met de .Find() methode kun je naar één specifieke
                // record gaan zoeken op basis van de primary key (id)
                Activity activity = db.Activities.Find(id);
                // member als return
                return activity;
            }
        }
    }
}
