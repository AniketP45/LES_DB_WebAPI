using LES_DB_WebAPI.Data;
using LES_DB_WebAPI.Models;
using LES_DB_WebAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
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

        public DBController(AppDbContext context)
        {
            _context = context;
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

            setLog("Request recived for - " + sendMailQueue.QuotationId);


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

                setLog("Data saved for - " + sendMailQueue.QuotationId);


                return CreatedAtAction(nameof(PostSendMailQueue), SendMailQueueDto);
            }
            catch (DbUpdateException ex)
            {
                setLog("Error on PostSendMailQueue - " + ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            catch (Exception ex)
            {
                setLog("Error on PostSendMailQueue - " + ex.Message);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPost("auditlog")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostAuditLog(SMAuditLog auditLog)
        {
            setLog("---------------------------------------------");

            if (auditLog == null)
            {
                setLog("AuditLog object is null");
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
                setLog("AuditLog object Added to database");


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

                setLog("Error on PostAuditLog - " + ex.Message +ex.InnerException.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            catch (Exception ex)
            {
                setLog("Error on PostAuditLog - " + ex.Message);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
            finally
            {
                setLog("------------------------------------------");

            }
        }

        public static void setLog(string log)
        {
            try
            {
                LeSDataMain.LeSDM.AddConsoleLog(log);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
