using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("INSTRUMENTS")]
[Index("SAbbrev", Name = "IX_sAbbrev", IsUnique = true)]
[Index("SInstrument", Name = "IX_sInstrument", IsUnique = true)]
public partial class Instrument
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sInstrument")]
    [StringLength(64)]
    public string SInstrument { get; set; } = null!;

    [Column("sAbbrev")]
    [StringLength(8)]
    public string SAbbrev { get; set; } = null!;

    [Column("iInstrGroup")]
    public int IInstrGroup { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IInstrGroup")]
    [InverseProperty("Instruments")]
    public virtual Instrgroup IInstrGroupNavigation { get; set; } = null!;

    [InverseProperty("IInstrumentNavigation")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
