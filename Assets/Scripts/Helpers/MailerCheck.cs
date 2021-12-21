using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class MailerCheck
{
    private static string fName = "Mailer.csv";
    private static string headers = "Week,Complete,Sent,FormName,LogName,WavName\n";

    public static void makeFile()
    {
        if (!File.Exists(Application.dataPath + "/" + fName))
        {
            //  Week, Completed, Sent
            string contents = headers + "1,0,0,0,0,0\n2,0,0,0,0,0\n3,0,0,0,0,0";
            CSVWriter.writeStringToCSV(contents, fName);
        }
        else
        {
            Debug.Log("Mail check file exists.");
        }
    }

    /// <summary>
    /// Updates the Mailer file with new information 
    /// </summary>
    /// <param name="week">The week we are on</param>
    /// <param name="isComplete">Has the program been finished for the week</param>
    /// <param name="isSent">Has it been successfully sent</param>
    /// <param name="formName">File Name for the form</param>
    /// <param name="logName">File nmae for the logfile</param>
    /// <param name="wavName">Filename for the audio</param>
    public static void updateFile(int week, bool isComplete, bool isSent, string formName, string logName, string wavName)
    {
        string text = File.ReadAllText(Application.dataPath + "/" + fName);
        string[] lines = Regex.Split(text, "\n");
        string[,] cols = new string[3,6];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] col = Regex.Split(lines[i], ",");

            if (col.Length >= 3)
            {
                cols[i - 1, 0] = col[0];
                cols[i - 1, 1] = col[1];
                cols[i - 1, 2] = col[2];
                cols[i - 1, 3] = "0";
                cols[i - 1, 4] = "0";
                cols[i - 1, 5] = "0";

                if (i == week)
                {
                    if (isComplete)
                    {
                        cols[week - 1, 1] = "1";
                    }
                    if (isSent)
                    {
                        cols[week - 1, 2] = "1";
                    }
                    cols[week - 1, 3] = formName;
                    cols[week - 1, 4] = logName;
                    cols[week - 1, 5] = wavName;
                }
            }
        }

        string outputText = headers;
        for (int i = 0; i < cols.GetLength(0); i++)
        {
            outputText += cols[i, 0] + "," + cols[i, 1] + "," + cols[i, 2] + "," + cols[i, 3] + "," + cols[i, 4] + "," + cols[i, 5] + "\n";
        }

        CSVWriter.overwriteStringToCSV(outputText, fName);
    }

    /// <summary>
    /// This function checks the mailer log file to see if there is any pending mail to be sent
    /// </summary>
    public static void checkForSends()
    {
        string text = File.ReadAllText(Application.dataPath + "/" + fName);
        string[] lines = Regex.Split(text, "\n");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] col = Regex.Split(lines[i], ",");

            if (col.Length >= 3)
            {
                if (int.Parse(col[1]) == 1 && int.Parse(col[2]) == 0)
                {
                    Debug.Log("There is pending mail for week " + i);
                    SMTPMailer mail = new SMTPMailer();
                    string[] filePaths = { col[3], col[4], col[5] };
                    mail.Main(filePaths, i);
                }
            }
        }
    }



}
