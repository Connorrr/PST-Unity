using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryButtonScript : MonoBehaviour
{

    public Text memoryButtonText;
    public Image memoryButtonImage;
    public Sprite memorySprite;
    public bool isTarget;
    public MemoryGameControllerScript parentController;

    private bool isButton;
    private int imageNum;       //  This number is used for button types and corresponds to the order in which it is displayed
    private bool isTryAgain;
    private float tryAgainTimer;

    // Start is called before the first frame update
    void Start()
    {
        tryAgainTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTryAgain)
        {
            tryAgainTimer -= Time.deltaTime;
            if (tryAgainTimer < 0)
            {
                isTryAgain = false;
                setAsQuestionMark();
                tryAgainTimer = 1.0f;

            }
        }
    }

    public void setImage()
    {
        memoryButtonImage.sprite = memorySprite;
    }

    public void setAsDisplayImage()
    {
        isTryAgain = false;
        memoryButtonText.text = "";
        memoryButtonImage.color = new Color32(255, 255, 255, 255);
        isButton = false;
    }

    public void setAsMemoryButton(int num)
    {
        isTryAgain = false;
        memoryButtonText.text = "";
        memoryButtonImage.color = new Color32(255, 255, 255, 255);
        isButton = true;
        imageNum = num;
    }

    public void setAsQuestionMark()
    {
        isTryAgain = false;
        memoryButtonText.text = "?";
        memoryButtonImage.color = new Color32(0,0,0,255);
        isButton = false;
    }

    public void setAsTryAgain()
    {
        memoryButtonText.text = "Try Again";
        memoryButtonImage.color = new Color32(0, 0, 0, 255);
        isButton = false;
        isTryAgain = true;
    }

    public void destroyMe()
    {
        Destroy(this.gameObject);
    }

    public void buttonPressed()
    {
        if (isTarget)
        {
            if (parentController.correctImageSelected(imageNum))
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            parentController.incorrectImageSelected();
        }
        
    }

}
