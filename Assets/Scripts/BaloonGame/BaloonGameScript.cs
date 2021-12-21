using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaloonGameScript : MonoBehaviour
{
    public BaloonScript baloon;
    public ScoreIncrimenter score;
    public AudioSource AS;
    public AudioSource ASPop;
    public AudioClip goodClip;
    public AudioClip calmClip;
    public AudioClip bothClip;
    public AudioClip neverClip;
    public GameObject finalTextObject;
    public Text finalText;

    private float mainTimer;
    private float baloonTimer;
    private bool hasStarted;
    private int baloonIndex;
    private float[] baloonTimes = { 2.0f, 0.3f, 1.5f, 0.8f, 1.2f };
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        mainTimer = 35f;
        hasStarted = false;
        baloonTimer = baloonTimes[rnd.Next(0, 4)];
        baloonIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            mainTimer -= Time.deltaTime;
            baloonTimer -= Time.deltaTime;

            if (baloonTimer < 0)
            {
                addBaloon();
                baloonIndex++;
                baloonTimer = baloonTimes[rnd.Next(0, 4)];
            }

            if (mainTimer < 0)
            {
                setUpFinalText();
                StartCoroutine(goToInstructions());
            }
        }
    }

    public void startGame()
    {
        hasStarted = true;
    }

    private void addBaloon()
    {
        System.Random rnd = new System.Random();
        BaloonScript baloonClone = Instantiate(baloon, this.transform);
        Vector3 pos = baloonClone.transform.position;
        baloonClone.AS = AS;
        baloonClone.ASPop = ASPop;
        baloonClone.score = score;
        setBaloonMaterialAndSound(baloonClone);
        //float baloonWidth = GetComponent<RectTransform>().rect.width / 7;
        //baloonClone.GetComponent<RectTransform>().sizeDelta = new Vector2(baloonWidth, baloonWidth);
        pos.x = getRandomXPosition(rnd);
        pos.y = getRandomYPosition();
        //pos.z = 804.3f;
        baloonClone.transform.position = pos;
    }

    private void setBaloonMaterialAndSound(BaloonScript baloonClone)
    {
        Debug.Log("index:  " + baloonIndex % 4);
        if (baloonIndex % 4 == 0)
        {
            baloonClone.setCalmMaterial();
            baloonClone.clip = calmClip;
        }
        else if(baloonIndex % 4 == 1)
        {
            baloonClone.setGoodMaterial();
            baloonClone.clip = goodClip;
        }
        else if (baloonIndex % 4 == 2)
        {
            baloonClone.setBothMaterial();
            baloonClone.clip = bothClip;
        }
        else
        {
            baloonClone.setNeverMaterial();
            baloonClone.clip = neverClip;
        }
    }

    private float getRandomXPosition(System.Random rnd)
    {
        float rtrn = 0;
        float width = 1340f;
        rtrn = ((float)rnd.NextDouble() * width) - (width / 2);
        return rtrn;
    }

    private float getRandomYPosition()
    {
        float rtrn = -800;
        //float height = this.gameObject.GetComponent<RectTransform>().rect.height;
        //rtrn = height - startY - ((float)rnd.NextDouble() * baloonHeight * 3);
        return rtrn;
    }

    private void setUpFinalText()
    {
        finalTextObject.SetActive(true);
        finalText.text = "Congratulations!  You got " + score.score + " points!";
    }

    private IEnumerator goToInstructions()
    {
        yield return new WaitForSeconds(2.5f);
        CSVWriter.writeStringToCSV(score.score.ToString() + "\n", StaticData.LogFName);
        SceneManager.LoadScene(5);
    }
}
