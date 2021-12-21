using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

    public Button week1Button;
    public Button week2Button;
    public Button week3Button;
    public InputField idInput;

	// Use this for initialization
	void Start () {
        week1Button.interactable = false;
        week2Button.interactable = false;
        week3Button.interactable = false;
        idInput.onValueChanged.AddListener(delegate { participantIDFinished(idInput); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void participantIDFinished (InputField idField)
    {
        if (idField.text.Length > 0)
        {
            week1Button.interactable = true;
            week2Button.interactable = true;
            week3Button.interactable = true;
            StaticData.ParticipantID = idField.text;
        }
        else if(idField.text.Length == 0)
        {
            week1Button.interactable = false;
            week2Button.interactable = false;
            week3Button.interactable = false;
            Debug.Log("ID Input Field is Empty");
        }
    }
}
