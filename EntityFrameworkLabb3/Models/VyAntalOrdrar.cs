using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    public partial class VyAntalOrdrar
    {
        [Column("ISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        public DateTime Orderdatum { get; set; }
        [Column(TypeName = "money")]
        public decimal OrderPris { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("KundID")]
        public int KundId { get; set; }
    }
}
