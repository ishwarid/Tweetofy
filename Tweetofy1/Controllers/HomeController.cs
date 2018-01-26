using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Tweetofy1.Models;
//using RestSharp;
//using RestSharp.Authenticators;

namespace Tweetofy1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Twitofy!";

            return View();
        }

        //public ActionResult ()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        public ActionResult ShowTweets(FormCollection Form)
        {
            string bearer = "AAAAAAAAAAAAAAAAAAAAAIDD4AAAAAAAamkhD24d2rBj4PcFwTujM%2FDfJSg%3DK2Piy7l1bFWxHPWmct2brKb8zlz0HRAjCKohawOjMqYDr9ufs2";
            Tweets currentTweets = new Tweets();

            List<Tweets> TweetsList = new List<Tweets> ();            
            TweetsList.Add(currentTweets);
            //ViewBag.TweetsList = TweetsList;
            //currentTweets = {"_id": "5a6ac1e7394bc45902a4dfe5","name": "Sherman Reese","address": "315 Regent Place, Herald, Pennsylvania, 8672","about": "Nostrud velit ut fugiat adipisicing do ut et laborum excepteur incididunt. Ex dolor irure veniam Lorem fugiat est consectetur ipsum duis veniam in. Lorem aute anim dolor ea fugiat pariatur ullamco Lorem magna adipisicing exercitation adipisicing consectetur dolore.\r\n"};
            //return Json(TweetsList);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            string username = Form["UserId"];
            HttpResponseMessage response = client.GetAsync("?screen_name=" + username + "&count=100").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Tweets>>().Result;
                foreach (var d in dataObjects)
                {
                    //Console.WriteLine("{0}", d.text);
                    TweetsList.Add(d);
                }
            }
            else
            {
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
               // ViewBag.message = "error";
            }  

            return View(TweetsList);
        }

        
 
        
    }
}
