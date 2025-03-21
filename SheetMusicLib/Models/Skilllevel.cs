using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SKILLLEVELS")]
[Index("SSkillLevel", Name = "IX_sSkillLevel", IsUnique = true)]
public partial class Skilllevel
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    /// <summary>
    /// Textual description of skill level
    /// </summary>
    [Column("sSkillLevel")]
    [StringLength(25)]
    public string SSkillLevel { get; set; } = null!;

    /// <summary>
    /// Numerical skill level for the purpose of ordering the textual skill levels
    /// </summary>
    [Column("iSkillLevel")]
    public int ISkillLevel { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [InverseProperty("ISkillLevelNavigation")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
