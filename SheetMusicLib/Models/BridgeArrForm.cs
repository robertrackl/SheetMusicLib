using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("BRIDGE_ARR_FORMS")]
public partial class BridgeArrForm
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iArrangement")]
    public int IArrangement { get; set; }

    [Column("iMusicalForm")]
    public int IMusicalForm { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IArrangement")]
    [InverseProperty("BridgeArrForms")]
    public virtual Arrangement IArrangementNavigation { get; set; } = null!;

    [ForeignKey("IMusicalForm")]
    [InverseProperty("BridgeArrForms")]
    public virtual Musicalform IMusicalFormNavigation { get; set; } = null!;
}
