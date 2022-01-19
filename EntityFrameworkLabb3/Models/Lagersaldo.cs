using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Table("Lagersaldo")]
    public partial class Lagersaldo
    {
        [Key]
        [Column("BöckerISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string BöckerIsbn { get; set; } = null!;
        [Key]
        [Column("ButikerID")]
        public int ButikerId { get; set; }
        public int? Antal { get; set; }

        [ForeignKey(nameof(ButikerId))]
        [InverseProperty("Lagersaldos")]
        public virtual Butiker Butiker { get; set; } = null!;
        [ForeignKey(nameof(BöckerIsbn))]
        [InverseProperty(nameof(Böcker.Lagersaldos))]
        public virtual Böcker BöckerIsbnNavigation { get; set; } = null!;
    }
}
