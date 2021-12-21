using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class StimulusButton : MonoBehaviour {

    public StimulusHandler stimHandlerScript;
    public int type;
    public bool is4x4 = false;
    private bool isTarget;
    private Sprite stim;
    private Image i;
    private int numberOfHits = 0;       //The amount of times it is pressed
    private bool isHit = false;
    private string lastSpriteName;
    private Stopwatch timer;

    public AudioSource audioSource;

    public AudioClip AC1;
    public AudioClip AC2;
    public AudioClip AC3;
    public AudioClip AC4;

    private AudioClip clipToPlay;

    public bool isGreatAudio;

    // Use this for initialization
    void Start () {
        //Debug.Log("Started Stim Button");
        //setFile();
        lastSpriteName = "";
        i = GetComponent<Image>();
        timer = Stopwatch.StartNew();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //                  Types
    //                  1 = Angry
    //                  2 = Calm
    //                  3 = Good
    //                  4 = Happy 
    //                  5 = Mild
    //                  6 = Negative
    //                  7 = Positive
    //                  8 = Severe
    public void SetStimulus(string spriteName, bool isTarget, int type, List<string> excludedNames)
    {
        string newSpriteName = spriteName;
        if (newSpriteName == lastSpriteName )
        {
            //  This part is to avoid images going back to back in the one spot but there is a small chance that 
            //  this will create a double up in the trial since two or more images will be double ups and the next 
            //  stim object wont update the excluded names.
            newSpriteName = CSVReader.GetImageFileName(excludedNames, type);
        }
        //Debug.Log("SpriteName: " + newSpriteName);
        stim = Resources.Load<Sprite>(spriteName);
        if ( i == null)     // In the 4x4 trials, because the stim is disabled on start the SetStimulus function can be called before Start
        {
            i = GetComponent<Image>();
            timer = Stopwatch.StartNew();
        }
        i.sprite = stim;
        this.isTarget = isTarget;
        this.type = type;
        lastSpriteName = newSpriteName;
        numberOfHits = 0;
        isHit = false;
        timer.Reset();
        timer.Start();
    }

    private static readonly System.Random random = new System.Random();
    private static readonly object syncLock = new object();
    public static int RandomNumber(int min, int max)
    {
        lock (syncLock)
        { // synchronize
            return random.Next(min, max);
        }
    }

    public void setAudioFile(bool isGreatAudio)     //  Audio clips set in th stimulus handler script
    {
        
        if (isGreatAudio)  
        {
            clipToPlay = AC4;
        }
        else
        {
            clipToPlay = AC1;
        }
    }

    // Sets and plays the current audiofile
    private void setFile()
    {

        audioSource.clip = AC1;
        if (isGreatAudio)
        {
            audioSource.clip = AC4;
        }
        //else if (val == 4)
        //{
        //    audioSource.clip = AC4;
        //}  *** Removed because it was annoying
        //UnityEngine.Debug.Log("This is the val: " + val);
    }

    public void StimPressed()
    {
        audioSource.clip = clipToPlay;  //  Set clip here so that it doesn't cut off previous sound
        stimHandlerScript.clickCount++;
        if (isTarget)
        {
            audioSource.Play(0);
        }
        if ( !isHit )
        {
            isHit = true;
            timer.Stop();
            numberOfHits++;
            if (isTarget)
            {
                StaticData.SelectionCount++;
                if (StaticData.Selections == StaticData.SelectionCount)
                {
                    stimHandlerScript.RT = timer.ElapsedMilliseconds;
                    stimHandlerScript.proceedToNextTrial();
                }
            }
        }
    }
}
