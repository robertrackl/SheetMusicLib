using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("INSTRGROUPS")]
[Index("SGroup", Name = "IX_sGroup", IsUnique = true)]
public partial class Instrgroup
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sGroup")]
    [StringLength(20)]
    public string SGroup { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IInstrGroupNavigation")]
    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();
}
