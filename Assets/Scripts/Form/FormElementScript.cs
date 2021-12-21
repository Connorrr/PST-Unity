using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormElementScript : MonoBehaviour
{
    public Text header;
    public GameObject buttons;

    private float height;

    // Start is called before the first frame update
    void Start()
    {
        height = this.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<RectTransform>().rect.height != height)
        {
            height = this.GetComponent<RectTransform>().rect.height;
            header.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width, height / 2);
            buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width, height / 2);
        }
    }
}
