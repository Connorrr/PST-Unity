using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScaler : MonoBehaviour
{
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponent<GridLayoutGroup>().enabled = false;
        getParentDimensions();
        setButtonSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<RectTransform>().rect.width != width || transform.parent.GetComponent<RectTransform>().rect.height != height)
        {
            getParentDimensions();
            setButtonSize();
        }
    }

    private void getParentDimensions()
    {
        width = transform.parent.GetComponent<RectTransform>().rect.width;
        height = transform.parent.GetComponent<RectTransform>().rect.height;
    }

    private void setButtonSize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(250f, height / 1.5f);
    }
}
