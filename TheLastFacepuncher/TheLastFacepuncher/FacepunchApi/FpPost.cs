using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheLastFacepuncher.FacepunchApi
{
    public class FpPost
    {
        public enum Rating
        {
            funny,
            agree
        }

        public int ID;
        public int UserID;
        public string UserName;
        public string Message;
        public string AvatarURL;
        //Image Avatar;
        public List<Rating> Ratings;
    }
}