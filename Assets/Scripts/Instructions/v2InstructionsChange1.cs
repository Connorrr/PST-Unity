using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class v2InstructionsChange1 : MonoBehaviour
{
    public Text textElement;
    public int sNo;         //  The screen number used to chose which text is relevant

    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.isV2)
        {
            if (sNo == 1)
            {
                textElement.text = @"Hi and welcome to the <color=#ff0000>Positive Search Program</color>
My name's Dave and the <color=#ff0000>Positive Search Program</color> is designed to help kids 
take action by learning a couple of important skills.";
            }else if(sNo == 2)
            {
                textElement.text = @"The first skill is to look for helpful things around you to focus your attention on. 

To be happy and calm in life, it is helpful to look for <color=blue>GOOD</color> things around you to focus on instead. 
That means to focus your attention on things you like and that makes you feel happy. 

They could be favourite toys, smiling faces of family and friends, your pets, nice plants and flowers, 
and happy pictures or photos around you.";
            }
            else
            {
                Debug.Log("Error:  The sNo needs to be 1-2");
            }
            

            
        }
    }
}
