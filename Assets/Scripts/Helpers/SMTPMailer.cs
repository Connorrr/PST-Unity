using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

public class SMTPMailer
{
    static bool mailSent = false;
    private static int week;

    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        // Get the unique identifier for this asynchronous operation.
        String token = (string)e.UserState;
        
        if (e.Cancelled)
        {
            Debug.Log("Send canceled: " + token);
        }
        if (e.Error != null)
        {
            Debug.Log(token + " " + e.Error.ToString());
        }
        else
        {
            Debug.Log("Message sent.");
            //  Mailer check depreciated
            //  MailerCheck.updateFile(week, true, true, Application.dataPath + "/" + StaticData.FormFName, Application.dataPath + "/" + StaticData.LogFName, StaticData.ARecordingPath);
            week = 0;
        }
        mailSent = true;
        StaticData.isSendingMail = false;
    }

    public void Main(String[] filePaths, int weekNo)
    {
        StaticData.isSendingMail = true;
        MailMessage mail = new MailMessage();

        week = weekNo;

        mail.From = new MailAddress("pst@griffithpsychapps.com");
        mail.To.Add("connor.reid87@gmail.com,acats@griffith.edu.au");
        mail.Subject = "PST Logs Test";
        mail.Body = "Logs for participant " + StaticData.ParticipantID;

        for (int i = 0; i < filePaths.Length; i++)
        {
            if (filePaths[i] != null && !filePaths[i].Equals(""))
            {
                if (File.Exists(filePaths[i]))
                {
                    mail.Attachments.Add(new Attachment(filePaths[i]));
                }
                else
                {
                    Debug.Log("SMTPMailer: Main: File does not exist: " + filePaths[i]);
                }
            }
            else
            {
                Debug.Log("SMTPMailer: Main: File null or empty: " + filePaths[i]);
            }
        }

        SmtpClient smtpServer = new SmtpClient("mail2.qnetau.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("pst@griffithpsychapps.com", "Phadmuska69") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);

        string userState = "Message Token";
        smtpServer.SendAsync(mail, userState);

    }
}