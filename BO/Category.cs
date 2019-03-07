﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        public Category()
        {

        }

    }
}
