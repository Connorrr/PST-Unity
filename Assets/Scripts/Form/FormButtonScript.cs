using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormButtonScript : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip toPlay;

    public Button b0;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;

    public int questionIndex;

    public ScrollRect scroller;

    public SubmitButtonScript submitButton;

    public bool isSelectable;

    public FormButtonScript nextButton;

    private GridLayoutGroup grid;
    private float gridWidth;
    private float gridHeight;

    private void Start()
    {
        resetButtonBackgrounds();
        setButtonActive(isSelectable);
        grid = GetComponent<GridLayoutGroup>();
        gridWidth = GetComponent<RectTransform>().rect.width;
        gridHeight = GetComponent<RectTransform>().rect.height;
    }

    private void Update()
    {
        if (GetComponent<RectTransform>().rect.height != gridHeight)
        {
            gridHeight = GetComponent<RectTransform>().rect.height;
            setCellSize();
        }else if (GetComponent<RectTransform>().rect.width != gridWidth)
        {
            gridWidth = GetComponent<RectTransform>().rect.width;
            setCellSize();
        }
    }

    private void setCellSize()
    {
        float maxCellSize = gridHeight;
        float maxWidth = (maxCellSize * 11) + 12;
        
        if (gridWidth > maxWidth)
        {
            grid.cellSize = new Vector2(maxCellSize, maxCellSize);
            Debug.Log("Size: " + maxCellSize);
        }
        else
        {
            float newCellSize = (gridWidth - 12) / 11;
            grid.cellSize = new Vector2(newCellSize, newCellSize);
            Debug.Log("Size: " + newCellSize);
        }
    }

    public void selectButton( int index)
    {
        resetButtonBackgrounds();
        switch (index)
        {
            case 0:
                b0.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 1:
                b1.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 2:
                b2.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 3:
                b3.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 4:
                b4.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 5:
                b5.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 6:
                b6.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 7:
                b7.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            case 8:
                b8.GetComponent<Image>().color = new Color32(0, 0, 225, 255);
                submitButton.questionAnswered(questionIndex, index);
                break;
            default:
                Debug.Log("Error: FormButtonScript: selectButton: Button index should be between 1-8: index = " + index);
                break;
        }

        playOnCompletion();
        if ( nextButton != null)
        {
            nextButton.setButtonActive(true);
        }

    }

    public void setButtonActive(bool isQuestionActive)
    {
        b0.interactable = isQuestionActive;
        b1.interactable = isQuestionActive;
        b2.interactable = isQuestionActive;
        b3.interactable = isQuestionActive;
        b4.interactable = isQuestionActive;
        b5.interactable = isQuestionActive;
        b6.interactable = isQuestionActive;
        b7.interactable = isQuestionActive;
        b8.interactable = isQuestionActive;
    }

    //  Plays the audio clip after selection
    private void playOnCompletion()
    {
        if (toPlay != null)
        {
            AS.clip = toPlay;
            AS.Play();
        }
    }

    private void resetButtonBackgrounds()
    {
        b0.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b1.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b2.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b3.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b4.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b5.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b6.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b7.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        b8.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
    }
}
