using MonkeyShelter.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Models
{
    public class MonkeyFluctuationDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public FluctuationState FluctuationState { get; set; }
    }
}