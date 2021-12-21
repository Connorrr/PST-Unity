using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class BaloonScript : MonoBehaviour
{

    public UnityEvent OnClick = new UnityEvent();
    public AudioSource AS;
    public AudioSource ASPop;
    public AudioClip clip;
    public TextMesh text;
    public ScoreIncrimenter score;

    public Material lookForGoodMaterial;
    public Material lookForCalmMaterial;
    public Material useBothOptionsMaterial;
    public Material neverGiveUpMaterial;
    public MeshRenderer mainPartBaloon;

    private float zRotation;
    private float animTime;
    private float direction;
    private float gravityMagnitudeMultiplier;
    private float leftMovement;
    private enum baloonType { good, calm, both, never };
    private baloonType thisType;
    private List<int> lfg = new List<int> { 0, 2, 3 };
    private List<int> lfc = new List<int> { 0, 1, 3, 4 };
    private List<int> ubo = new List<int> { 1, 2, 3, 4 };
    private List<int> ngu = new List<int> { 0, 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        zRotation = 0f;
        animTime = 0f;
        direction = 1f;

        lfg.Shuffle();
        lfc.Shuffle();
        ubo.Shuffle();
        ngu.Shuffle();


        System.Random rand = new System.Random();
        gravityMagnitudeMultiplier = ((float)rand.NextDouble() + 1f) * 7;

        if (rand.NextDouble() > 0.5)
        {
            leftMovement = ((float)rand.NextDouble() + 1f) * 3;
        }
        else
        {
            leftMovement = -1f * ((float)rand.NextDouble() + 1f) * 3;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        setTilt();
    }

    public void setGoodMaterial()
    {
        thisType = baloonType.good;
        mainPartBaloon.material = lookForGoodMaterial;
        text.text = "Look for\nGood!";
    }

    public void setCalmMaterial()
    {
        thisType = baloonType.calm;
        mainPartBaloon.material = lookForCalmMaterial;
        text.text = "Look for\nCalm!";
    }

    public void setBothMaterial()
    {
        thisType = baloonType.both;
        mainPartBaloon.material = useBothOptionsMaterial;
        text.text = "Use both\nOptions!";
    }

    public void setNeverMaterial()
    {
        thisType = baloonType.never;
        mainPartBaloon.material = neverGiveUpMaterial;
        text.text = "Never Give\nUp!";
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * Physics.gravity.magnitude * gravityMagnitudeMultiplier);
        GetComponent<Rigidbody>().AddForce(Vector3.left * Physics.gravity.magnitude * leftMovement);
    }

    private void setTilt()
    {
        zRotation = calcLogistics(1f, 1f, 1.5f, animTime) * 26f;
        GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, zRotation);

        if (zRotation > 9.9f)
        {
            direction = -1f;
        }
        if (zRotation < -9.9f)
        {
            direction = 1f;
        }

        if (direction > 0f)
        {
            animTime += Time.deltaTime;
        }
        else
        {
            animTime -= Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        score.incrimentScore();
        checkIfMantraIsPlaying();
        ASPop.Play();
        Destroy(this.gameObject);
        //checkIfFinished();
    }

    private void checkIfMantraIsPlaying()
    {
        if (!AS.isPlaying)      //  If not then play the clip
        {
            setAudioClip();
            AS.Play();
        }
    }

    private void setAudioClip()
    {
        string clipName = "";

        switch (thisType)
        {
            case baloonType.good:
                {
                    clipName = "LookForGood";
                    clipName = getFullScriptString(StaticData.goodClipCounter, clipName, lfg);
                    StaticData.goodClipCounter++;
                    break;
                }
            case baloonType.calm:
                {
                    clipName = "LookForCalm";
                    clipName = getFullScriptString(StaticData.calmClipCounter, clipName, lfc);
                    StaticData.calmClipCounter++;
                    break;
                }
            case baloonType.both:
                {
                    clipName = "UseBothOptions";
                    clipName = getFullScriptString(StaticData.bothClipCounter, clipName, ubo);
                    StaticData.bothClipCounter++;
                    break;
                }
            case baloonType.never:
                {
                    clipName = "NeverGiveUp";
                    clipName = getFullScriptString(StaticData.neverClipCounter, clipName, ngu);
                    StaticData.neverClipCounter++;
                    break;
                }
            default: break;
        }

        //Debug.Log(clipName);

        AS.clip = (AudioClip)Resources.Load(clipName);
        //AS.clip = Resources.Load<Sprite>("Images/Avatars/" + StaticData.AvatarImageName);
    }

    private string getFullScriptString(int count, string prefix, List<int>suffix)
    {
        string rtrn = prefix;
        
        if (suffix[count % suffix.Count] != 0)
        {
            rtrn += suffix[count % suffix.Count].ToString();
        }
        rtrn = "Audio/Mantras/" + rtrn;
        return rtrn;
    }


    /// <summary>
    /// This function calculates the S curve for the z rotation 
    /// </summary>
    /// <param name="L">Max value (1)</param>
    /// <param name="k">curve steepness (1)</param>
    /// <param name="x0">curve mid point along time axis</param>
    /// <param name="x">current time</param>
    /// <returns></returns>
    private float calcLogistics(float L, float k, float x0, float x)
    {
        float rtrn = (L/(1 + Mathf.Exp(-k*(x-x0))))-0.5f;
        return rtrn;
    }

    //  Redundant funstion that checks to see if 4 baloons have been pressed and adjusts moves to the next scene after all have been pressed
    /*private void checkIfFinished()
    {
        int completeCount = 1;
        if (baloon1 == null)
        {
            completeCount++;
        }
        if (baloon2 == null)
        {
            completeCount++;
        }
        if (baloon3 == null)
        {
            completeCount++;
        }
        if (baloon4 == null)
        {
            completeCount++;
        }

        if (completeCount > 3)
        {
            transform.localScale -= new Vector3(100000f, 100000f, 100000f);
            StartCoroutine(goToInstructions());
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/

    private IEnumerator goToInstructions()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(5);
    }

}
