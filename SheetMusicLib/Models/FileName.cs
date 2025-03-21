using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("FILE_NAMES")]
[Index("SFileName", Name = "IDX_FILE_NAMES")]
[Index("SFileName", Name = "UQ__FILE_NAM__BEB5E6B187BA08BA", IsUnique = true)]
public partial class FileName
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sFileName")]
    [StringLength(850)]
    public string SFileName { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IFileNameNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();
}
