using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("MUSICALFORMS")]
[Index("SMusicalForm", Name = "IX_sMusicalForm", IsUnique = true)]
public partial class Musicalform
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sMusicalForm")]
    [StringLength(127)]
    public string SMusicalForm { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IMusicalFormNavigation")]
    public virtual ICollection<BridgeArrForm> BridgeArrForms { get; set; } = new List<BridgeArrForm>();
}
