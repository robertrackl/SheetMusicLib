using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SH2_DRAWERSSHELVES")]
[Index("SContainerName", Name = "IX_SH2_DRAWERSSHELVES", IsUnique = true)]
public partial class Sh2Drawersshelf
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sContainerName")]
    [StringLength(127)]
    public string SContainerName { get; set; } = null!;

    [Column("iContainerType")]
    public int IContainerType { get; set; }

    [Column("iCabStack")]
    public int? ICabStack { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("ICabStack")]
    [InverseProperty("Sh2Drawersshelves")]
    public virtual Sh1Cabsstack? ICabStackNavigation { get; set; }

    [ForeignKey("IContainerType")]
    [InverseProperty("Sh2Drawersshelves")]
    public virtual Containertype IContainerTypeNavigation { get; set; } = null!;

    [InverseProperty("IDrawerShelfNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();

    [InverseProperty("IDrawerShelfNavigation")]
    public virtual ICollection<Sh3Foldersbox> Sh3Foldersboxes { get; set; } = new List<Sh3Foldersbox>();
}
