using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LES_DB_WebAPI.Models
{
    [Table("SM_AUDITLOG")]

    public class SMAuditLog
    {
        [Key]
        [Column("LogID")]
        public int LogId { get; set; }

        [Column("ModuleName")] // 3
        [StringLength(255)]
        public string? ModuleName { get; set; }

        [Column("FileName")] // 4
        public string? FileName { get; set; }

        [Column("AuditValue")] //7
        public string? AuditValue { get; set; }

        [Column("KeyRef1")]
        [StringLength(255)]
        public string? KeyRef1 { get; set; }

        [Column("KeyRef2")] //5
        [StringLength(255)]
        public string? KeyRef2 { get; set; }

        [Column("LogType")] // 6
        [StringLength(50)]
        public string? LogType { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("BUYER_ID")]
        public int? BuyerId { get; set; }

        [Column("SUPPLIER_ID")]
        public int? SupplierId { get; set; }

        [Column("ServerName")] //9
        [StringLength(255)]
        public string? ServerName { get; set; }

        [Column("BuyerCode")] // 1, 10
        [StringLength(50)]
        public string? BuyerCode { get; set; }

        [Column("SupplierCode")] // 2, 11
        [StringLength(50)]
        public string? SupplierCode { get; set; }

        [Column("DocType")] //12
        [StringLength(50)]
        public string? DocType { get; set; }

        [Column("FILENAME2")]
        [StringLength(255)]
        public string? FileName2 { get; set; }

        [Column("FILENAME3")]
        [StringLength(255)]
        public string? FileName3 { get; set; }

        [Column("PROCESSOR_NAME")]
        [StringLength(255)]
        public string? ProcessorName { get; set; }

        [Column("UPDATE_DATE_INT")]
        public int? UpdateDateInt { get; set; }
    }
}
