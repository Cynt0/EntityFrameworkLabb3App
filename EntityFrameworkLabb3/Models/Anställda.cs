using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    public partial class Anställda
    {
        public Anställda()
        {
            Butikers = new HashSet<Butiker>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Förnamn { get; set; }
        [StringLength(50)]
        public string? Efternamn { get; set; }
        [StringLength(50)]
        public string? Mobilnummer { get; set; }
        [Column("ButikerID")]
        public int ButikerId { get; set; }

        [ForeignKey(nameof(ButikerId))]
        [InverseProperty("Anställda")]
        public virtual Butiker Butiker { get; set; } = null!;
        [InverseProperty("AnställdaNavigation")]
        public virtual ICollection<Butiker> Butikers { get; set; }
    }
}
