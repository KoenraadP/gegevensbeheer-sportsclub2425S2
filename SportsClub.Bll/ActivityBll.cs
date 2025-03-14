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
            // en of deze lijst niet leeg is
            if (lstActivities == null || lstActivities.Count == 0)
            {
                // eigen exception boodschap aanmaken
                // throw stopt ook de methode
                throw new Exception("No activities found");
            }

            // lijst van activities als return
            return lstActivities;
        }
    }
}
