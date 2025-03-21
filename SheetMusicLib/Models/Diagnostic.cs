using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("DIAGNOSTICS")]
public partial class Diagnostic
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    /// <summary>
    /// f = fatal error (software collapse); s = severe or stop error (causes popup message to user); c = continuable error (may cause popup message); w = warning; i = info; d = debug
    /// </summary>
    [Column("cSeverity")]
    [StringLength(1)]
    [Unicode(false)]
    public string CSeverity { get; set; } = null!;

    [Column("iLevel")]
    public short? ILevel { get; set; }

    [Column("DWhen")]
    public DateTime Dwhen { get; set; }

    [Column("sText")]
    public string SText { get; set; } = null!;
}
