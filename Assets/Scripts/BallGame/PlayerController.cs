using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text timerText;
    public Component canvas;

    private Rigidbody rb;
    private int count;
    private bool buttonDown;

    private float sessionTime;
    private float closeTime;            //  Used to delay the closing of the game so the response can be shown on the screen
    private int roundedTime;
    private bool isFinished;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        buttonDown = false;
        sessionTime = 20.0f;
        closeTime = 3.0f;
        roundedTime = (int)sessionTime;
        isFinished = false;
        setTimerText();
    }

    private void Update()
    {
        
        if (isFinished)
        {
            closeTime -= Time.deltaTime;
            if (closeTime < 0)
            {
                SceneManager.LoadScene(5);
            }
        }
        else
        {
            sessionTime -= Time.deltaTime;
            if (sessionTime <= roundedTime - 1)
            {
                roundedTime -= 1;
                setTimerText();
            }

            if (sessionTime < 0)
            {
                winText.text = "Congratulations!!  You collected " + count +" Smiley Faces!!";
                isFinished = true;
            }

        }
    }

    private float getNormalizedMousePosX(float x)
    {
        float normX = (x - ((float)canvas.GetComponent<RectTransform>().rect.width / 2)) / ((float)canvas.GetComponent<RectTransform>().rect.width / 2) * 4;
        if (normX > 1f)
        {
            normX = 1.0f;
        }else if (normX < -1f)
        {
            normX = -1.0f;
        }
        return normX;
    }

    private float getNormalizedMousePosY(float x)
    {
        float normY = (x - ((float)canvas.GetComponent<RectTransform>().rect.height / 2)) / ((float)canvas.GetComponent<RectTransform>().rect.height / 2) * 4;
        if (normY > 1f)
        {
            normY = 1.0f;
        }
        else if (normY < -1f)
        {
            normY = -1.0f;
        }
        return normY;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Fire1"))
        {
            buttonDown = true;
        }
        else
        {
            buttonDown = false;
        }

        if (buttonDown)
        {
            moveHorizontal = getNormalizedMousePosX(Input.mousePosition.x);
            moveVertical = getNormalizedMousePosY(Input.mousePosition.y);
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.GetComponent<BallPickup>().pickupHit();
            if (StaticData.isDebugMode)
            {
                SceneManager.LoadScene(5);
            }

            //other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void setTimerText()
    {
        timerText.text = "Time remaining: " + roundedTime;
    }

    void SetCountText()
    {
        countText.text = "Collected:  " + count.ToString();
        if (count >= 14)
        {
            winText.text = "Congratulations!!  You collected all 14 Smiley Faces!!";
            isFinished = true;
        }
    }
}
