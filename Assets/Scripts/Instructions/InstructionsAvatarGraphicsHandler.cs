using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsAvatarGraphicsHandler : MonoBehaviour
{

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject avatar;

    public bool isInstructions1;
    public int screenNo;

    private float height;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        setHeights();
        setAvatarImage();
    }

    // Update is called once per frame
    void Update()
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

    private void setHeights()
    {
        height = GetComponent<RectTransform>().rect.height;
        width = GetComponent<RectTransform>().rect.width;
        
        float textHeight = (height * 2) / 3;
        float avatarHeight = height / 3;

        text1.GetComponent<RectTransform>().sizeDelta = new Vector2(width-10, textHeight);
        text2.GetComponent<RectTransform>().sizeDelta = new Vector2(width-10, textHeight);
        text3.GetComponent<RectTransform>().sizeDelta = new Vector2(width-10, textHeight);
        avatar.GetComponent<RectTransform>().sizeDelta = new Vector2(width-10, avatarHeight);

    }

    private void setAvatarImage()
    {

       if (screenNo == 1)
       {
           avatar.GetComponent<AvatarGraphicsHandler>().setNoBubbles();
       }
       if(screenNo == 5)
       {
            if ( StaticData.WeekNo == 1)
            {
                avatar.GetComponent<AvatarGraphicsHandler>().setNeverGiveUp();
            }
            else
            {
                avatar.GetComponent<AvatarGraphicsHandler>().setAllBubbles();
            }
           
       }
       if (screenNo == 6)
       {
           avatar.GetComponent<AvatarGraphicsHandler>().setAllBubbles();
       }
       if (screenNo == 10)
       {
           avatar.GetComponent<AvatarGraphicsHandler>().setLookForGood();
       }

    }
}
