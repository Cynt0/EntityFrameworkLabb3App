using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Table("Butiker")]
    public partial class Butiker
    {
        public Butiker()
        {
            Anställda = new HashSet<Anställda>();
            Lagersaldos = new HashSet<Lagersaldo>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Namn { get; set; }
        [StringLength(50)]
        public string? Gata { get; set; }
        [StringLength(50)]
        public string? Stad { get; set; }
        [StringLength(50)]
        public string? Postnummer { get; set; }
        [Column("AnställdaID")]
        public int AnställdaId { get; set; }

        [ForeignKey(nameof(AnställdaId))]
        [InverseProperty(nameof(Models.Anställda.Butikers))]
        public virtual Anställda AnställdaNavigation { get; set; } = null!;
        [InverseProperty(nameof(Models.Anställda.Butiker))]
        public virtual ICollection<Anställda> Anställda { get; set; }
        [InverseProperty(nameof(Lagersaldo.Butiker))]
        public virtual ICollection<Lagersaldo> Lagersaldos { get; set; }
    }
}
