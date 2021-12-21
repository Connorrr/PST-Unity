using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions2AvatarGraphicsHandler : MonoBehaviour
{

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    public GameObject text12;
    public GameObject text13;
    public GameObject text14;
    public GameObject text17;
    public GameObject text18;
    public GameObject avatar;
    public VerticalLayoutGroup layout;
    public GameObject gridLayout;

    private float height;
    private float width;
    private GameObject currentText;
    private bool isAvatarScreen;

    // Start is called before the first frame update
    void Start()
    {
        isAvatarScreen = true;
        setAvatarImage();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvatarScreen)
        {
            if (height != GetComponent<RectTransform>().rect.height)
            {
                setHeights();
            }
            if (width != GetComponent<RectTransform>().rect.width)
            {
                setHeights();
            }
        }
        if (StaticData.ScreenNo >= 27)
        {
            if (height != GetComponent<RectTransform>().rect.height)
            {
                setLastScreensHeights();
            }
            if (width != GetComponent<RectTransform>().rect.width)
            {
                setLastScreensHeights();
            }
        }
    }

    private void setHeights()
    {
        height = GetComponent<RectTransform>().rect.height;
        width = GetComponent<RectTransform>().rect.width;

        float textHeight = (height * 2) / 3;
        float avatarHeight = height / 3;

        currentText.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 10, textHeight);
        avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 10, avatarHeight);
    }

    private void setLastScreensHeights()
    {
        height = GetComponent<RectTransform>().rect.height;
        width = GetComponent<RectTransform>().rect.width;

        float textHeight = height / 3;
        float gridHeight = textHeight;
        float avatarHeight = textHeight;

        text17.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 10, textHeight);
        text18.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 10, textHeight);
        avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 10, avatarHeight);
        gridLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(width, gridHeight);
    }

    public void setAvatarImage()
    {
        //Debug.Log(StaticData.ScreenNo);
        avatar.gameObject.SetActive(true);
        layout.enabled = false;

        switch (StaticData.ScreenNo)
        {
            case 11:
                currentText = text1;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForGood();
                break;
            case 12:
                currentText = text2;
                setHeights();
                if (StaticData.WeekNo != 1)
                {
                    avatar.GetComponent<AvatarGraphicsHandler>().setLookForCalm();
                }
                else
                {
                    avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
                }
                break;
            case 13:
                avatar.gameObject.SetActive(false);
                layout.enabled = true;
                //currentText = text3;
                //setHeights();
                //avatar.GetComponent<AvatarGraphicsHandler>().setLookForCalm();
                break;
            case 14:
                currentText = text4;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
                break;
            case 15:
                currentText = text5;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForGood();
                break;
            case 16:
                currentText = text6;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForCalm();
                break;
            case 17:
                currentText = text7;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForGood();
                break;
            case 18:
                currentText = text8;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForCalm();
                break;
            case 19:
                currentText = text9;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
                break;
            case 20:
                currentText = text10;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForGood();
                break;
            case 21:
                currentText = text11;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setLookForCalm();
                break;
            case 22:
                currentText = text12;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
                break;
            case 23:
                currentText = text13;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setNeverGiveUp();
                break;
            case 24:
                currentText = text14;
                setHeights();
                avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
                break;
            case 25:
                isAvatarScreen = false;
                avatar.gameObject.SetActive(false);
                layout.enabled = true;
                break;
            case 26:
                isAvatarScreen = false;
                avatar.gameObject.SetActive(false);
                layout.enabled = true;
                break;
            case 27:
                isAvatarScreen = false;
                avatar.gameObject.SetActive(true);
                setLastScreensHeights();
                break;
            case 28:
                isAvatarScreen = false;
                avatar.gameObject.SetActive(true);
                setLastScreensHeights();
                break;
            default:
                Debug.Log("This screen doesnt have an avatar.");
                break;
        }

    }
}
