using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EmojiScript : MonoBehaviour
{
    private RectTransform parentRectTransform;
    private EmojiGameScript gameScript;
    public bool isTarget;
    public AudioSource AS;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = this.transform.parent.GetComponent<EmojiGameScript>();
        setImage();
        isActive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        checkPosition();
    }

    private void checkPosition()
    {
        if (this.gameObject.GetComponent<RectTransform>().position.y < 0)
        {
            if (isTarget)
            {
                if (isActive)
                {
                    gameScript.incrimentMiss();
                }
            }
            Destroy(this.gameObject);
        }
    }

    private void setImage()
    {
        System.Random rnd = new System.Random();
        if (isTarget)
        {
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Emoji/Image" + rnd.Next(1,19));
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Negative/Image" + rnd.Next(1, 17));
        }
    }

    public void onClick()
    {
        if (isTarget)
        {
            this.gameObject.GetComponent<Image>().enabled = false;
            AS.Play();
            gameScript.incrimentHit();
            isActive = false;
        }
        else
        {
            gameScript.incrimentMiss();
        }
    }
}
