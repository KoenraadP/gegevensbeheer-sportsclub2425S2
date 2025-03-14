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
    }
}
