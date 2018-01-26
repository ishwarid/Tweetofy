using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tweetofy1.Models
{
    public class Tweets
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserId { get; set; }
        public object text;
        public object created_at;
        public string ShowTweet { get; set; }
    }
}