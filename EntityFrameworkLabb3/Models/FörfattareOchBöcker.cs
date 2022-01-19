using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    [Table("FörfattareOchBöcker")]
    public partial class FörfattareOchBöcker
    {
        [Column("ISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [Column("FörfattareID")]
        public int FörfattareId { get; set; }

        [ForeignKey(nameof(FörfattareId))]
        public virtual Författare Författare { get; set; } = null!;
        [ForeignKey(nameof(Isbn))]
        public virtual Böcker IsbnNavigation { get; set; } = null!;
    }
}
