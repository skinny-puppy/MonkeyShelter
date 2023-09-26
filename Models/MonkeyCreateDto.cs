using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MonkeyShelter.Common;

namespace MonkeyShelter.Models
{
    public class MonkeyCreateDto
    {
        public MonkeyCreateDto()
        {
            this.Registered = DateTime.UtcNow.ToString("ddd MMM dd yyyy HH:mm:ss");
            this.Id = KeyGenerator.GetUniqueKey(24);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "You should provide a name.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "You should provide weight.")]
        public int Weight { get; set; }
        public string EyeColor { get; set; }
        [Required(ErrorMessage = "You should provide species.")]
        public string Species { get; set; }
        public string Registered { get; set; }
        public string FavoriteFruit { get; set; }
    }
}