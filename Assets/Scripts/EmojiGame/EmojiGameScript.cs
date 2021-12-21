using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmojiGameScript : MonoBehaviour
{

    public Text scoreText;
    public EmojiScript emoji;
    public GameObject finalTextCanvas;
    public Text finalText;
    public Button startButton;
    public AudioSource hitSound;

    private int score;
    private int hits;
    private int emojiCount;
    private int miss;
    private float secondsFloor;     //  Value that is adjusted at the end of each second.  Used to update timer text.
    private float mainTimer;
    private float waitTime;
    private float maxWaitTime;
    private float minWaitTime;
    private bool hasFinished;
    private bool hasStarted;
    private System.Random rnd;
    private float[] firstDropTimes = { 0.7f, 0.8f, 1f, 1.6f };
    private string timeString = "";
    private List<float> dropTimes = new List<float>{ 3.00f, 1.28f, 0.87f, 1.81f, 1.63f, 0.74f, 1.42f, 1.04f, 0.62f, 0.61f, 0.69f, 0.60f, 0.69f, 0.65f, 0.68f, 0.66f, 0.66f, 0.66f, 0.61f, 0.61f, 0.61f, 0.61f, 0.61f, 0.64f, 0.61f, 0.61f, 0.64f, 0.61f, 0.64f, 0.60f };
    private List<bool> stimType = new List<bool> { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    private List<int> lanes = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
    // Start is called before the first frame update

    void Start()
    {
        stimType.Shuffle();
        firstDropTimes.Shuffle();
        buildLanesList();
        score = 0;
        hits = 0;
        miss = 0;
        emojiCount = 0;
        waitTime = 4f;
        minWaitTime = 0.6f;
        maxWaitTime = waitTime;
        mainTimer = 30f + waitTime;
        secondsFloor = mainTimer;
        hasFinished = false;
        hasStarted = false;
        rnd = new System.Random();
        setFinalScoreSize();
        startButton.onClick.AddListener(startButtonPressed);
        setTextSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            System.Random rnd = new System.Random();
            waitTime -= Time.deltaTime;
            mainTimer -= Time.deltaTime;
            if (!hasFinished)
            {
                if (waitTime < 0)
                {
                    maxWaitTime -= 0.25f;
                    if (maxWaitTime < 0.7f)
                    {
                        maxWaitTime = 0.7f;
                    }
                    //waitTime = ((float)rnd.NextDouble() * (maxWaitTime - minWaitTime)) + minWaitTime;
                    if (emojiCount < 4)
                    {
                        addEmoji(true);
                        waitTime = firstDropTimes[emojiCount - 1];
                    }
                    else
                    {
                        if (stimType.Count > 0)
                        {
                            addEmoji(stimType[0]);
                            waitTime = dropTimes[0];
                            dropTimes.RemoveAt(0);
                            stimType.RemoveAt(0);
                            //timeString += string.Format("{0:0.00}", waitTime) + ",";
                        }
                    }
                }
                if (mainTimer < secondsFloor - 1)
                {
                    secondsFloor -= 1f;
                    updateText();
                }
            }
            if (mainTimer < 0)
            {
                showFinalText();
                hasFinished = true;
                //Debug.Log(timeString);
            }
        }
    }

    private void startButtonPressed()
    {
        hasStarted = true;
        hitSound.Play();
        startButton.gameObject.SetActive(false);
        addEmoji(true);
        waitTime = firstDropTimes[emojiCount - 1];
    }

    private void addEmoji(bool isTarget)
    {
        EmojiScript emojiClone = Instantiate(emoji, this.transform);
        Vector3 pos = emojiClone.transform.position;
        float emojiWidth = GetComponent<RectTransform>().rect.width / 7;            // 7 emojies can fit horizontally on the screen
        emojiClone.GetComponent<RectTransform>().sizeDelta = new Vector2(emojiWidth, emojiWidth);
        pos.x = getRandomXPosition(emojiClone.GetComponent<RectTransform>().rect.width, rnd);
        pos.y = getRandomYPosition(emojiClone.GetComponent<RectTransform>().rect.height, pos.y, rnd);
        emojiClone.transform.position = pos;
        emojiClone.isTarget = isTarget;
        emojiClone.GetComponent<Rigidbody2D>().gravityScale = rnd.Next(10, 15);
        emojiCount++;
    }

    private float getRandomXPosition(float emojiWidth, System.Random rnd)
    {
        if (lanes.Count <= 0)
        {
            buildLanesList();
        }

        float rtrn = 0;
        float width = this.gameObject.GetComponent<RectTransform>().rect.width;
        rtrn = (((float)lanes[0] - 1) *  emojiWidth) + emojiWidth/2;
        lanes.RemoveAt(0);
        return rtrn;
    }

    private float getRandomYPosition(float emojiHeight, float startY, System.Random rnd)
    {
        float rtrn = 0;
        float width = this.gameObject.GetComponent<RectTransform>().rect.width;
        rtrn = startY + ((float)rnd.NextDouble() * emojiHeight * 3);
        return rtrn;
    }

    private void buildLanesList()
    {
        List<int> first = new List<int> { 1, 2, 3 };
        List<int> second = new List<int> { 4, 5, 6, 7 };
        first.Shuffle();
        second.Shuffle();

        lanes = new List<int> { first[0], first[1], first[2], second[0], second[1], second[2], second[3] };
    } 

    private bool randomBool(System.Random rnd)
    {
        bool rtrn = false;
        if ( rnd.Next(2) == 0)
        {
            rtrn = true;
        }
        return rtrn;
    }

    private void setTextSize()
    {
        float canvasWidth = this.gameObject.GetComponent<RectTransform>().rect.width;
        float canvasHeight = this.gameObject.GetComponent<RectTransform>().rect.height;
        scoreText.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasWidth/4, canvasHeight/3);
    }

    public void incrimentMiss()
    {
        miss += 1;
        updateText();
    }

    public void incrimentHit()
    {
        score += 10;
        hits += 1;
        updateText();
    }

    private void setFinalScoreSize()
    {
        float canvasWidth = this.gameObject.GetComponent<RectTransform>().rect.width;
        float canvasHeight = this.gameObject.GetComponent<RectTransform>().rect.height;
        finalTextCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasWidth/2, canvasHeight/2);
    }

    private void showFinalText()
    {
        finalText.text = "Congratulations!  You got " + hits + " faces for " + score + " points!";
        finalTextCanvas.gameObject.SetActive(true);
        StartCoroutine(goToInstructions());
    }

    private void updateText()
    {
        scoreText.text = "Time: " + (int)secondsFloor + "\nScore:  " + score + "\nHits: " + hits + "\nMiss: " + miss;
    }

    private IEnumerator goToInstructions()
    {
        yield return new WaitForSeconds(2.5f);
        CSVWriter.writeStringToCSV("Hits: " + hits + ",Miss: " + miss + ",Score: " + score + "\n", StaticData.LogFName);
        SceneManager.LoadScene(5);
    }
}
