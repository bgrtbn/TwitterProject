using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterProject.Model.Option;
using TwitterProject.UI.Areas.Member.Models.DTO;

namespace TwitterProject.UI.Areas.Member.Models.VM
{
    public class TweetVM
    {
        public TweetVM()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
            AppUsers = new List<AppUser>();
            appUser = new AppUser();

            tweet = new TweetDTO();
        }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<AppUser> AppUsers  { get; set; }
        public TweetDTO tweet { get; set; }
        public AppUser appUser { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}