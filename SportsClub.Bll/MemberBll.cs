using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsClub.Entities;
using SportsClub.Dal;

namespace SportsClub.Bll
{
    public class MemberBll
    {
        // Read All
        // opnieuw de using SportsClub.Entities niet vergeten
        // en using SportsClub.Dal
        public List<Member> ReadAll()
        {
            // methode uit Dal gebruiken
            List<Member> lstMembers = new MemberDal().ReadAll();

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
