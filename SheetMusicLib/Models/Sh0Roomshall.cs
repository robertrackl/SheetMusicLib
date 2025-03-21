using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SH0_ROOMSHALLS")]
[Index("SContainerName", Name = "IX_SH0_ROOMSHALLS", IsUnique = true)]
public partial class Sh0Roomshall
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sContainerName")]
    [StringLength(127)]
    public string SContainerName { get; set; } = null!;

    [Column("iContainerType")]
    public int IContainerType { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IContainerType")]
    [InverseProperty("Sh0Roomshalls")]
    public virtual Containertype IContainerTypeNavigation { get; set; } = null!;

    [InverseProperty("IRoomHallNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();

    [InverseProperty("IRoomHallNavigation")]
    public virtual ICollection<Sh1Cabsstack> Sh1Cabsstacks { get; set; } = new List<Sh1Cabsstack>();
}
