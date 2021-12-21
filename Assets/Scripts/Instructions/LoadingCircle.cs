using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingCircle : MonoBehaviour
{
    public GameObject ErrorTextCanvas;

    private RectTransform rectComponent;
    private float rotateSpeed = 200f;
    private float timeLimit = 38;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        if (StaticData.isErrorSendingMail)
        {
            timeLimit = 8f;
        }
        else
        {
            seeIfTimeLimitHasBeenReached();
            checkHasSent();
        }
    }

    //  See if the timelimit has been reached
    private void seeIfTimeLimitHasBeenReached()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 8f)
        {
            ErrorTextCanvas.gameObject.SetActive(true);
        }

        if (timeLimit <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }

    //  Check to see if the email has been sent
    private void checkHasSent()
    {
        if (StaticData.isSendingMail == false)
        {
            SceneManager.LoadScene(0);
        }
    }
}
