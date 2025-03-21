using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SETTINGS")]
[Index("SSettingKey", Name = "IX_SETTINGS", IsUnique = true)]
public partial class Setting
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sSettingKey")]
    [StringLength(50)]
    public string SSettingKey { get; set; } = null!;

    [Column("sSettingValue")]
    public string SSettingValue { get; set; } = null!;

    [Column("sDescription")]
    [StringLength(255)]
    public string? SDescription { get; set; }
}
