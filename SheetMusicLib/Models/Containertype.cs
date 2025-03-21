using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("CONTAINERTYPES")]
[Index("SContainerType", Name = "IX_CONTAINERTYPES", IsUnique = true)]
public partial class Containertype
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sContainerType")]
    [StringLength(16)]
    public string SContainerType { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IContainerTypeNavigation")]
    public virtual ICollection<Sh0Roomshall> Sh0Roomshalls { get; set; } = new List<Sh0Roomshall>();

    [InverseProperty("IContainerTypeNavigation")]
    public virtual ICollection<Sh1Cabsstack> Sh1Cabsstacks { get; set; } = new List<Sh1Cabsstack>();

    [InverseProperty("IContainerTypeNavigation")]
    public virtual ICollection<Sh2Drawersshelf> Sh2Drawersshelves { get; set; } = new List<Sh2Drawersshelf>();

    [InverseProperty("IContainerTypeNavigation")]
    public virtual ICollection<Sh3Foldersbox> Sh3Foldersboxes { get; set; } = new List<Sh3Foldersbox>();
}
