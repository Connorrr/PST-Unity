using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameGraphicsController : MonoBehaviour
{

    public Canvas buttonCanvas;
    public Canvas imageCanvas;
    public Canvas scoreCanvas;

    private float parentCanvasHeight;

    // Start is called before the first frame update
    void Start()
    {
        parentCanvasHeight = this.gameObject.GetComponent<RectTransform>().rect.height;
        setCanvasHeights();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHeightChanged())
        {
            setCanvasHeights();
        }
    }

    private bool hasHeightChanged()
    {
        bool hasChanged = false;

        if (parentCanvasHeight != this.gameObject.GetComponent<RectTransform>().rect.height)
        {
            parentCanvasHeight = this.gameObject.GetComponent<RectTransform>().rect.height;
            hasChanged = true;
        }

        return hasChanged;
    }

    private void setCanvasHeights()
    {
        buttonCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().rect.width, parentCanvasHeight / 4);
        imageCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().rect.width, parentCanvasHeight / 4);
        float cellHeight = buttonCanvas.GetComponent<RectTransform>().rect.height - 15;
        if ( parentCanvasHeight >= this.gameObject.GetComponent<RectTransform>().rect.width)
        {
            cellHeight = (this.gameObject.GetComponent<RectTransform>().rect.width / 5) - 5;
        }
        buttonCanvas.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellHeight, cellHeight);
        imageCanvas.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellHeight, cellHeight);
        scoreCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(cellHeight*3, (parentCanvasHeight / 4) - 5);
    }
}
