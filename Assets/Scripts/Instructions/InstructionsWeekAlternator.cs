using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsWeekAlternator : MonoBehaviour
{

    public Text Text1;
    public Text Text2;
    public Text Text3;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.WeekNo == 1)
        {
            Text1.gameObject.SetActive(true);
            Text2.gameObject.SetActive(false);
            Text3.gameObject.SetActive(false);
        }
        else if (StaticData.WeekNo == 2)
        {
            Text1.gameObject.SetActive(false);
            Text2.gameObject.SetActive(true);
            Text3.gameObject.SetActive(false);
        }
        else if (StaticData.WeekNo == 3)
        {
            Text1.gameObject.SetActive(false);
            Text2.gameObject.SetActive(false);
            Text3.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("InstructionsWeekAlternator: Start: Weekno must be between 1-3");
        }
    }
}
