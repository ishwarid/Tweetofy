using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tweetofy1.Models
{
    public class HomeModel
    {

        [Required(ErrorMessage = "Username is required.")]
        public string UserId { get; set; }
    }
}