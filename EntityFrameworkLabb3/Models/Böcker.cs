using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Table("Böcker")]
    public partial class Böcker
    {
        public Böcker()
        {
            Lagersaldos = new HashSet<Lagersaldo>();
            OrderSpecarHemsida = new HashSet<OrderSpecarHemsidum>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Key]
        [Column("ISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [StringLength(50)]
        public string? Titel { get; set; }
        [StringLength(50)]
        public string? Språk { get; set; }
        [Column(TypeName = "money")]
        public decimal? Pris { get; set; }
        public DateTime? Utgivningsdatum { get; set; }
        [Column("FörfattareID")]
        public int FörfattareId { get; set; }

        [ForeignKey(nameof(FörfattareId))]
        [InverseProperty("Böckers")]
        public virtual Författare Författare { get; set; } = null!;
        [InverseProperty(nameof(Lagersaldo.BöckerIsbnNavigation))]
        public virtual ICollection<Lagersaldo> Lagersaldos { get; set; }
        [InverseProperty(nameof(OrderSpecarHemsidum.IsbnNavigation))]
        public virtual ICollection<OrderSpecarHemsidum> OrderSpecarHemsida { get; set; }
    }
}
