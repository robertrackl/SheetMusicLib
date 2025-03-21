using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("BRIDGE_ARR_STYLES")]
public partial class BridgeArrStyle
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iArrangement")]
    public int IArrangement { get; set; }

    [Column("iStyle")]
    public int IStyle { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IArrangement")]
    [InverseProperty("BridgeArrStyles")]
    public virtual Arrangement IArrangementNavigation { get; set; } = null!;

    [ForeignKey("IStyle")]
    [InverseProperty("BridgeArrStyles")]
    public virtual Style IStyleNavigation { get; set; } = null!;
}
