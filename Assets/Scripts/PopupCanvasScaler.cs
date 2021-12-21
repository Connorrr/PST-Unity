using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCanvasScaler : MonoBehaviour
{

    private float parentWidth;
    private float parentHeight;

    // Start is called before the first frame update
    void Start()
    {
        setLocalVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentWidth != transform.parent.gameObject.GetComponent<RectTransform>().rect.width || parentHeight != transform.parent.gameObject.GetComponent<RectTransform>().rect.height)
        {
            setLocalVariables();
            setCanvasSize();
        }
    }

    private void setLocalVariables()
    {
        parentWidth = transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        parentHeight = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
    }

    private void setCanvasSize()
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth * 0.6f, parentHeight * 0.6f);
    }
}
