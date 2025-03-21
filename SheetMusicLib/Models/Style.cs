using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("STYLES")]
[Index("SStyle", Name = "IX_sStyle", IsUnique = true)]
public partial class Style
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sStyle")]
    [StringLength(25)]
    public string SStyle { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IStyleNavigation")]
    public virtual ICollection<BridgeArrStyle> BridgeArrStyles { get; set; } = new List<BridgeArrStyle>();
}
