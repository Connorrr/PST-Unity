using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonBlockGraphics : MonoBehaviour
{
    public GameObject parentCanvas;

    private float parentHeight;
    private float parentWidth;
    private bool shiftingRight;
    private bool shiftingLeft;

    // Start is called before the first frame update
    void Start()
    {
        shiftingRight = false;
        shiftingLeft = false;
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
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        float xSpace = grid.spacing.x;
        float buttonWidth = 2 * (parentWidth / 8);
        float cellWidth = (parentWidth - buttonWidth - (4* xSpace)) / 4;
        
        if (cellWidth < parentHeight)
        {
            grid.cellSize = new Vector2(cellWidth, cellWidth);
        }
        else
        {
            grid.cellSize = new Vector2(parentHeight, parentHeight);
        }
    }

    public void shiftRight()
    {
        shiftingRight = true;
    }

    public void shiftLeft()
    {
        shiftingLeft = true;
    }

    private void animateShiftRight()
    {
        if (!shiftingLeft)
        {

        }
    }

    private void animateShiftLeft()
    {
        if (!shiftingRight)
        {

        }
    }
}
