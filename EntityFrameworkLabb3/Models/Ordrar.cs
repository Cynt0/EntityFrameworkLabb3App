using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Table("Ordrar")]
    public partial class Ordrar
    {
        public Ordrar()
        {
            OrderSpecarHemsida = new HashSet<OrderSpecarHemsidum>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("KundID")]
        public int KundId { get; set; }

        [ForeignKey(nameof(KundId))]
        [InverseProperty(nameof(Kunder.Ordrars))]
        public virtual Kunder Kund { get; set; } = null!;
        [InverseProperty(nameof(OrderSpecarHemsidum.Order))]
        public virtual ICollection<OrderSpecarHemsidum> OrderSpecarHemsida { get; set; }
    }
}
