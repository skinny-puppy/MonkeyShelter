using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace MonkeyShelter.Models
{
    public class MonkeyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string EyeColor { get; set; }
        public string Species { get; set; }
        public DateTime Registered { get; set; }
        public string FavoriteFruit { get; set; }
    }
}