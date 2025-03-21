using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("COLLECTIONS")]
[Index("SCollection", Name = "IX_sCollection", IsUnique = true)]
public partial class Collection
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sCollection")]
    [StringLength(255)]
    public string SCollection { get; set; } = null!;

    [Column("iArrangement")]
    public int IArrangement { get; set; }

    [Column("iPhysLoc")]
    public int? IPhysLoc { get; set; }

    [Column("iOwner")]
    public int? IOwner { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("ICollectionNavigation")]
    public virtual ICollection<BridgeCollItem> BridgeCollItems { get; set; } = new List<BridgeCollItem>();

    [ForeignKey("IOwner")]
    [InverseProperty("Collections")]
    public virtual Person? IOwnerNavigation { get; set; }

    [ForeignKey("IPhysLoc")]
    [InverseProperty("Collections")]
    public virtual Physloc? IPhysLocNavigation { get; set; }
}
