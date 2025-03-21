using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SH3_FOLDERSBOXES")]
[Index("SContainerName", Name = "IX_SH3_FOLDERSBOXES", IsUnique = true)]
public partial class Sh3Foldersbox
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sContainerName")]
    [StringLength(127)]
    public string SContainerName { get; set; } = null!;

    [Column("iContainerType")]
    public int IContainerType { get; set; }

    [Column("iDrawerShelf")]
    public int IDrawerShelf { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IContainerType")]
    [InverseProperty("Sh3Foldersboxes")]
    public virtual Containertype IContainerTypeNavigation { get; set; } = null!;

    [ForeignKey("IDrawerShelf")]
    [InverseProperty("Sh3Foldersboxes")]
    public virtual Sh2Drawersshelf IDrawerShelfNavigation { get; set; } = null!;

    [InverseProperty("IFolderOrBoxNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();
}
