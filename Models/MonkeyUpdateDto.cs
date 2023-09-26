using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Models
{
    public class MonkeyUpdateDto
    {
        
        public string Id { get; set; }
        public int Weight { get; set; }

    }
}