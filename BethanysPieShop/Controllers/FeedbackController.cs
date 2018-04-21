﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // Why? for post request
        //Feedback object created via the model binding
        // at this point modle binder has locked at all the data in form data
        // with request and search for data that corresponds to feedback properties
        // will search for phone email etc etc that are generated by tag helpers
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
