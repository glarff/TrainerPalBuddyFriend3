using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TrainerPalBuddyFriend3 {
    
    public class Warpgate
    {
        public Warpgate() { }
        public virtual int Wksegpk { get; set; }
        public virtual Gateway Gateway { get; set; }
        public virtual Templar Templar { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Sequence { get; set; }
        public virtual SelectList DDLWorkouts { get; set; }
        public virtual SelectList DDLSegments { get; set; }
    }
}
