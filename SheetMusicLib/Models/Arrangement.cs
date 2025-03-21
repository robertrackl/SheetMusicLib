using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("ARRANGEMENTS")]
public partial class Arrangement
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    /// <summary>
    /// The title of this arrangement. If bOriginal is true, this title should be empty because the title of the original work in table WORKS prevails.
    /// </summary>
    [Column("sTitle")]
    [StringLength(127)]
    public string? STitle { get; set; }

    /// <summary>
    /// The subtitle of this arrangement. If bOriginal is true, this subtitle should be empty because the subtitle of the original work in table WORKS prevails.
    /// </summary>
    [Column("sSubtitle")]
    [StringLength(255)]
    public string? SSubtitle { get; set; }

    /// <summary>
    /// Pointer to row in table PEOPLE indicating composer or arranger. If here is no such person then point to an entry called &apos;unknown&apos; or &apos;anonymous&apos;.
    /// </summary>
    [Column("iCompArr")]
    public int ICompArr { get; set; }

    /// <summary>
    /// Year when composition or arrangement was created/completed
    /// </summary>
    [Column("iYearCompleted")]
    public int? IYearCompleted { get; set; }

    /// <summary>
    /// Year of composition or arrangement publication
    /// </summary>
    [Column("iYearPublished")]
    public int? IYearPublished { get; set; }

    /// <summary>
    /// Pointer to row in table WORKS. This  underlying work must exist.
    /// </summary>
    [Column("iWork")]
    public int IWork { get; set; }

    [Column("iEnsembleType")]
    public int? IEnsembleType { get; set; }

    /// <summary>
    /// True - it is an original composition. False - it is an arrangement
    /// </summary>
    [Column("bOriginal")]
    public bool BOriginal { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    /// <summary>
    /// Pointer to another record in the same table to indicate the original composition or arrangement on which this arrangement is based. If one exists bOriginal should be false.
    /// </summary>
    [Column("iBasedOnArr")]
    public int? IBasedOnArr { get; set; }

    [InverseProperty("IArrangementNavigation")]
    public virtual ICollection<BridgeArrForm> BridgeArrForms { get; set; } = new List<BridgeArrForm>();

    [InverseProperty("IArrangementNavigation")]
    public virtual ICollection<BridgeArrGenre> BridgeArrGenres { get; set; } = new List<BridgeArrGenre>();

    [InverseProperty("IArrangementNavigation")]
    public virtual ICollection<BridgeArrStyle> BridgeArrStyles { get; set; } = new List<BridgeArrStyle>();

    [ForeignKey("IBasedOnArr")]
    [InverseProperty("InverseIBasedOnArrNavigation")]
    public virtual Arrangement? IBasedOnArrNavigation { get; set; }

    [ForeignKey("ICompArr")]
    [InverseProperty("Arrangements")]
    public virtual Person ICompArrNavigation { get; set; } = null!;

    [ForeignKey("IEnsembleType")]
    [InverseProperty("Arrangements")]
    public virtual Ensembletype? IEnsembleTypeNavigation { get; set; }

    [ForeignKey("IWork")]
    [InverseProperty("Arrangements")]
    public virtual Work IWorkNavigation { get; set; } = null!;

    [InverseProperty("IBasedOnArrNavigation")]
    public virtual ICollection<Arrangement> InverseIBasedOnArrNavigation { get; set; } = new List<Arrangement>();

    [InverseProperty("IArrangementNavigation")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
