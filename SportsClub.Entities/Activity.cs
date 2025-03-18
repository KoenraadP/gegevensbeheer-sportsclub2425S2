using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Activityname { get; set; }
        public int MaxParticipants { get; set; } // aantal ingeschrevenen voor een activiteit

        // een activity kan meerdere members bevatten
        public List<Member> Members { get; set; }

        public Activity(string activityName, int maxParticipants)
        {
            Activityname = activityName;
            MaxParticipants = maxParticipants;
            // lege list starten voor members
            Members = new List<Member>();
        }

        // lege constructor voor de Seed() methode
        public Activity()
        {
            
        }
    }
}
