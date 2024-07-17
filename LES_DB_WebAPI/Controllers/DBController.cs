using LES_DB_WebAPI.Data;
using LES_DB_WebAPI.Models;
using LES_DB_WebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LES_DB_WebAPI.Controllers
{
    [Route("api/DB")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DBController> _logger;

        public DBController(AppDbContext context, ILogger<DBController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost("sendmail")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostSendMailQueue(SendMailQueue sendMailQueue)
        {
            if (sendMailQueue == null)
            {
                return BadRequest("SendMailQueue object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SendMailQueues.AddAsync(sendMailQueue);
                await _context.SaveChangesAsync();

                var SendMailQueueDto = new SendMailQueueDto
                {
                    QuotationId = sendMailQueue.QuotationId,
                    QuoteExported = sendMailQueue.QuoteExported,
                    DocType = sendMailQueue.DocType,
                    RefKey = sendMailQueue.RefKey,
                    MailFrom = sendMailQueue.MailFrom,
                    MailTo = sendMailQueue.MailTo,
                    MailCc = sendMailQueue.MailCc,
                    MailBcc = sendMailQueue.MailBcc,
                    MailSubject = sendMailQueue.MailSubject,
                    MailBody = sendMailQueue.MailBody,
                    Attachments = sendMailQueue.Attachments,
                    MailDate = sendMailQueue.MailDate,
                    NotToSend = sendMailQueue.NotToSend,
                    BuyerId = sendMailQueue.BuyerId,
                    SupplierId = sendMailQueue.SupplierId,
                    ReplyEmail = sendMailQueue.ReplyEmail,
                    SenderName = sendMailQueue.SenderName,
                    ReceiverName = sendMailQueue.ReceiverName,
                    ActionType = sendMailQueue.ActionType,
                    HtmlNotToSend = sendMailQueue.HtmlNotToSend,
                    SendHtmlMsg = sendMailQueue.SendHtmlMsg,
                    UseHtmlFileMsg = sendMailQueue.UseHtmlFileMsg,
                    DelayMailMin = sendMailQueue.DelayMailMin,
                    Module = sendMailQueue.Module,
                    SuppRef = sendMailQueue.SuppRef,
                    ByrCode = sendMailQueue.ByrCode,
                    SuppCode = sendMailQueue.SuppCode,
                    ReplyAllEmail = sendMailQueue.ReplyAllEmail,
                    Udf1 = sendMailQueue.Udf1
                };


                return CreatedAtAction(nameof(PostSendMailQueue), SendMailQueueDto);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Error on PostSendMailQueue - " + ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on PostSendMailQueue - " + ex.Message);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPost("auditlog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostAuditLog(SMAuditLog auditLog)
        {
            //_logger.LogInformation("PostAuditLog method called.");

            if (auditLog == null)
            {
                _logger.LogError("AuditLog object is null");
                return BadRequest("AuditLog object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.AuditLogs.AddAsync(auditLog);
                await _context.SaveChangesAsync();
                //_logger.LogInformation("AuditLog object Added to database");


                var auditLogDto = new SMAuditLogDto
                {
                    ModuleName = auditLog.ModuleName,
                    FileName = auditLog.FileName,
                    AuditValue = auditLog.AuditValue,
                    KeyRef1 = auditLog.KeyRef1,
                    KeyRef2 = auditLog.KeyRef2,
                    LogType = auditLog.LogType,
                    UpdateDate = auditLog.UpdateDate,
                    ServerName = auditLog.ServerName,
                    BuyerCode = auditLog.BuyerCode,
                    SupplierCode = auditLog.SupplierCode,
                    DocType = auditLog.DocType,
                    FileName2 = auditLog.FileName2,
                    FileName3 = auditLog.FileName3,
                    ProcessorName = auditLog.ProcessorName
                };




                return CreatedAtAction(nameof(PostAuditLog), auditLogDto);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Error on PostAuditLog - " + ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on PostAuditLog - " + ex.Message);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
