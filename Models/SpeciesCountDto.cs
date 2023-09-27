using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Models
{
    public class SpeciesCountDto
    {
        public string Species { get; set; }
        public int Count { get; set; }

        public DateTime Registered { get; set; }
    }
}