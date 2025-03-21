using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("CHANGE_LOG")]
public partial class ChangeLog
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sTableName")]
    [StringLength(128)]
    public string STableName { get; set; } = null!;

    /// <summary>
    /// ID of affected record in table sTableName
    /// </summary>
    [Column("iRecord")]
    public int IRecord { get; set; }

    /// <summary>
    /// I = insert, U = update, D = delete
    /// </summary>
    [Column("cActionType")]
    [StringLength(1)]
    [Unicode(false)]
    public string CActionType { get; set; } = null!;

    [Column("uChangedBy")]
    public Guid UChangedBy { get; set; }

    [Column("DChanged", TypeName = "datetime")]
    public DateTime Dchanged { get; set; }

    /// <summary>
    /// JSON serialization of old value of entire record
    /// </summary>
    [Column("sOldValue")]
    public string? SOldValue { get; set; }

    /// <summary>
    /// JSON serialization of new value of entire record
    /// </summary>
    [Column("sNewValue")]
    public string? SNewValue { get; set; }

    [ForeignKey("UChangedBy")]
    [InverseProperty("ChangeLogs")]
    public virtual User UChangedByNavigation { get; set; } = null!;
}
