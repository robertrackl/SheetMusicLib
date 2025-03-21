using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SheetMusicLib.Models;

[Table("SH1_CABSSTACKS")]
[Index("SContainerName", Name = "IX_SH1_CABSSTACKS", IsUnique = true)]
public partial class Sh1Cabsstack
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("sContainerName")]
    [StringLength(127)]
    public string SContainerName { get; set; } = null!;

    [Column("iContainerType")]
    public int IContainerType { get; set; }

    [Column("iRoomHall")]
    public int IRoomHall { get; set; }

    [Column("sComment")]
    public string? SComment { get; set; }

    [ForeignKey("IContainerType")]
    [InverseProperty("Sh1Cabsstacks")]
    public virtual Containertype IContainerTypeNavigation { get; set; } = null!;

    [ForeignKey("IRoomHall")]
    [InverseProperty("Sh1Cabsstacks")]
    public virtual Sh0Roomshall IRoomHallNavigation { get; set; } = null!;

    [InverseProperty("ICabStackNavigation")]
    public virtual ICollection<Physloc> Physlocs { get; set; } = new List<Physloc>();

    [InverseProperty("ICabStackNavigation")]
    public virtual ICollection<Sh2Drawersshelf> Sh2Drawersshelves { get; set; } = new List<Sh2Drawersshelf>();
}
