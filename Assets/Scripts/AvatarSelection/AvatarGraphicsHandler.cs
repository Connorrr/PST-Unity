using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarGraphicsHandler : MonoBehaviour
{

    public Image avatar;
    public Image lookForGood;
    public Image lookForCalm;
    public Image useBothOptions;
    public Image neverGiveUp;
    public GameObject leftPanel;
    public GameObject rightPanel;

    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        setDimensions();
    }

    // Update is called once per frame
    void Update()
    {
        if (width != GetComponent<RectTransform>().rect.width)
        {
            setDimensions();
        }
        if (height != GetComponent<RectTransform>().rect.height)
        {
            setDimensions();
        }
    }

    private void setDimensions()
    {
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;

        if (height < width / 2)
        {
            avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(height, height);
        }
        else
        {
            avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(width / 2, width / 2);
        }

        float avatarWidth = avatar.GetComponent<RectTransform>().rect.width;
        float speechBubbleWidth = (width - avatarWidth) / 2;
        float speechBubbleHeight = height / 2;

        leftPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, height); 
        rightPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, height);

        lookForGood.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, speechBubbleHeight);
        lookForCalm.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, speechBubbleHeight);
        useBothOptions.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, speechBubbleHeight);
        neverGiveUp.GetComponent<RectTransform>().sizeDelta = new Vector2(speechBubbleWidth, speechBubbleHeight);

    }

    /// <summary>
    /// Sets the image to have a "Look for good" Bubble
    /// </summary>
    public void setLookForGood()
    {
        lookForGood.gameObject.SetActive(true);
        lookForCalm.gameObject.SetActive(false);
        useBothOptions.gameObject.SetActive(false);
        neverGiveUp.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the image to have a "Look for calm" Bubble
    /// </summary>
    public void setLookForCalm()
    {
        lookForGood.gameObject.SetActive(false);
        lookForCalm.gameObject.SetActive(true);
        useBothOptions.gameObject.SetActive(false);
        neverGiveUp.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the image to have a "Use Both Options" Bubble
    /// </summary>
    public void setUseBothOptions()
    {
        lookForGood.gameObject.SetActive(false);
        lookForCalm.gameObject.SetActive(false);
        useBothOptions.gameObject.SetActive(true);
        neverGiveUp.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the image to have a "Never Give Up" Bubble
    /// </summary>
    public void setNeverGiveUp()
    {
        lookForGood.gameObject.SetActive(false);
        lookForCalm.gameObject.SetActive(false);
        useBothOptions.gameObject.SetActive(false);
        neverGiveUp.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets the image to have a all bubbles displayed 
    /// </summary>
    public void setAllBubbles()
    {
        lookForGood.gameObject.SetActive(true);
        lookForCalm.gameObject.SetActive(true);
        useBothOptions.gameObject.SetActive(true);
        neverGiveUp.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets the image to have no bubbles displayed 
    /// </summary>
    public void setNoBubbles()
    {
        lookForGood.gameObject.SetActive(false);
        lookForCalm.gameObject.SetActive(false);
        useBothOptions.gameObject.SetActive(false);
        neverGiveUp.gameObject.SetActive(false);
    }

}
