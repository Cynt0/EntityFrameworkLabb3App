using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb3.Models
{
    [Keyless]
    public partial class VyFleraFörfattareSammaBok
    {
        [Column("ISBN")]
        [StringLength(30)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [Column("FörfattareID")]
        public int FörfattareId { get; set; }
    }
}
