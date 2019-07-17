using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Workouts {
        public Workouts() { }
        public virtual int Workoutpk { get; set; }
        public virtual string Workoutid { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Customflg { get; set; }

    }
}
