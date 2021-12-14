using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECMA.APP.Models
{
    [Table("tbl_Contract")]
    public partial class TblContract
    {
        [Key]
        [StringLength(50)]
        public string ContractId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDatetime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Owner { get; set; }
    }
}
