using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class WeekButton : MonoBehaviour
{

    public TextAsset csv;

    public void LoadByIndex(int weekNo)
    {
        Debug.Log(Application.dataPath);
        CSVReader.PullFilenames(csv);
        StaticData.BlockNumber = 0;
        StaticData.WeekNo = weekNo;
        StaticData.FormFName = "Logs/" + StaticData.ParticipantID + "_" + StaticData.WeekNo + "_Form_" + DateTime.Now.ToString("dd_MM_yyyy_H_mm") + ".csv";
        StaticData.LogFName = "Logs/" + StaticData.ParticipantID + "_" + StaticData.WeekNo + "_Log_" + DateTime.Now.ToString("dd_MM_yyyy_H_mm") + ".csv";
        //  Removed to elliviate crashes
        //  MailerCheck.makeFile();
        //  MailerCheck.checkForSends();
        makeLogsFolder();
        SceneManager.LoadScene(4);
    }

    private void makeLogsFolder()
    {
        if (System.IO.Directory.Exists(Application.dataPath + "/Logs"))
        {
            Debug.Log("Found logs folder");
        }
        else
        {
            Directory.CreateDirectory(Application.dataPath + "/Logs"); // returns a DirectoryInfo object
            Debug.Log("Created logs folder");
        }

        string date = DateTime.Today.ToString("dd_MM_yyyy");
        CSVWriter.writeStringToCSV("ID:," + StaticData.ParticipantID + ",Date:," + date + "\n", StaticData.LogFName);
        CSVWriter.writeStringToCSV("ID:," + StaticData.ParticipantID + ",Date:," + date + "\n", StaticData.FormFName);
    }
}