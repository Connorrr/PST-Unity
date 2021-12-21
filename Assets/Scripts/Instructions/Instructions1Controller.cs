using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions1Controller : MonoBehaviour {

    public Component instructionsPanel1;
    public Component instructionsPanel2;
    public Component instructionsPanel3;
    public Component instructionsPanel4;
    public Component instructionsPanel5;
    public Component instructionsPanel6;
    public Component instructionsPanel7;
    public Component instructionsPanel8;
    public Component instructionsPanel9;
    public Component instructionsPanel10;

    public Component instructionPanelPrefab;

    public Button progressButton;

    public AudioSource audioPlayer;

    private Image avatarImage;

    private int progress;

    private int weekNo;
    
    // Use this for initialization
    void Start () {
        weekNo = StaticData.WeekNo;
        replaceAvatarImage();
        progress = 1;
        setAudioFile(); 
        progressButton.onClick.AddListener(progressButtonPressed);
        if (StaticData.isDebugMode)
        {
            progressButton.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!audioPlayer.isPlaying && !progressButton.IsActive())
        {
            Debug.Log("Finished Playing");
            progressButton.gameObject.SetActive(true);
        }
    }

    // replaces image1 with the selected avatar image
    private void replaceAvatarImage()
    {
        GameObject go = GameObject.FindWithTag("AvatarImage");
        avatarImage = go.GetComponent<Image>();
        avatarImage.sprite = Resources.Load<Sprite>("Images/Avatars/" + StaticData.AvatarImageName);
    }

    // Sets and plays the current audiofile
    private void setAudioFile()
    {
        AudioClip instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions1/Week 1 Screen " + progress.ToString());
        if (weekNo == 1)
        {
            instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions1/Week 1 Screen " + progress.ToString());
        }
        else
        {
            if (progress == 1)
            {
                instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions" + weekNo + "/Week " + weekNo + " Screen 1");
            }
            else if (progress == 5)
            {
                instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions" + weekNo + "/Week " + weekNo + " Screen 2");
            }
            else if (progress == 10)
            {
                instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions" + weekNo + "/Week " + weekNo + " Screen 3");
            }
        }

        if (weekNo == 1 && StaticData.isV2 && progress == 1)
        {
            instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions" + weekNo + "/Week 1 Screen 1 V2");
        }

        if (weekNo == 1 && StaticData.isV2 && progress == 2)
        {
            instructionsAudio = Resources.Load<AudioClip>("Audio/Instructions" + weekNo + "/Week 1 Screen 2 V2");
        }
        audioPlayer.clip = instructionsAudio;
        audioPlayer.Play(0);
    }

    public void progressButtonPressed()
    {
        progress = setProgress(progress);

        if (!StaticData.isDebugMode)
        {
            progressButton.gameObject.SetActive(false);
        }
        setActivePanel();
        setAudioFile();
    }

    private int setProgress(int prog)
    {
        int rtrn;

        if (weekNo == 1)
        {
            rtrn = prog + 1;
        }
        else
        {
            if (prog == 1)
            {
                rtrn = 5;
            }
            else if (prog == 5)
            {
                rtrn = 10;
            }
            else
            {
                rtrn = 11;
            }
        }

        return rtrn;
    }

    //  Set the current Instructions panel
    private void setActivePanel()
    {
        deactivatePanels();
        switch (progress)
        {
            case 1:
                instructionsPanel1.gameObject.SetActive(true);
                break;
            case 2:
                instructionsPanel2.gameObject.SetActive(true);
                break;
            case 3:
                instructionsPanel3.gameObject.SetActive(true);
                break;
            case 4:
                instructionsPanel4.gameObject.SetActive(true);
                break;
            case 5:
                instructionsPanel5.gameObject.SetActive(true);
                replaceAvatarImage();
                break;
            case 6:
                instructionsPanel6.gameObject.SetActive(true);
                replaceAvatarImage();
                break;
            case 7:
                instructionsPanel7.gameObject.SetActive(true);
                break;
            case 8:
                instructionsPanel8.gameObject.SetActive(true);
                break;
            case 9:
                instructionsPanel9.gameObject.SetActive(true);
                break;
            case 10:
                instructionsPanel10.gameObject.SetActive(true);
                replaceAvatarImage();
                break;
            case 11:
                StaticData.ScreenNo = 11;
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("Progress value outside of limits: " + progress);
                break;
        }
    }

    //  Deactivate all panels
    private void deactivatePanels()
    {
        instructionsPanel1.gameObject.SetActive(false);
        instructionsPanel2.gameObject.SetActive(false);
        instructionsPanel3.gameObject.SetActive(false);
        instructionsPanel4.gameObject.SetActive(false);
        instructionsPanel5.gameObject.SetActive(false);
        instructionsPanel6.gameObject.SetActive(false);
        instructionsPanel7.gameObject.SetActive(false);
        instructionsPanel8.gameObject.SetActive(false);
        instructionsPanel9.gameObject.SetActive(false);
        instructionsPanel10.gameObject.SetActive(false);
    }
}
