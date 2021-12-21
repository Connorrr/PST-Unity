using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class StimulusHandler : MonoBehaviour {

    public long RT;
    public int clickCount;

    public Text progressText;
    public Canvas background;

    public Button topLeftStim;
    public Button topMidStim;
    public Button topRightStim;
    public Button midLeftStim;
    public Button midMidStim;
    public Button midRightStim;
    public Button botLeftStim;
    public Button botMidStim;
    public Button botRightStim;
    // 4x4 Stim
    public Button stim10;
    public Button stim11;
    public Button stim12;
    public Button stim13;
    public Button stim14;
    public Button stim15;
    public Button stim16;

    public TextAsset csv;

    public bool unitTest = false;
    public int unitTestWeek = 0;
    public int unitTestBlock = 0;

    private StimulusButton _topLeftStimScript;
    private StimulusButton _topMidStimScript;
    private StimulusButton _topRightStimScript;
    private StimulusButton _midLeftStimScript;
    private StimulusButton _midMidStimScript;
    private StimulusButton _midRightStimScript;
    private StimulusButton _botLeftStimScript;
    private StimulusButton _botMidStimScript;
    private StimulusButton _botRightStimScript;
    // 4x4 Stim
    private StimulusButton stim10Script;
    private StimulusButton stim11Script;
    private StimulusButton stim12Script;
    private StimulusButton stim13Script;
    private StimulusButton stim14Script;
    private StimulusButton stim15Script;
    private StimulusButton stim16Script;

    //  Log file variables
    private int trialTargetType = 0;
    private int trialDistractorType = 0;
    private int trialNumTargets = 0;
    private int trialMatrixType = 0;

    private GridLayoutGroup StimUIGrouping;

    private int blockNo;
    private int[,] block = new int[9, 3];       // num targets, target type, distractor type
    private int[] spacingType;
    private int[,] block9 = new int[9, 4];      // target type1, target type 2, distractor type, numStimulus
    private int trialNo = 0;

    private float gap;                          //  Gap between stim

    private int clickAudioChange;               //  This is the trial number for which the click audio will change fring the bell to "Great!"

    // Use this for initialization
    void Start () {
        //Debug.Log("Start");

        if (unitTest)
        {
            unitTestSetup();
        }

        blockNo = StaticData.BlockNumber;
        //blockNo = 9;

        StimUIGrouping = this.GetComponent<GridLayoutGroup>();

        _topLeftStimScript = topLeftStim.GetComponent<StimulusButton>();
        _topMidStimScript = topMidStim.GetComponent<StimulusButton>();
        _topRightStimScript = topRightStim.GetComponent<StimulusButton>();
        _midLeftStimScript = midLeftStim.GetComponent<StimulusButton>();
        _midMidStimScript = midMidStim.GetComponent<StimulusButton>();
        _midRightStimScript = midRightStim.GetComponent<StimulusButton>();
        _botLeftStimScript = botLeftStim.GetComponent<StimulusButton>();
        _botMidStimScript = botMidStim.GetComponent<StimulusButton>();
        _botRightStimScript = botRightStim.GetComponent<StimulusButton>();
        // 4x4 Stim
        stim10Script = stim10.GetComponent<StimulusButton>();
        stim11Script = stim11.GetComponent<StimulusButton>();
        stim12Script = stim12.GetComponent<StimulusButton>();
        stim13Script = stim13.GetComponent<StimulusButton>();
        stim14Script = stim14.GetComponent<StimulusButton>();
        stim15Script = stim15.GetComponent<StimulusButton>();
        stim16Script = stim16.GetComponent<StimulusButton>();

        _topLeftStimScript.stimHandlerScript = this;
        _topMidStimScript.stimHandlerScript = this;
        _topRightStimScript.stimHandlerScript = this;
        _midLeftStimScript.stimHandlerScript = this;
        _midMidStimScript.stimHandlerScript = this;
        _midRightStimScript.stimHandlerScript = this;
        _botLeftStimScript.stimHandlerScript = this;
        _botMidStimScript.stimHandlerScript = this;
        _botRightStimScript.stimHandlerScript = this;
        stim10Script.stimHandlerScript = this;
        stim11Script.stimHandlerScript = this;
        stim12Script.stimHandlerScript = this;
        stim13Script.stimHandlerScript = this;
        stim14Script.stimHandlerScript = this;
        stim15Script.stimHandlerScript = this;
        stim16Script.stimHandlerScript = this;

        //Debug.Log("Setting Spacing");
        //setStimSpacing();
        //Debug.Log("Setting Background");
        setBackground();

        sortRandomPositions();

        StaticData.Selections = 1;
        //Debug.Log("PullingFilenames");
        //CSVReader.PullFilenames(csv);

        //Debug.Log("Init Block");
        initBlock();

        System.Random rnd = new System.Random();
        clickAudioChange = rnd.Next(block.GetLength(0));
        printBlock();
        proceedToNextTrial();

    }

    //  Sets the background for the trial
    private void setBackground()
    {
        //String bgName = "BG" + (blockNo+1).ToString();
        //Sprite newBackground = Resources.Load<Sprite>(bgName);
        
        switch (blockNo + 1)
        {
            case 1:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 74, 74, 255);
                break;
            case 2:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 151, 0, 255);
                break;
            case 3:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 98, 255);
                break;
            case 4:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(59, 212, 21, 255);
                break;
            case 5:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(62, 152, 200, 255);
                break;
            case 6:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(122, 39, 198, 255);
                break;
            case 7:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(224, 23, 200, 255);
                break;
            case 8:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(159, 73, 111, 255);
                break;
            case 9:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(164, 164, 164, 255);
                break;
            case 10:
                background.GetComponent<UnityEngine.UI.Image>().color = new Color32(210, 40, 37, 255);
                break;
            default:
                Debug.Log("No setting for this block");
                break;
        }
    }

    private void setTrialAudio(bool isGreatAudio)
    {
        _topLeftStimScript.setAudioFile(isGreatAudio);
        _topMidStimScript.setAudioFile(isGreatAudio);
        _topRightStimScript.setAudioFile(isGreatAudio);
        _midLeftStimScript.setAudioFile(isGreatAudio);
        _midMidStimScript.setAudioFile(isGreatAudio);
        _midRightStimScript.setAudioFile(isGreatAudio);
        _botLeftStimScript.setAudioFile(isGreatAudio);
        _botMidStimScript.setAudioFile(isGreatAudio);
        _botRightStimScript.setAudioFile(isGreatAudio);
        stim10Script.setAudioFile(isGreatAudio);
        stim11Script.setAudioFile(isGreatAudio);
        stim12Script.setAudioFile(isGreatAudio);
        stim13Script.setAudioFile(isGreatAudio);
        stim14Script.setAudioFile(isGreatAudio);
        stim15Script.setAudioFile(isGreatAudio);
        stim16Script.setAudioFile(isGreatAudio);
    }

    // Sets the spacing of the stim inside the container
    private void setStimSpacing()
    {
        //spacingType
        if (spacingType[trialNo-1] == 2)
        {
            gap = StaticData.SpreadSpacing;
            StimUIGrouping.spacing = new Vector2(gap, gap);
            StaticData.isSpread = true;
        }
        else if (spacingType[trialNo-1] == 1)
        {
            gap = StaticData.NarrowSpacing;
            StimUIGrouping.spacing = new Vector2(gap, gap);
            StaticData.isSpread = false;
        }
    }

    // Update is called once per frame
    void Update () {

    }
    private List<Vector3> randomPositions;
    private float cellSize;

    //  Sorts the possible positions for a random scatter trial
    private void sortRandomPositions()
    {
        randomPositions = new List<Vector3>();
        RectTransform canvas = this.GetComponent<RectTransform>();
        System.Random rng = new System.Random();
        float width = canvas.rect.width;
        float height = canvas.rect.height;
        cellSize = StaticData.gridCellSize;
        float newGap = StaticData.SpreadSpacing;
        float step = cellSize + newGap;
        for (float i = 0; i < height; i += step)      //  Traverse the height of the screen cell by cell
        {
            for (float j = 0; j < width; j += step)      //  Traverse the width of the screen cell by cell
            {
                float driftY = ((float)rng.NextDouble() * newGap) - (newGap / 2);
                float driftX = ((float)rng.NextDouble() * newGap) - (newGap / 2);
                randomPositions.Add(new Vector3(i + (cellSize / 2) + driftX, (j + (cellSize / 2)) + driftY, 0.0f));
            }
        }
    }

    /// <summary>
    /// This function is only called when the the trial is a random position trial.
    /// </summary>
    private void setCellRandomPositions()
    {
        randomPositions.Shuffle();

        applyRandomPositions(topLeftStim, cellSize, 0);
        applyRandomPositions(topMidStim, cellSize, 1);
        applyRandomPositions(topRightStim, cellSize, 2);
        applyRandomPositions(midLeftStim, cellSize, 3);
        applyRandomPositions(midMidStim, cellSize, 4);
        applyRandomPositions(midRightStim, cellSize, 5);
        applyRandomPositions(botLeftStim, cellSize, 6);
        applyRandomPositions(botMidStim, cellSize, 7);
        applyRandomPositions(botRightStim, cellSize, 8);
        applyRandomPositions(stim10, cellSize, 9);
        applyRandomPositions(stim11, cellSize, 10);
        applyRandomPositions(stim12, cellSize, 11);
        applyRandomPositions(stim13, cellSize, 12);
        applyRandomPositions(stim14, cellSize, 13);
        applyRandomPositions(stim15, cellSize, 14);
        applyRandomPositions(stim16, cellSize, 15);

    }

    private void applyRandomPositions(Button stim, float cellSize, int index)
    {
        float maxX = randomPositions[index].x + cellSize / 2;
        float maxY = randomPositions[index].y + cellSize / 2;
        float minX = randomPositions[index].x - cellSize / 2;
        float minY = randomPositions[index].y - cellSize / 2;
        stim.image.rectTransform.anchorMax = new Vector2(0f, 0f);
        stim.image.rectTransform.anchorMin = new Vector2(0f, 0f);
        stim.image.rectTransform.offsetMax = new Vector2(maxX, maxY);
        stim.image.rectTransform.offsetMin = new Vector2(minX, minY);
        //Debug.Log("X: " + randomPositions[index].x + "  Y: " + randomPositions[index].y);
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
    void initBlock ()
    {
        if ( blockNo == 0 )
        {
            arrangeBlock(3, 3, 5, 2, 3, 3, 8, 2, 3, 4, 1, 2);
        }
        else if (blockNo == 1)
        {
            arrangeBlock(3, 3, 5, 10, 3, 3, 8, 10, 3, 4, 1, 6);  
        }
        else if (blockNo == 2)
        {
            arrangeBlock(3, 2, 5, 10, 3, 2, 8, 10);
        }
        else if (blockNo == 3)
        {
            arrangeBlock(2, 3, 5, 10, 2, 3, 8, 10, 2, 4, 1, 6);
        }
        else if (blockNo == 4)
        {
            arrangeBlock(2, 2, 5, 10, 2, 2, 8, 10);
        }
        else if (blockNo == 5)
        {
            arrangeBlock(1, 3, 5, 10, 1, 3, 8, 10, 1, 4, 1, 6);
        }
        else if (blockNo == 6)
        {
            arrangeBlock(1, 2, 5, 10, 1, 2, 8, 10);
        }
        else if (blockNo == 7)
        {
            arrangeBlock(1, 3, 5, 10, 1, 3, 8, 10, 1, 4, 1, 6);
        }
        else if (blockNo == 8)
        {
            arrangeBlock(1, 2, 5, 10, 1, 2, 8, 10);
        }
        else if (blockNo == 9)
        {
            StaticData.Selections = 2;
            arrangeBlock9();
        } 
        else 
        {
            Debug.Log("Error:  StimulusHandler: initBlock(): incorrect Block Number.");
        }
        //printBlock();
    }

    // This method is used to activate or deatcivate the extra stim for the 4x4 trials
    void set4x4Trial(bool is4x4)
    {
        if ( is4x4 )
        {
            StimUIGrouping.constraintCount = 4;
            stim16.gameObject.SetActive(true);
            stim15.gameObject.SetActive(true);
            stim14.gameObject.SetActive(true);
            stim13.gameObject.SetActive(true);
            stim12.gameObject.SetActive(true);
            stim11.gameObject.SetActive(true);
            stim10.gameObject.SetActive(true);
        } else
        {
            StimUIGrouping.constraintCount = 3;
            stim16.gameObject.SetActive(false);
            stim15.gameObject.SetActive(false);
            stim14.gameObject.SetActive(false);
            stim13.gameObject.SetActive(false);
            stim12.gameObject.SetActive(false);
            stim11.gameObject.SetActive(false);
            stim10.gameObject.SetActive(false);
        }
    }

    void buildAndShuffleIntListOrder(List<int> order, int num)
    {
        for (int i = 0; i < num; i++)
        {
            order.Add(i);
        }
        order.Shuffle();
    }

    void arrangeBlock(int numTarg0, int targetType0, int distractorType0, int noTrials0, int numTarg1, int targetType1, int distractorType1, int noTrials1, int numTarg2 = 0, int targetType2 = 0, int distractorType2 = 0, int noTrials2 = 0)
    {
        int noTri0 = noTrials0;
        int noTri1 = noTrials1;
        int noTri2 = noTrials2;
        int blockLength = noTri0 + noTri1 + noTri2;
        List<int> order = new List<int>();
        buildAndShuffleIntListOrder(order, blockLength);

        block = new int[blockLength, 3];
        spacingType = new int[blockLength];

        for (int i = 0; i < blockLength; i++)
        {
            if ( i < noTrials0)
            {
                block[order[i], 0] = numTarg0; block[order[i], 1] = targetType0; block[order[i], 2] = distractorType0;
            }else if ( i < (noTrials0 + noTrials1))
            {
                block[order[i], 0] = numTarg1; block[order[i], 1] = targetType1; block[order[i], 2] = distractorType1;
            }else 
            {
                block[order[i], 0] = numTarg2; block[order[i], 1] = targetType2; block[order[i], 2] = distractorType2;
            }
        }

        for (int i = 0; i < spacingType.Length; i++)
        {
            if (i % 1 == 0)
            {
                spacingType[i] = 1;
            }
            if (i % 2 == 0)
            {
                spacingType[i] = 2;
            }
            if (i % 3 == 0)
            {
                spacingType[i] = 3;
            }
        }
        spacingType.Shuffle();
    }

    //  This function is to layout the 9th block which includes 2 targets and some 4x4 trials
    void arrangeBlock9( )
    {
        int noTri0 = 10;
        int noTri1 = 10;
        int noTri2 = 10;
        int noTri3 = 10;
        int blockLength = noTri0 + noTri1 + noTri2 + noTri3;
        List<int> order = new List<int>();
        buildAndShuffleIntListOrder(order, blockLength);

        block9 = new int[blockLength, 4];
        spacingType = new int[blockLength];

        for (int i = 0; i < blockLength; i++)
        {
            if (i < noTri0)
            {
                block9[order[i], 0] = 3; block9[order[i], 1] = 2; block9[order[i], 2] = 5; block9[order[i], 3] = 9;
            }
            else if (i < (noTri0 + noTri1))
            {
                block9[order[i], 0] = 3; block9[order[i], 1] = 2; block9[order[i], 2] = 8; block9[order[i], 3] = 9;
            }
            else if (i < (noTri0 + noTri1 + noTri2))
            {
                block9[order[i], 0] = 3; block9[order[i], 1] = 2; block9[order[i], 2] = 5; block9[order[i], 3] = 16;
            }
            else
            {
                block9[order[i], 0] = 3; block9[order[i], 1] = 2; block9[order[i], 2] = 8; block9[order[i], 3] = 16;
            }
        }

        for (int i = 0; i < spacingType.Length; i++)
        {
            if (i % 1 == 0)
            {
                spacingType[i] = 1;
            }
            if (i % 2 == 0)
            {
                spacingType[i] = 2;
            }
            if (i % 3 == 0)
            {
                spacingType[i] = 3;
            }
        }
        spacingType.Shuffle();
    }

    public void proceedToNextTrial()
    {

        StaticData.SelectionCount = 0;
        trialNo++;
        int blockLength = block.GetLength(0);

        if ( clickAudioChange == trialNo)
        {
            Debug.Log("Change the audio");
            setTrialAudio(true);
        }
        else
        {
            setTrialAudio(false);
        }

        if (StaticData.is1Trial)
        {
            blockLength = 1;
        }

        if (blockNo == 9)
        {
            blockLength = block9.GetLength(0);

            if (StaticData.is1Trial)
            {
                blockLength = 0;
            }
        }

        if (trialNo != 1)
        {
            string ID = buildTrialID(trialTargetType, trialNumTargets, trialDistractorType, trialMatrixType, trialNo-1);
            CSVWriter.writeStringToCSV(ID + "," + RT + "," + clickCount + "\n", StaticData.LogFName);
            clickCount = 0;
        }

        if ( trialNo > blockLength)
        {
            StaticData.BlockNumber++;
            StartCoroutine(endBlock());
        }
        else
        {
            progressText.text = trialNo.ToString() + "/" + blockLength.ToString();

            setStimSpacing();
            

            if (blockNo == 9)
            {
                setupTrial9(block9[trialNo - 1, 0], block9[trialNo - 1, 1], block9[trialNo - 1, 2], block9[trialNo - 1, 3]);
            }
            else
            {
                setupTrial(block[trialNo - 1, 0], block[trialNo - 1, 1], block[trialNo - 1, 2]);
            }
            bool isRandomSpacing = false;

            if (spacingType[trialNo-1] == 3)
            {
                isRandomSpacing = true;
            }

            if (isRandomSpacing)
            {
                StimUIGrouping.enabled = false;
                setCellRandomPositions();
            }
            else
            {
                StimUIGrouping.enabled = true;
            }
        }
    }

    private bool blockEnding = false;
    private IEnumerator endBlock()
    {
        blockEnding = true;
        yield return new WaitForSeconds(0.5f);
        if (unitTest)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
        
    }

    private int convertStimTypeToLogCode(int type)
    {
        int rtrn = 0;

        if (type == 1)
        {
            rtrn = 3;
        }else if (type == 2)
        {
            rtrn = 2;
        }else if(type == 3)
        {
            rtrn = 1;
        }
        else if (type == 4)
        {
            rtrn = 4;
        }
        else if (type == 5)
        {
            rtrn = 1;
        }
        else if (type == 6)
        {
            Debug.Log("ERROR: There should be no Negative stimulus.");
        }
        else if (type == 7)
        {
            Debug.Log("ERROR: There should be no Positive stimulus.");
        }
        else if (type == 8)
        {
            rtrn = 2;
        }
        else
        {
            Debug.Log("ERROR: Stimulus Types should be between 1 - 8");
        }

        return rtrn;
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
    private void setupTrial(int numberOfTargets, int targetType, int distractorType)
    {
        
        trialTargetType = convertStimTypeToLogCode(targetType);
        trialDistractorType = convertStimTypeToLogCode(distractorType);
        trialNumTargets = numberOfTargets;
        trialMatrixType = 1;

        List<string> imageFNames = new List<string>();
        List<string> excludedFNames = new List<string>();       //imageFNames but without the sub folders
        List<bool> isTargetList = new List<bool>();
        List<int> typeList = new List<int>();
        List<int> imagePositions = new List<int>(){ 0,1,2,3,4,5,6,7,8 };

        for (int i = 0; i < numberOfTargets; i++)
        {
            imageFNames.Add(CSVReader.GetImageFileName(excludedFNames, targetType));    //Add good images
            excludedFNames.Add(Path.GetFileNameWithoutExtension(imageFNames[i]));
            isTargetList.Add(true);
            typeList.Add(targetType);
        }

        for (int i = 0; i < 9 - numberOfTargets; i++)
        {
            imageFNames.Add(CSVReader.GetImageFileName(excludedFNames, distractorType));    //Add Distractor images
            excludedFNames.Add(Path.GetFileNameWithoutExtension(imageFNames[i + numberOfTargets]));
            isTargetList.Add(false);
            typeList.Add(distractorType);
        }

        imagePositions.Shuffle();

        _topLeftStimScript.SetStimulus(imageFNames[imagePositions[0]], isTargetList[imagePositions[0]], typeList[imagePositions[0]], excludedFNames);
        _topMidStimScript.SetStimulus(imageFNames[imagePositions[1]], isTargetList[imagePositions[1]], typeList[imagePositions[1]], excludedFNames);
        _topRightStimScript.SetStimulus(imageFNames[imagePositions[2]], isTargetList[imagePositions[2]], typeList[imagePositions[2]], excludedFNames);
        _midLeftStimScript.SetStimulus(imageFNames[imagePositions[3]], isTargetList[imagePositions[3]], typeList[imagePositions[3]], excludedFNames);
        _midMidStimScript.SetStimulus(imageFNames[imagePositions[4]], isTargetList[imagePositions[4]], typeList[imagePositions[4]], excludedFNames);
        _midRightStimScript.SetStimulus(imageFNames[imagePositions[5]], isTargetList[imagePositions[5]], typeList[imagePositions[5]], excludedFNames);
        _botLeftStimScript.SetStimulus(imageFNames[imagePositions[6]], isTargetList[imagePositions[6]], typeList[imagePositions[6]], excludedFNames);
        _botMidStimScript.SetStimulus(imageFNames[imagePositions[7]], isTargetList[imagePositions[7]], typeList[imagePositions[7]], excludedFNames);
        _botRightStimScript.SetStimulus(imageFNames[imagePositions[8]], isTargetList[imagePositions[8]], typeList[imagePositions[8]], excludedFNames);

    }

    private void setupTrial9(int targetType1, int targetType2, int distractorType, int numStim)
    {
        trialTargetType = 3;
        trialDistractorType = convertStimTypeToLogCode(distractorType);
        trialNumTargets = 2;
        trialMatrixType = 1;

        List<string> imageFNames = new List<string>();
        List<string> excludedFNames = new List<string>();       //imageFNames but without the sub folders
        List<bool> isTargetList = new List<bool>();
        List<int> typeList = new List<int>();
        List<int> imagePositions = new List<int>();
        buildAndShuffleIntListOrder(imagePositions, numStim);
        
        imageFNames.Add(CSVReader.GetImageFileName(excludedFNames, targetType1));    //Add first target image
        excludedFNames.Add(Path.GetFileNameWithoutExtension(imageFNames[0]));
        isTargetList.Add(true);
        typeList.Add(targetType1);

        imageFNames.Add(CSVReader.GetImageFileName(excludedFNames, targetType2));    //Add second target
        excludedFNames.Add(Path.GetFileNameWithoutExtension(imageFNames[1]));
        isTargetList.Add(true);
        typeList.Add(targetType2);

        //  Add distractors
        for (int i = 2; i < numStim; i++)
        {
            imageFNames.Add(CSVReader.GetImageFileName(excludedFNames, distractorType));  
            excludedFNames.Add(Path.GetFileNameWithoutExtension(imageFNames[i]));
            isTargetList.Add(false);
            typeList.Add(distractorType);
        }

        _topLeftStimScript.SetStimulus(imageFNames[imagePositions[0]], isTargetList[imagePositions[0]], typeList[imagePositions[0]], excludedFNames);
        _topMidStimScript.SetStimulus(imageFNames[imagePositions[1]], isTargetList[imagePositions[1]], typeList[imagePositions[1]], excludedFNames);
        _topRightStimScript.SetStimulus(imageFNames[imagePositions[2]], isTargetList[imagePositions[2]], typeList[imagePositions[2]], excludedFNames);
        _midLeftStimScript.SetStimulus(imageFNames[imagePositions[3]], isTargetList[imagePositions[3]], typeList[imagePositions[3]], excludedFNames);
        _midMidStimScript.SetStimulus(imageFNames[imagePositions[4]], isTargetList[imagePositions[4]], typeList[imagePositions[4]], excludedFNames);
        _midRightStimScript.SetStimulus(imageFNames[imagePositions[5]], isTargetList[imagePositions[5]], typeList[imagePositions[5]], excludedFNames);
        _botLeftStimScript.SetStimulus(imageFNames[imagePositions[6]], isTargetList[imagePositions[6]], typeList[imagePositions[6]], excludedFNames);
        _botMidStimScript.SetStimulus(imageFNames[imagePositions[7]], isTargetList[imagePositions[7]], typeList[imagePositions[7]], excludedFNames);
        _botRightStimScript.SetStimulus(imageFNames[imagePositions[8]], isTargetList[imagePositions[8]], typeList[imagePositions[8]], excludedFNames);

        if (numStim == 16)
        {
            set4x4Trial(true);
            trialMatrixType = 2;
            stim10Script.SetStimulus(imageFNames[imagePositions[9]], isTargetList[imagePositions[9]], typeList[imagePositions[9]], excludedFNames);
            stim11Script.SetStimulus(imageFNames[imagePositions[10]], isTargetList[imagePositions[10]], typeList[imagePositions[10]], excludedFNames);
            stim12Script.SetStimulus(imageFNames[imagePositions[11]], isTargetList[imagePositions[11]], typeList[imagePositions[11]], excludedFNames);
            stim13Script.SetStimulus(imageFNames[imagePositions[12]], isTargetList[imagePositions[12]], typeList[imagePositions[12]], excludedFNames);
            stim14Script.SetStimulus(imageFNames[imagePositions[13]], isTargetList[imagePositions[13]], typeList[imagePositions[13]], excludedFNames);
            stim15Script.SetStimulus(imageFNames[imagePositions[14]], isTargetList[imagePositions[14]], typeList[imagePositions[14]], excludedFNames);
            stim16Script.SetStimulus(imageFNames[imagePositions[15]], isTargetList[imagePositions[15]], typeList[imagePositions[15]], excludedFNames);
        }
        else if (numStim == 9)
        {
            set4x4Trial(false);
        } else
        {
            Debug.Log("ERROR: setupTrial9: wrong number of stim passed through: " + numStim);
        }

    }

    private int randValBetween(int lowerLimit, int upperLimit, System.Random rnd)
    {
        int value = rnd.Next(lowerLimit, upperLimit);
        return value;
    }

    void printBlock()
    {
        for (int i = 0; i < block.GetLength(0); i++)
        {
            Debug.Log(block[i, 0] + ", " + block[i, 1] + ", " + block[i, 2]);
        }
    }

    // This method is used to take the trial details and return an ID string for the log file
    string buildTrialID(int targetType, int numberOfTargets, int distractorType, int matrixType, int trialNo)
    {   
        string ID = StaticData.BlockNumber.ToString() + targetType;
        ID += numberOfTargets;
        ID += distractorType;
        ID += matrixType;
        if (trialNo < 10)
        {
            ID += "0" + trialNo;
        }
        else
        {
            ID += trialNo;
        }
        return ID;
    }

    private void unitTestSetup()
    {
        StaticData.WeekNo = unitTestWeek;
        StaticData.FormFName = "Logs/" + "tst" + "_" + unitTestWeek + "_Form_" + DateTime.Now.ToString("dd_MM_yyyy_H_mm") + ".csv";
        StaticData.LogFName = "Logs/" + "tst" + "_" + unitTestWeek + "_Log_" + DateTime.Now.ToString("dd_MM_yyyy_H_mm") + ".csv";
        StaticData.WeekNo = unitTestWeek;
        StaticData.BlockNumber = unitTestBlock;

        if (CSVReader.haveFilenamesBeenPulled() == false)
        {
            CSVReader.PullFilenames(csv);
        }

        StartCoroutine(clickButtons());
    }

    private IEnumerator clickButtons()
    {

        yield return new WaitForSeconds(0.5f);

        List<Button> buttons = new List<Button>();

        buttons.Add(topLeftStim);
        buttons.Add(topMidStim);
        buttons.Add(topRightStim);
        buttons.Add(midLeftStim);
        buttons.Add(midMidStim);
        buttons.Add(midRightStim);
        buttons.Add(botLeftStim);
        buttons.Add(botMidStim);
        buttons.Add(botRightStim);
        buttons.Add(stim10);
        buttons.Add(stim11);
        buttons.Add(stim12);
        buttons.Add(stim13);
        buttons.Add(stim14);
        buttons.Add(stim15);
        buttons.Add(stim16);

        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].IsActive())
            {
                buttons[i].onClick.Invoke();
            }
        }

        if (!blockEnding)
        {
            StartCoroutine(clickButtons());
        }

    }

}

public static class ThreadSafeRandom
{
    [ThreadStatic] private static System.Random Local;

    public static System.Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}

static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}