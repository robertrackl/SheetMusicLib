using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SETTINGS")]
[Index("sSettingKey", Name = "IX_SETTINGS", IsUnique = true)]
public partial class Setting
{
    [Key]
    [Column("ID")]
    public int ID { get; set; }

    [Column("sSettingKey")]
    [StringLength(50)]
    public string sSettingKey { get; set; } = null!;

    [Column("sSettingValue")]
    public string sSettingValue { get; set; } = null!;

    [Column("sDescription")]
    [StringLength(255)]
    public string? sDescription { get; set; }
}
