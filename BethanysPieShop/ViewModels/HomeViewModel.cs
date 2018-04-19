using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 ViewModels are the beans class used by the views
 It contains all the data that a view would generally require
 Just additionaly layer so that controllers instead of 
 data manuplation focus in processing request
     */
namespace BethanysPieShop.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
