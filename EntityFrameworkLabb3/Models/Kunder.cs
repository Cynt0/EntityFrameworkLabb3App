using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Table("Kunder")]
    public partial class Kunder
    {
        public Kunder()
        {
            Ordrars = new HashSet<Ordrar>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Förnamn { get; set; }
        [StringLength(50)]
        public string? Efternamn { get; set; }

        [InverseProperty(nameof(Ordrar.Kund))]
        public virtual ICollection<Ordrar> Ordrars { get; set; }
    }
}
