using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            string check = searchType; //char.ToUpper(searchType[0]) + searchType.Substring(1);
            ViewBag.check = check;
            ViewBag.term = searchTerm;
            List<Dictionary<string, string>> jobs;
            if (searchType.Equals("all"))
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    jobs = JobData.FindAll();
                }
                else
                {
                    jobs = JobData.FindByValue(searchTerm);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    jobs = JobData.FindAll();
                }
                else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            ViewBag.jobs = jobs;
            return View();
        }

    }
}
