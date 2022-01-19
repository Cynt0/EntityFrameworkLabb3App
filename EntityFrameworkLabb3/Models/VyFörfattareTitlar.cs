using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    public partial class VyFörfattareTitlar
    {
        [StringLength(101)]
        public string? Författare { get; set; }
        public int? Ålder { get; set; }
        public int? Antal { get; set; }
        [Column(TypeName = "money")]
        public decimal? Lagersaldo { get; set; }
    }
}
