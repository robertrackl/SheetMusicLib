using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("BRIDGE_ARR_GENRES")]
public partial class BridgeArrGenre
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iArrangement")]
    public int IArrangement { get; set; }

    [Column("iGenre")]
    public int IGenre { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IArrangement")]
    [InverseProperty("BridgeArrGenres")]
    public virtual Arrangement IArrangementNavigation { get; set; } = null!;

    [ForeignKey("IGenre")]
    [InverseProperty("BridgeArrGenres")]
    public virtual Genre IGenreNavigation { get; set; } = null!;
}
