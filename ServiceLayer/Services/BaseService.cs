using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace ServiceLayer.Services
{
    public class BaseService
    {
        public FacultyAppDataRepository facAppDataRepo;
        public IMapper _mapper;
        public BaseService()
        {
            facAppDataRepo = new FacultyAppDataRepository();            
            _mapper = AutoMapperServiceProfile.Init();
        }
        protected bool SendMail(string toEmailAddr, string subject, string body)
        {
            var isMailSent = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                string fromEmailAddr = "{from email id}";
                string pwd = "{password}";
                mail.From = new MailAddress(fromEmailAddr);
                mail.To.Add(toEmailAddr);
                mail.Subject = subject;
                mail.Body = body;
                mail.Priority = MailPriority.High;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmailAddr, pwd);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                isMailSent = true;
            }
            catch(Exception ex)
            {
                isMailSent = false;
            }
            return isMailSent;
        }
    }
}
