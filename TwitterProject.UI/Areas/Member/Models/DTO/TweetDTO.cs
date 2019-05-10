using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterProject.UI.Areas.Member.Models.DTO
{
    public class TweetDTO
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string TweetImage { get; set; }
        public string XSmallTweetImage { get; set; }
        public string CruptedTweetImage { get; set; }
        public string ImagePath { get; set; }

        public Guid AppUserID { get; set; }
      
    }
}