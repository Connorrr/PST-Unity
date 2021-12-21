using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormGraphicsHandler : MonoBehaviour
{
    public Component parentView;
    public GridLayoutGroup grid;
    public float cellHeight;
    private float formWidth;
    private float windowHeight;
    private float windowWidth;
    public GameObject formText;

    // Start is called before the first frame update
    void Start()
    {
        setSizes();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentView.GetComponent<RectTransform>().rect.height != windowHeight || parentView.GetComponent<RectTransform>().rect.width != windowWidth)
        {
            setSizes();
        }
    }

    private void setSizes()
    {
        formWidth = parentView.GetComponent<RectTransform>().rect.width - (parentView.GetComponent<RectTransform>().rect.width / 6);
        windowHeight = parentView.GetComponent<RectTransform>().rect.height;
        windowWidth = parentView.GetComponent<RectTransform>().rect.width;
        Vector2 cellSize;
        if (windowHeight >= 500)
        {
            if (windowHeight > 650)
            {
                windowHeight = 650;
            }
            formText.SetActive(true);
            cellSize = new Vector2(formWidth-10, windowHeight / 6);
        }
        else
        {
            formText.SetActive(false);
            cellSize = new Vector2(formWidth-10, windowHeight / 5);
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(formWidth, windowHeight);
        grid.cellSize = cellSize;
    }
}
