using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitButtonScript : MonoBehaviour
{

    public Text mainText;
    public Slider keenSlider;
    public Slider mindSlider;
    public Slider enjoySlider;
    public Slider helpfulSlider;

    private bool isPlayingFirstAudio;

    private bool q1Selected;
    private bool q2Selected;
    private bool q3Selected;
    private bool q4Selected;
    private int q1Score;
    private int q2Score;
    private int q3Score;
    private int q4Score;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().interactable = false;
        isPlayingFirstAudio = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayingFirstAudio)
        {
            
        }
    }

    private void setSecondAudio()
    {
        
    }

    /// <summary>
    /// When each of the four questions are answered this function is called.  When the final question is answered the submit button will become interactable.
    /// </summary>
    /// <param name="index">The question index between 1-4</param>
    public void questionAnswered(int index,int score)
    {
        if (index == 1)
        {
            q1Selected = true;
            q1Score = score;
        }else if (index == 2)
        {
            q2Selected = true;
            q2Score = score;
        }
        else if (index == 3)
        {
            q3Selected = true;
            q3Score = score;
        }
        else if (index == 4)
        {
            q4Selected = true;
            q4Score = score;
        }
        else
        {
            Debug.Log("Error: SubmitButtonScript: questionAnswered: Index value should be between 1 and 4: Index = " + index);
        }

        if (q1Selected && q2Selected && q3Selected && q4Selected)
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void onSubmitButtonPress()
    {

        int keenVal = q1Score;
        int mindVal = q2Score;
        int enjoyVal = q3Score;
        int helpfulVal = q4Score;

        string csv = q1Score + "," + q2Score + "," + q3Score + "," + q4Score;
        CSVWriter.writeStringToCSV(csv, StaticData.FormFName);

        //  Depreciated because of bugs
        //  MailerCheck.updateFile(StaticData.WeekNo, true, false, Application.dataPath + "/" + StaticData.FormFName, Application.dataPath + "/" + StaticData.LogFName, StaticData.ARecordingPath);

        //Send Logs and Recording
        SMTPMailer mail = new SMTPMailer();
        string[] filePaths = { StaticData.ARecordingPath, Application.dataPath + "/" + StaticData.FormFName, Application.dataPath + "/" + StaticData.LogFName };
        mail.Main(filePaths, StaticData.WeekNo);

        StaticData.ScreenNo++;

        SceneManager.LoadScene(5);
    }
}
