using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SheetMusicLib.Models
{
    [Table("THEMES")]
    public partial class Theme
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("sName")]
        [StringLength(50)]
        public string sName { get; set; }

        [Required]
        [Column("sBackColor")]
        [StringLength(7)]
        public string sBackColor { get; set; }

        [Required]
        [Column("sForeColor")]
        [StringLength(7)]
        public string sForeColor { get; set; }

        [Required]
        [Column("sPrimaryColor")]
        [StringLength(7)]
        public string sPrimaryColor { get; set; }

        [Required]
        [Column("sSecondaryColor")]
        [StringLength(7)]
        public string sSecondaryColor { get; set; }

        [Required]
        [Column("sTertiaryColor")]
        [StringLength(7)]
        public string sTertiaryColor { get; set; }
    }
}
