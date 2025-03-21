using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("PHYSLOCS")]
[Index("IPath", "IFileName", Name = "UC_PHYSLOCS_iPath_iFileName", IsUnique = true)]
public partial class Physloc
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sLocationName")]
    [StringLength(127)]
    public string? SLocationName { get; set; }

    [Column("iPath")]
    public int? IPath { get; set; }

    [Column("iFileName")]
    public int? IFileName { get; set; }

    /// <summary>
    /// Single character indicating the type of storage medium: &apos;P&apos; - printed paper, &apos;F&apos; - Computer file, &apos;O&apos; - other
    /// </summary>
    [Column("iMediumType")]
    public int IMediumType { get; set; }

    [Column("iRoomHall")]
    public int? IRoomHall { get; set; }

    [Column("iCabStack")]
    public int? ICabStack { get; set; }

    [Column("iDrawerShelf")]
    public int? IDrawerShelf { get; set; }

    [Column("iFolderOrBox")]
    public int? IFolderOrBox { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IPhysLocNavigation")]
    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    [ForeignKey("ICabStack")]
    [InverseProperty("Physlocs")]
    public virtual Sh1Cabsstack? ICabStackNavigation { get; set; }

    [ForeignKey("IDrawerShelf")]
    [InverseProperty("Physlocs")]
    public virtual Sh2Drawersshelf? IDrawerShelfNavigation { get; set; }

    [ForeignKey("IFileName")]
    [InverseProperty("Physlocs")]
    public virtual FileName? IFileNameNavigation { get; set; }

    [ForeignKey("IFolderOrBox")]
    [InverseProperty("Physlocs")]
    public virtual Sh3Foldersbox? IFolderOrBoxNavigation { get; set; }

    [ForeignKey("IMediumType")]
    [InverseProperty("Physlocs")]
    public virtual Mediatype IMediumTypeNavigation { get; set; } = null!;

    [ForeignKey("IPath")]
    [InverseProperty("Physlocs")]
    public virtual FilePath? IPathNavigation { get; set; }

    [ForeignKey("IRoomHall")]
    [InverseProperty("Physlocs")]
    public virtual Sh0Roomshall? IRoomHallNavigation { get; set; }
}
