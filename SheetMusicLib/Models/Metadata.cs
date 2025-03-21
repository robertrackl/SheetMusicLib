using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("METADATA")]
public partial class Metadata
{
    [Key]
    [Column("sTableName")]
    [StringLength(128)]
    public string STableName { get; set; } = null!;

    [Column("sDescription")]
    public string SDescription { get; set; } = null!;
}
