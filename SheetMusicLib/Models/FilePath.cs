using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("FILE_PATHS")]
[Index("SPath", Name = "IDX_FILE_PATHS")]
[Index("SPath", Name = "UQ__FILE_PAT__C2B5D3B9CB47D8C9", IsUnique = true)]
public partial class FilePath
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sPath")]
    [StringLength(850)]
    public string SPath { get; set; } = null!;

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("IPathNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();
}
