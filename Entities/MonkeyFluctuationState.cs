using MonkeyShelter.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Entities
{
    public class MonkeyFluctuationState
    {
            [Key]
        
            public int id { get; set; }
            public DateTime CreatedDate = DateTime.UtcNow;
            public FluctuationState State { get; set; }
    }
}