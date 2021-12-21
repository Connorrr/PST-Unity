using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrialGraphicalHandler : MonoBehaviour {

    public RectTransform panel;
    public GridLayoutGroup grid;

    private float panelHeight;
    private float cellHeight;
    private float gridCellSize;

    // Use this for initialization
    void Start()
    {
        panelHeight = panel.rect.height;
        cellHeight = panelHeight / 4;
        updateGDimensions();
    }

    // Update is called once per frame
    void Update()
    {
        if (panelHeight != panel.rect.height)
        {
            panelHeight = panel.rect.height;
            cellHeight = panelHeight / 4;
            updateGDimensions();
        }
    }

    //  Updates the graphical dimensions
    void updateGDimensions()
    {
        setStaticSpacing();
        setCellSize();
    }

    private void setCellSize()
    {
        gridCellSize = (panelHeight / 4) - StaticData.SpreadSpacing;
        grid.cellSize = new Vector2(gridCellSize, gridCellSize);
        setStaticSpacing();
        if ( StaticData.isSpread)
        {
            grid.spacing = new Vector2(StaticData.SpreadSpacing, StaticData.SpreadSpacing);
        }
        else
        {
            grid.spacing = new Vector2(StaticData.NarrowSpacing, StaticData.NarrowSpacing);
        }
        StaticData.gridCellSize = gridCellSize;
    }

    private void setStaticSpacing()
    {
        StaticData.SpreadSpacing = cellHeight / 5;
        StaticData.NarrowSpacing = cellHeight / 20;
    }

}
