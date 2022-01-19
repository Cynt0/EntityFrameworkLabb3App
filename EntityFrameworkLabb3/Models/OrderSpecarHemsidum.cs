using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    public partial class OrderSpecarHemsidum
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Key]
        [Column("ISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        public DateTime Orderdatum { get; set; }
        [Column(TypeName = "money")]
        public decimal OrderPris { get; set; }

        [ForeignKey(nameof(Isbn))]
        [InverseProperty(nameof(Böcker.OrderSpecarHemsida))]
        public virtual Böcker IsbnNavigation { get; set; } = null!;
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Ordrar.OrderSpecarHemsida))]
        public virtual Ordrar Order { get; set; } = null!;
    }
}
