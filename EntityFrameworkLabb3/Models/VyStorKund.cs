using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    public partial class VyStorKund
    {
        [Column("KundID")]
        public int KundId { get; set; }
        [Column(TypeName = "money")]
        public decimal OrderPris { get; set; }
        [StringLength(50)]
        public string? Förnamn { get; set; }
    }
}
