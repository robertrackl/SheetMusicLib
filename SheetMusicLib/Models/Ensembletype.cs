using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("ENSEMBLETYPES")]
[Index("SEnsembleType", Name = "IX_sEnsembleType", IsUnique = true)]
public partial class Ensembletype
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sEnsembleType")]
    [StringLength(127)]
    public string SEnsembleType { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IEnsembleTypeNavigation")]
    public virtual ICollection<Arrangement> Arrangements { get; set; } = new List<Arrangement>();
}
