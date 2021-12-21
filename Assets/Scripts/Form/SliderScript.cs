using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;
    public Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(delegate { updateRateTextValue(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateRateTextValue()
    {
        valueText.text = slider.value.ToString();
    }
}
