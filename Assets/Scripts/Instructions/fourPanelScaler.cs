using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourPanelScaler : MonoBehaviour
{

    public GridLayoutGroup panel;
    public Component parentCanvas;

    private float screenWidth;
    private float space;
    private float padding;

    // Start is called before the first frame update
    void Start()
    {
        space = panel.spacing.x;
        padding = 10;
        setCellSize();
    }

    // Update is called once per frame
    void Update()
    {
        setCellSize();
    }

    private void setCellSize()
    {
        if (parentCanvas.GetComponent<RectTransform>().rect.width != screenWidth)
        {
            screenWidth = parentCanvas.GetComponent<RectTransform>().rect.width;
            float cellHeight = (screenWidth - (2*padding) - (3*space)) / 4;
            Vector2 cellSize = new Vector2(cellHeight, cellHeight);
            panel.cellSize = cellSize;
        }
    }
}
