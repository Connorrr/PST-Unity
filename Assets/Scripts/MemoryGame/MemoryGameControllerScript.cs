using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MemoryGameControllerScript : MonoBehaviour
{

    public MemoryButtonScript memoryButton;
    public Canvas mainDisplayImageCanvas;
    public Canvas buttonImageCanvas;
    public Text scoreText;
    public AudioSource audioSource;
    public Canvas finalScoreCanvas;
    public Text finalScoreText;

    private int score;
    private int numberOfImages;
    private int currentImage;
    private int level;
    private int finalLevel = 12;
    private int phase;                                      // 1:  show images, 2:  questionmarks and buttons displayed
    private List<MemoryButtonScript> displayImages;
    private List<MemoryButtonScript> buttonImages;
    private bool wasFirstClick;
    private float phase1Timer;
    private int clickCount;
    private bool isStartWait;
    private float startWait;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        score = 0;
        level = 1;
        isStartWait = true;
        startWait = 0.5f;
        resetVariables();
    }

    // Update is called once per frame
    void Update()
    {
            if (!isStartWait)
            {
                if (phase == 1)
                {
                    phase1Timer -= Time.deltaTime;
                    if (phase1Timer < 0)
                    {
                        phase = 2;
                        startPhaseTwo();
                    }
                }
            }
            else
            {
                startWait -= Time.deltaTime;
                if (startWait < 0)
                {
                    isStartWait = false;
                    startWait = 0.5f;
                    startLevel();
                }
            }
    }

    private void resetVariables()
    {
        numberOfImages = 2;
        currentImage = 0;
        phase = 1;
        wasFirstClick = true;
        phase1Timer = 3f;
        clickCount = 0;
        displayImages = new List<MemoryButtonScript>();
        buttonImages = new List<MemoryButtonScript>();
    }

    private void startLevel()
    {
        setScore();

        System.Random rnd = new System.Random();
        List<int> targetImageNums = new List<int>();

        if ( level < 6)
        {
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
        }else if( level < 11)
        {
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
        }
        else
        {
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
            targetImageNums.Add(addDisplayImage(targetImageNums));
        }
    }

    private void startPhaseTwo()
    {
        List<bool> isTargetList = new List<bool>();
        List<int> order = new List<int>();
        List<int> distractorImageAddresses = new List<int>();

        for (int i = 0; i < displayImages.Count; i++)
        {
            displayImages[i].setAsQuestionMark();
            order.Add(i);
        }
        order.Shuffle();

        if (level < 6)
        {
            Debug.Log("Level < 6");
            isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(false);
            isTargetList.Shuffle();
        }else if (level < 11)
        {
            Debug.Log("Level < 11");
            isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(false);
            isTargetList.Shuffle();
        }
        else
        {
            Debug.Log("Level > 11");
            isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(true); isTargetList.Add(false);
            isTargetList.Shuffle();
        }

        int orderAddress = 0;
        for ( int i = 0; i < isTargetList.Count; i++)
        {
            if (isTargetList[i])
            {
               Sprite image = displayImages[order[orderAddress]].memorySprite;
               addImageButton(true, image, order[orderAddress]);
               orderAddress++;
            }
            else
            {
               Sprite image = getSprite(false, RandomNumbers.getRandomNumberExcludingWRand(rnd, 1, 17, distractorImageAddresses));
               addImageButton(true, image, -1);
            }
        }

    }

    private void addImageButton(bool isTarget, Sprite image, int order)
    {
        buttonImages.Add(getMemoryButton(true, isTarget, image, order));
    }

    private int addDisplayImage(List<int>imageNums)
    {

        int randomImageNumber = RandomNumbers.getRandomNumberExcludingWRand(rnd, 1, 37, imageNums);
        displayImages.Add(getMemoryButton(false, true, getSprite(true, randomImageNumber)));

        return randomImageNumber;
    }

    private MemoryButtonScript getMemoryButton(bool isButton, bool isTarget, Sprite image, int order = -1)
    {
        MemoryButtonScript memoryButtonClone;
        if (isButton)
        {
            memoryButtonClone = Instantiate(memoryButton, buttonImageCanvas.transform);
            memoryButtonClone.isTarget = isTarget;
            memoryButtonClone.memorySprite = image;
            memoryButtonClone.parentController = this;
            memoryButtonClone.setAsMemoryButton(order);
        }
        else
        {
            memoryButtonClone = Instantiate(memoryButton, mainDisplayImageCanvas.transform);
            memoryButtonClone.isTarget = isTarget;
            memoryButtonClone.memorySprite = image;
            memoryButtonClone.setAsDisplayImage();
        }
        memoryButtonClone.setImage();


        return memoryButtonClone;
    }

    private Sprite getSprite(bool isTarget, int imageNum)
    {
        Sprite image;
        if (isTarget)
        {
            image = Resources.Load<Sprite>("Images/Emoji/Image" + imageNum);
        }
        else
        {
            image = Resources.Load<Sprite>("Images/Negative/Image" + imageNum);
        }
        return image;
    }

    private void endLevel()
    {
        level++;
        StartCoroutine(waitDestroyAllEmojis());
    }

    private IEnumerator waitDestroyAllEmojis()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < displayImages.Count; i++)
        {
            displayImages[i].destroyMe();
        }

        for (int i = 0; i < buttonImages.Count; i++)
        {
            buttonImages[i].destroyMe();
        }

        if ( level > finalLevel)
        {
            finishGame();
        }
        else
        {
            resetVariables();
            isStartWait = true;
        }
    }

    public bool correctImageSelected(int imageNum)
    {
        bool isCorrect;
        if ( currentImage == imageNum )
        {
            displayImages[currentImage].setAsDisplayImage();
            currentImage++;
            isCorrect = true;
            audioSource.Play();
            if (currentImage == displayImages.Count)
            {
                endLevel();
            }
            if (wasFirstClick)
            {
                score += 1;
                setScore();
            }
            wasFirstClick = true;
        }
        else
        {
            displayImages[currentImage].setAsTryAgain();
            wasFirstClick = false;
            isCorrect = false;
        }

        return isCorrect;
    }

    public void incorrectImageSelected()
    {
        displayImages[currentImage].setAsTryAgain();
        wasFirstClick = false;
    }

    private void setScore()
    {
        scoreText.text = "Score:  " + score + "\nGame: " + level;
    }

    private void finishGame()
    {
        finalScoreText.text = "Congratulations!  \nYou finished with a score of " + score + "!";
        finalScoreCanvas.gameObject.SetActive(true);
        StartCoroutine(goToInstructions());
    }

    private IEnumerator goToInstructions()
    {
        yield return new WaitForSeconds(4.5f);
        CSVWriter.writeStringToCSV(score.ToString() + "\n", StaticData.LogFName);
        SceneManager.LoadScene(5);
    }
}
