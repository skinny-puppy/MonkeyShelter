using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Entities
{
    public class Monkey
    {

        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public int Weight { get; set; }
        public string EyeColor { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Registered { get; set; }
        public string FavoriteFruit { get; set; }
    }
}