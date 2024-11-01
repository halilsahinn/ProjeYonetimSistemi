﻿#region NAMESPACES
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
#endregion
public class EmailSender
{
    #region FIELDS
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;
    #endregion

    #region CTOR
    public EmailSender(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUser = smtpUser;
        _smtpPass = smtpPass;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("YourAppName", _smtpUser));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;

        emailMessage.Body = new TextPart("html")
        {
            Text = message
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_smtpServer, _smtpPort, false);
            await client.AuthenticateAsync(_smtpUser, _smtpPass);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
#endregion