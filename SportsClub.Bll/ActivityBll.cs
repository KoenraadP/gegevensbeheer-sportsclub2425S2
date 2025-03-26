using SportsClub.Dal;
using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Bll
{
    public static class ActivityBll
    {
        public static List<Activity> ReadAll()
        {
            // methode uit Dal gebruiken
            List<Activity> lstActivities = ActivityDal.ReadAll();

            // controleren of we effectief een correcte lijst krijgen
            if (lstActivities == null)
            {
                // eigen exception boodschap aanmaken
                // throw stopt ook de methode
                throw new Exception("No activities found");
            }

            // lijst van activities als return
            return lstActivities;
        }

        // methode om één activity op te halen via de Dal 
        // hierin gaan we ook controleren of we effectief
        // een activity terug krijgen, anders exception aanmaken
        public static Activity ReadOne(int id)
        {
            Activity a = ActivityDal.ReadOne(id);
            if (a == null)
            {
                throw new Exception("Activity not found");
            }
            return a;
        }
    }
}
