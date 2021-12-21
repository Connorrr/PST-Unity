using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarScreenGraphicsHandler : MonoBehaviour
{

    public GameObject text;
    public GameObject carouselCanvas;
    public GameObject parentCanvas;
    public GameObject startButton;

    private float parentHeight;
    private float parentWidth;

    // Start is called before the first frame update
    void Start()
    {
        setParentValues();
        setChildrenSizes();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkChangeInParentSize())
        {
            setParentValues();
            setChildrenSizes();
        }
    }

    private void setParentValues()
    {
        parentHeight = parentCanvas.GetComponent<RectTransform>().rect.height;
        parentWidth = parentCanvas.GetComponent<RectTransform>().rect.width;
    }

    private bool checkChangeInParentSize()
    {
        bool hasChanged = false;

        if (parentHeight != parentCanvas.GetComponent<RectTransform>().rect.height)
        {
            hasChanged = true;
        }

        if (parentWidth != parentCanvas.GetComponent<RectTransform>().rect.width)
        {
            hasChanged = true;
        }
        return hasChanged;
    }

    private void setChildrenSizes()
    {
        float carHeight = carouselCanvas.GetComponent<RectTransform>().rect.height * carouselCanvas.GetComponent<RectTransform>().localScale.x;
        float topAndBottomSpace = (parentHeight - carHeight) / 2;
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth-20, topAndBottomSpace);
        
        /*Vector3 pos = canvas.GetComponent<RectTransform>().position;
        pos.y = (1 * (parentHeight / 2));
        canvas.GetComponent<RectTransform>().position = pos;
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth, parentHeight / 2);*/
    }
}
