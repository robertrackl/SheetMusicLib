using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("PARTS")]
public partial class Part
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("iItem")]
    public int IItem { get; set; }

    [Column("iInstrument")]
    public int IInstrument { get; set; }

    /// <summary>
    /// A sequence number for different parts of the same instrument if they are indeed distributed as different parts.
    /// </summary>
    [Column("sPartSeqNum")]
    [StringLength(16)]
    public string? SPartSeqNum { get; set; }

    /// <summary>
    /// Serial  number of identical copies (i.e., one specific instrument) intended for different members of the ensemble or orchestra
    /// </summary>
    [Column("iInstrCopySeqNum")]
    public int? IInstrCopySeqNum { get; set; }

    [Column("iInstMinCount")]
    public int? IInstMinCount { get; set; }

    [Column("iSkillLevel")]
    public int? ISkillLevel { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IInstrument")]
    [InverseProperty("Parts")]
    public virtual Instrument IInstrumentNavigation { get; set; } = null!;

    [ForeignKey("IItem")]
    [InverseProperty("Parts")]
    public virtual Item IItemNavigation { get; set; } = null!;

    [ForeignKey("ISkillLevel")]
    [InverseProperty("Parts")]
    public virtual Skilllevel? ISkillLevelNavigation { get; set; }
}
