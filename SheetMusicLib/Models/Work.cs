using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("WORKS")]
[Index("STitle", "SComposerInitials", Name = "IX_WORKS", IsUnique = true)]
public partial class Work
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sTitle")]
    [StringLength(127)]
    public string STitle { get; set; } = null!;

    /// <summary>
    /// Can be null most of the time. Only needeed when there are duplicate titles and the record would not have a unique title. The combination of title and composer intials must be unique.
    /// </summary>
    [Column("sComposerInitials")]
    [StringLength(5)]
    public string? SComposerInitials { get; set; }

    [Column("sSubTitle")]
    [StringLength(255)]
    public string? SSubTitle { get; set; }

    [Column("iBasedOn")]
    public int? IBasedOn { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IWorkNavigation")]
    public virtual ICollection<Arrangement> Arrangements { get; set; } = new List<Arrangement>();

    [ForeignKey("IBasedOn")]
    [InverseProperty("InverseIBasedOnNavigation")]
    public virtual Work? IBasedOnNavigation { get; set; }

    [InverseProperty("IBasedOnNavigation")]
    public virtual ICollection<Work> InverseIBasedOnNavigation { get; set; } = new List<Work>();
}
