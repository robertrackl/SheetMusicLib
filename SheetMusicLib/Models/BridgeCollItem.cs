using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("BRIDGE_COLL_ITEMS")]
public partial class BridgeCollItem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iCollection")]
    public int ICollection { get; set; }

    [Column("iItem")]
    public int IItem { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("ICollection")]
    [InverseProperty("BridgeCollItems")]
    public virtual Collection ICollectionNavigation { get; set; } = null!;

    [ForeignKey("IItem")]
    [InverseProperty("BridgeCollItems")]
    public virtual Item IItemNavigation { get; set; } = null!;
}
