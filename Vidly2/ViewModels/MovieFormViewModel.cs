﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}