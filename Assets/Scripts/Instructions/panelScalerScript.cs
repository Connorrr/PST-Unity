using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelScalerScript : MonoBehaviour
{

    public GridLayoutGroup panel;
    public Component parentCanvas;

    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        setCellSize();
    }

    // Update is called once per frame
    void Update()
    {
        setCellSize();
    }

    private void setCellSize()
    {
        if (parentCanvas.GetComponent<RectTransform>().rect.height != screenHeight)
        {
            screenHeight = parentCanvas.GetComponent<RectTransform>().rect.height;
            float cellHeight = (screenHeight / (float)2.5) / 3;
            Vector2 cellSize = new Vector2(cellHeight, cellHeight);
            panel.cellSize = cellSize;
        }
    }
}
