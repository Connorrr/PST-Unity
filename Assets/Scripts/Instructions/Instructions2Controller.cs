using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions2Controller : MonoBehaviour
{

    public Component instructionsPanel1;
    public Component imagePanel1;           //  The main image panel with between 1 and 4 images
    public Component imagePanel2;           //  The image panel wich shows a shrunk version on the 9 trial panels
    public Component micPanel;              //  The canvas used to house the mic button
    public Component faceButtonPanel;       //  The panel with the four face buttons that play a mantra

    public Button progressButton;
    public Button micButton;
    public Button faceButton1;
    public Button faceButton2;
    public Button faceButton3;
    public Button faceButton4;

    public Button exitButton;

    public GameObject loadingCircle;

    public AudioSource audioPlayer;

    public Image backgroundImage;

    public Text instructions1;
    public Text instructions2;
    public Text instructions3;
    public Text instructions4;
    public Text instructions5;
    public Text instructions6;
    public Text instructions7;
    public Text instructions8;
    public Text instructions9;
    public Text instructions10;
    public Text instructions11;
    public Text instructions12;
    public Text instructions13;
    public Text instructions14;
    public Text instructions15;
    public Text instructions16;
    public Text instructions17;
    public Text instructions18;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    private int blockNo;

    private bool micActive;

    private int week23AudioNumber;

    private AudioClip recording;
    private float startRecordingTime;

    // Use this for initialization
    void Start()
    {
        week23AudioNumber = 0;
        blockNo = StaticData.BlockNumber;
        setUpScreen();
        progressButton.onClick.AddListener(progressButtonPressed);
        replaceAvatarImage();
        if (StaticData.isDebugMode)
        {
            progressButton.gameObject.SetActive(true);
            
        }
        micActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioPlayer.isPlaying && !progressButton.IsActive())
        {
            if (StaticData.ScreenNo == 25)
            {
                //showMicPanel();
                //micButton.interactable = true;
            }
            else if (StaticData.ScreenNo == 27) { }
            else if (StaticData.ScreenNo == 28) { }
            else
            {
                progressButton.gameObject.SetActive(true);
            }
        }
    }

    // replaces image1 with the selected avatar image
    private void replaceAvatarImage()
    {
        GameObject go = GameObject.FindWithTag("AvatarImage");
        go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatars/" + StaticData.AvatarImageName);
    }

    private void setUpScreen()
    {
        setActivePanel();
        setAudioFile();
    }

    private bool isRecording = false;
    private void micButtonPressed()
    {
        if (!micActive)
        {
            micButton.image.sprite = Resources.Load<Sprite>("mcphoneOn_Img");
            micActive = true;
            if (Microphone.devices.Length > 0)
            {
                startRecording();
            }
        }
        else
        {
            //micButton.image.sprite = Resources.Load<Sprite>("mcphoneOff_Img");
            if (isRecording)
            {
                stopRecording();
            }
            progressButton.gameObject.SetActive(true);
        }
    }

    private void startRecording()
    {
        Debug.Log("Attempting to record");
        isRecording = true;
        //Get the max frequency of a microphone, if it's less than 44100 record at the max frequency, else record at 44100
        int minFreq;
        int maxFreq;
        int freq = 44100;
        Microphone.GetDeviceCaps("", out minFreq, out maxFreq);
        if (maxFreq < 44100)
            freq = maxFreq;

        //Start the recording, the length of 300 gives it a cap of 5 minutes
        recording = Microphone.Start("", false, 300, 44100);
        startRecordingTime = Time.time;
    }

    private void stopRecording()
    {
        //End the recording, then play it
        Microphone.End("");
        micActive = false;
        //Trim the audioclip by the length of the recording
        AudioClip recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
        float[] data = new float[(int)((Time.time - startRecordingTime) * recording.frequency)];
        recording.GetData(data, 0);
        recordingNew.SetData(data, 0);
        this.recording = recordingNew;

        // Save the audio file as a wav file
        string fileName = StaticData.ParticipantID + "_" + StaticData.WeekNo;
        string filePath = SavWav.Save(fileName, recording);
        StaticData.ARecordingPath = filePath;
    }

    // Sets and plays the current audiofile
    private void setAudioFile()
    {
        AudioClip instructionsAudio = getAudioClip();
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
    }

    private AudioClip getAudioClip()
    {
        string filename = "Audio/Instructions1/Week 1 Screen " + StaticData.ScreenNo;
        AudioClip rtrn = Resources.Load<AudioClip>(filename);

        if (StaticData.WeekNo == 2)
        {
            filename = "Audio/Instructions2/Week 2 Screen " + week23AudioNumber;
            rtrn = Resources.Load<AudioClip>(filename);
        }
        if (StaticData.WeekNo == 3)
        {
            filename = "Audio/Instructions3/Week 3 Screen " + week23AudioNumber;
            rtrn = Resources.Load<AudioClip>("Audio/Instructions3/Week 3 Screen " + week23AudioNumber);
        }
        Debug.Log(filename);

        return rtrn;
    }

    public void progressButtonPressed()
    {
        if (micActive)
        {
            micButtonPressed();
        }
        progressToNext();
    }

    //  Sets 4 calm pics for the instructions
    private void setCalmPics()
    {
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(true);
        image4.gameObject.SetActive(true);

        image1.sprite = Resources.Load<Sprite>("Images/Calm/1540");
        image2.sprite = Resources.Load<Sprite>("Images/Calm/1600");
        image3.sprite = Resources.Load<Sprite>("Images/Calm/1602");
        image4.sprite = Resources.Load<Sprite>("Images/Calm/1603");
    }

    //  Sets 4 calm pics for the instructions
    private void setGoodCalmPics()
    {
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(true);
        image4.gameObject.SetActive(true);

        image1.sprite = Resources.Load<Sprite>("Images/Calm/1540");
        image2.sprite = Resources.Load<Sprite>("Images/Good/1710");
        image3.sprite = Resources.Load<Sprite>("Images/Calm/1602");
        image4.sprite = Resources.Load<Sprite>("Images/Good/1920");
    }

    private void deactivateExtraImagesPanels()
    {
        imagePanel1.gameObject.SetActive(false);
        imagePanel2.gameObject.SetActive(false);
        micPanel.gameObject.SetActive(false);
        micButton.gameObject.SetActive(false);
    }

    private void deactivateExtraImages()
    {
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
    }

    private void showMicPanel()
    {
        micButtonPressed();
        progressButton.gameObject.SetActive(true);
        imagePanel1.gameObject.SetActive(false);           //  The main image panel with between 1 and 4 images
        imagePanel2.gameObject.SetActive(false);           //  The image panel wich shows a shrunk version on the 9 trial panels
        micPanel.gameObject.SetActive(true);
        faceButtonPanel.gameObject.SetActive(false);
        micButton.interactable = true;
        micButton.gameObject.SetActive(true);
        //micButton.onClick.AddListener(micButtonPressed);
    }

    //  Shows the 9 panel instead of the main one
    private void show9Panel()
    {
        imagePanel1.gameObject.SetActive(false);
        imagePanel2.gameObject.SetActive(true);
        micPanel.gameObject.SetActive(false);
        faceButtonPanel.gameObject.SetActive(false);
    }

    //  Brings the main panel; back to the front
    private void showMainPanel()
    {
        imagePanel2.gameObject.SetActive(false);
        imagePanel1.gameObject.SetActive(true);
        micPanel.gameObject.SetActive(false);
        faceButtonPanel.gameObject.SetActive(false);
    }

    private void showFaceButtonPanel()
    {
        imagePanel2.gameObject.SetActive(false);
        imagePanel1.gameObject.SetActive(false);
        micPanel.gameObject.SetActive(false);
        faceButtonPanel.gameObject.SetActive(true);

        faceButton1.onClick.AddListener(goodFacePressed);
        faceButton2.onClick.AddListener(calmFacePressed);
        faceButton3.onClick.AddListener(bothFacePressed);
        faceButton4.onClick.AddListener(neverFacePressed);
    }

    private void resetFaceButtonPanel()
    {
        exitButton.gameObject.SetActive(false);
        faceButton1.gameObject.SetActive(true);
        faceButton2.gameObject.SetActive(true);
        faceButton3.gameObject.SetActive(true);
        faceButton4.gameObject.SetActive(true);
    }

    private void goodFacePressed()
    {
        AudioClip instructionsAudio = Resources.Load<AudioClip>("Audio/Mantras/LookForGood");
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
        faceButton1.gameObject.SetActive(false);
        checkToSeeIfAllFacesHaveBeenPressed();
    }

    private void calmFacePressed()
    {
        AudioClip instructionsAudio = Resources.Load<AudioClip>("Audio/Mantras/LookForCalm");
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
        faceButton2.gameObject.SetActive(false);
        checkToSeeIfAllFacesHaveBeenPressed();
    }

    private void bothFacePressed()
    {
        AudioClip instructionsAudio = Resources.Load<AudioClip>("Audio/Mantras/UseBothOptions");
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
        faceButton3.gameObject.SetActive(false);
        checkToSeeIfAllFacesHaveBeenPressed();
    }

    private void neverFacePressed()
    {
        AudioClip instructionsAudio = Resources.Load<AudioClip>("Audio/Mantras/NeverGiveUp");
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
        faceButton4.gameObject.SetActive(false);
        checkToSeeIfAllFacesHaveBeenPressed();
    }

    private void checkToSeeIfAllFacesHaveBeenPressed()
    {
        if (!faceButton4.IsActive() && !faceButton3.IsActive() && !faceButton2.IsActive() && !faceButton1.IsActive())
        {
            progressButton.gameObject.SetActive(true);
        }
    }

        private void setExitButton()
    {
        faceButtonPanel.gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(200f, 200f);
        exitButton.gameObject.SetActive(true);
        exitButton.onClick.AddListener(exitButtonPressed);
    }

    private void exitButtonPressed()
    {
        showSpinner();
        StaticData.isReturnFromEnd = true;
    }

    //  Ending is done from the LoadingCircel object now
    private void showSpinner()
    {
        exitButton.gameObject.SetActive(false);
        loadingCircle.gameObject.SetActive(true);
    }

    //  Set the current Instructions panel
    private void setActivePanel()
    {
        deactivatePanels();
        deactivateExtraImagesPanels();
        switch (StaticData.ScreenNo)
        {
            case 11:
                instructions1.gameObject.SetActive(true);
                week23AudioNumber = 4;
                imagePanel1.gameObject.SetActive(false);
                break;
            case 12:
                instructions2.gameObject.SetActive(true);
                week23AudioNumber = 5;
                break;
            case 13:
                deactivateExtraImages();
                //instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                show9Panel();
                instructions3.gameObject.SetActive(true);
                break;
            case 14:
                instructions4.gameObject.SetActive(true);
                week23AudioNumber = 6;
                break;
            case 15:
                instructions5.gameObject.SetActive(true);
                week23AudioNumber = 7;
                break;
            case 16:
                instructions6.gameObject.SetActive(true);
                week23AudioNumber = 8;
                break;
            case 17:
                instructions7.gameObject.SetActive(true);
                week23AudioNumber = 9;
                break;
            case 18:
                instructions8.gameObject.SetActive(true);
                week23AudioNumber = 10;
                break;
            case 19:
                instructions9.gameObject.SetActive(true);
                week23AudioNumber = 11;
                break;
            case 20:
                instructions10.gameObject.SetActive(true);
                week23AudioNumber = 12;
                break;
            case 21:
                instructions11.gameObject.SetActive(true);
                week23AudioNumber = 13;
                break;
            case 22:
                setCalmPics();
                instructions12.gameObject.SetActive(true);
                week23AudioNumber = 14;
                break;
            case 23:
                setGoodCalmPics();
                instructions13.gameObject.SetActive(true);
                week23AudioNumber = 15;
                break;
            case 24:
                deactivateExtraImages();
                instructions14.gameObject.SetActive(true);
                week23AudioNumber = 16;
                break;
            case 25:
                showMicPanel();
                instructions15.gameObject.SetActive(true);
                week23AudioNumber = 17;
                break;
            case 26:
                showMainPanel();
                instructions16.gameObject.SetActive(true);
                week23AudioNumber = 19;
                break;
            case 27:
                resetFaceButtonPanel();
                showFaceButtonPanel();
                instructions17.gameObject.SetActive(true);
                week23AudioNumber = 20;
                break;
            case 28:
                setExitButton();
                instructions18.gameObject.SetActive(true);
                week23AudioNumber = 21;
                break;
            default:
                Debug.Log("InstructionsController2:setScreenNo: The ScreenNo is out of range");
                break;
        }
    }

    private void progressToNext()
    {
        if (!StaticData.isDebugMode)
        {
            progressButton.gameObject.SetActive(false);
        }
        int sNo = StaticData.ScreenNo;
        StaticData.ScreenNo++;
        if ( sNo == 12 && StaticData.WeekNo != 1)   //  Screen not included in week 2 and 3
        {
            StaticData.ScreenNo++;
            sNo++;
        }
        switch (sNo)
        {
            case 11:
                SceneManager.LoadScene(1);
                break;
            case 12:
                setUpScreen();
                instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                break;
            case 13:
                SceneManager.LoadScene(1);
                break;
            case 14:
                goToGameScene();
                break;
            case 15:

                SceneManager.LoadScene(1);
                break;
            case 16:
                SceneManager.LoadScene(1);
                break;
            case 17:
                SceneManager.LoadScene(1);
                break;
            case 18:
                SceneManager.LoadScene(1);
                break;
            case 19:
                goToGameScene();
                break;
            case 20:
                SceneManager.LoadScene(1);
                break;
            case 21:
                SceneManager.LoadScene(1);
                break;
            case 22:
                setUpScreen();
                instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                break;
            case 23:
                SceneManager.LoadScene(1);
                break;
            case 24:
                setUpScreen();
                instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                break;
            case 25:
                SceneManager.LoadScene(6);
                break;
            case 26:
                setUpScreen();
                //instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                break;
            case 27:
                setUpScreen();
                //instructionsPanel1.GetComponent<Instructions2AvatarGraphicsHandler>().setAvatarImage();
                break;
            case 28:  
                break;
            default:
                Debug.Log("InstructionsController2:setScreenNo: The ScreenNo is out of range");
                break;
        }
    }

    private void goToGameScene()
    {
        if (StaticData.WeekNo == 1)
        {
            SceneManager.LoadScene(9);      // Balloon Game
        }
        else if (StaticData.WeekNo == 2)
        {
            SceneManager.LoadScene(7);      // Falling Emoji Game
        }
        else
        {
            SceneManager.LoadScene(8);      // Memory Game
        }
    }

    //  Deactivate all panels
    private void deactivatePanels()
    {
        instructions1.gameObject.SetActive(false);
        instructions2.gameObject.SetActive(false);
        instructions3.gameObject.SetActive(false);
        instructions4.gameObject.SetActive(false);
        instructions5.gameObject.SetActive(false);
        instructions6.gameObject.SetActive(false);
        instructions7.gameObject.SetActive(false);
        instructions8.gameObject.SetActive(false);
        instructions9.gameObject.SetActive(false);
        instructions10.gameObject.SetActive(false);
        instructions11.gameObject.SetActive(false);
        instructions12.gameObject.SetActive(false);
        instructions13.gameObject.SetActive(false);
        instructions14.gameObject.SetActive(false);
        instructions15.gameObject.SetActive(false);
        instructions16.gameObject.SetActive(false);
        instructions17.gameObject.SetActive(false);
        instructions18.gameObject.SetActive(false);
    }
}
