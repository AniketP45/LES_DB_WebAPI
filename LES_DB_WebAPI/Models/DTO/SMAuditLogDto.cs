namespace LES_DB_WebAPI.Models.DTO
{
    public class SMAuditLogDto
    {
        public string ModuleName { get; set; }
        public string FileName { get; set; }
        public string AuditValue { get; set; }
        public string KeyRef1 { get; set; }
        public string KeyRef2 { get; set; }
        public string LogType { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ServerName { get; set; }
        public string BuyerCode { get; set; }
        public string SupplierCode { get; set; }
        public string DocType { get; set; }
        public string FileName2 { get; set; }
        public string FileName3 { get; set; }
        public string ProcessorName { get; set; }
    }
}
