using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LES_DB_WebAPI.Models
{
    [Table("SM_SEND_MAIL_QUEUE")]
    public class SendMailQueue
    {
        [Key]
        [Column("QUEUE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QueueId { get; set; }

        [Column("QUOTATIONID")]
        public int? QuotationId { get; set; }

        [Column("QUOTE_EXPORTED")]
        public int? QuoteExported { get; set; }

        [Column("DOC_TYPE")]
        [StringLength(50)]
        public string DocType { get; set; }

        [Column("REF_KEY")]
        [StringLength(150)]
        public string RefKey { get; set; }

        [Column("MAIL_FROM")]
        [StringLength(100)]
        public string MailFrom { get; set; }

        [Column("MAIL_TO")]
        [StringLength(500)]
        public string MailTo { get; set; }

        [Column("MAIL_CC")]
        [StringLength(500)]
        public string MailCc { get; set; }

        [Column("MAIL_BCC")]
        [StringLength(500)]
        public string MailBcc { get; set; }

        [Column("MAIL_SUBJECT")]
        public string MailSubject { get; set; }

        [Column("MAIL_BODY")]
        public string MailBody { get; set; }

        [Column("ATTACHMENTS")]
        public string Attachments { get; set; }

        [Column("MAIL_DATE")]
        public DateTime? MailDate { get; set; }

        [Column("NOT_TO_SENT")]
        public byte? NotToSend { get; set; }

        [Column("BUYER_ID")]
        public int? BuyerId { get; set; }

        [Column("SUPPLIER_ID")]
        public int? SupplierId { get; set; }

        [Column("REPLY_EMAIL")]
        [StringLength(100)]
        public string ReplyEmail { get; set; }

        [Column("SENDER_NAME")]
        [StringLength(200)]
        public string SenderName { get; set; }

        [Column("RECEIVER_NAME")]
        [StringLength(200)]
        public string ReceiverName { get; set; }

        [Column("ACTION_TYPE")]
        [StringLength(50)]
        public string ActionType { get; set; }

        [Column("HTML_NOT_TO_SEND")]
        public int? HtmlNotToSend { get; set; }

        [Column("SEND_HTML_MSG")]
        public int? SendHtmlMsg { get; set; }

        [Column("USE_HTML_FILE_MSG")]
        public int? UseHtmlFileMsg { get; set; }

        [Column("DELAY_MAIL_MIN")]
        public int? DelayMailMin { get; set; }

        [Column("MODULE")]
        [StringLength(50)]
        public string Module { get; set; }

        [Column("SUPP_REF")]
        [StringLength(50)]
        public string SuppRef { get; set; }

        [Column("BYR_CODE")]
        [StringLength(50)]
        public string ByrCode { get; set; }

        [Column("SUPP_CODE")]
        [StringLength(50)]
        public string SuppCode { get; set; }

        [Column("TIME_STAMP")]
        [StringLength(50)]
        public string TimeStamp { get; set; }

        [Column("REPLY_ALL_EMAIL")]
        [StringLength(50)]
        public string ReplyAllEmail { get; set; }

        [Column("UDF1")]
        [StringLength(20)]
        public string Udf1 { get; set; }
    }
}
