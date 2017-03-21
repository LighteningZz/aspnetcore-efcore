using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore_efcore.Models.Database
{
    [Table("M_BRANCHs")]
    public partial class MBranchs
    {
        [Column("BRANCH_ID", TypeName = "varchar(50)")]
        [Key]
        public string BranchId { get; set; }
        [Required]
        [Column("CORP_ID", TypeName = "varchar(50)")]
        public string CorpId { get; set; }
        [Column("BRANCH_CODE", TypeName = "varchar(50)")]
        public string BranchCode { get; set; }
        [Column("BRANCH_NAME", TypeName = "varchar(50)")]
        public string BranchName { get; set; }
        [Column("DELETE_STATUS")]
        public int? DeleteStatus { get; set; }
        [Column("CREATE_BY", TypeName = "varchar(50)")]
        public string CreateBy { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("UPDATE_BY", TypeName = "varchar(50)")]
        public string UpdateBy { get; set; }
        [Column("UPDATE_DATE", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("REVISION")]
        public int? Revision { get; set; }
    }
}
