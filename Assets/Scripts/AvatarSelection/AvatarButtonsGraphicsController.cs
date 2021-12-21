using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonsGraphicsController : MonoBehaviour
{

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;

    public Button rightButton;
    public Button leftButton;

    public GameObject parentCanvas;

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
        rightButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth/8, parentWidth / 8);
        leftButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth / 8, parentWidth / 8);
    }

    }
