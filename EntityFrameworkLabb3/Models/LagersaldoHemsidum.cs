using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    public partial class LagersaldoHemsidum
    {
        [Column("BöckerISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string BöckerIsbn { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal BökerPris { get; set; }
        [StringLength(10)]
        public string? Antal { get; set; }
    }
}
