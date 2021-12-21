using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceButtonScalerScript : MonoBehaviour
{
    public GameObject parentCanvas;
    public float preferredCellHeight;

    private GridLayoutGroup grid;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();
        getParentDimensions();
        setCellSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentCanvas.GetComponent<RectTransform>().rect.width != width)
        {
            getParentDimensions();
            setCellSize();
        }
    }

    private void getParentDimensions()
    {
        width = parentCanvas.GetComponent<RectTransform>().rect.width;
        height = preferredCellHeight;
    }

    private void setCellSize()
    {
        float space = grid.spacing.x;
        float w = (width - space * 5) / 4;
        float h = height - space * 2;

        if ( w <= h)
        {
            grid.cellSize = new Vector2(w, w);
        }
        else
        {
            grid.cellSize = new Vector2(h, h);
        }
    }


}
