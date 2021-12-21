using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternativeWeekText : MonoBehaviour
{

    public Text InstructionText;
    public int textNumber;

    // Start is called before the first frame update
    void Start()
    {
        setText();
    }

    private void setText()
    {
        if (textNumber == 11)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen4;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen4;
            }
        }
        else if (textNumber == 13)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen5;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen5;
            }
        }
        else if (textNumber == 14)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen6;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen6;
            }
        }
        else if (textNumber == 15)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen7;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen7;
            }
        }
        else if (textNumber == 16)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen8;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen8;
            }
        }
        else if (textNumber == 17)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen9;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen9;
            }
        }
        else if (textNumber == 18)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen10;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen10;
            }
        }
        else if (textNumber == 19)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen11;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen11;
            }
        }
        else if (textNumber == 20)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen12;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen12;
            }
        }
        else if (textNumber == 21)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen13;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen13;
            }
        }
        else if (textNumber == 22)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen14;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen14;
            }
        }
        else if (textNumber == 23)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen15;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen15;
            }
        }
        else if (textNumber == 24)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen16;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen16;
            }
        }
        else if (textNumber == 25)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen17;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen17;
            }
        }
        else if (textNumber == 26)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen18;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen18;
            }
        }
        else if (textNumber == 27)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen19;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen19;
            }
        }
        else if (textNumber == 28)
        {
            if (StaticData.WeekNo == 2)
            {
                InstructionText.text = Instructions2Week23Text.week2_Screen20;
            }
            else if (StaticData.WeekNo == 3)
            {
                InstructionText.text = Instructions2Week23Text.week3_Screen20;
            }
        }
        else
        {
            Debug.Log("AlternativeText: Error: textNumber is incorrect.");
        }
    }
}
