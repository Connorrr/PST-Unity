using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarButton : MonoBehaviour {

    public Button avatarButton;

    private Image buttonImage;

	// Use this for initialization
	void Start () {
        Debug.Log("Avatar button started");
        buttonImage = avatarButton.gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToInstructions()
    {
        Debug.Log("We in GoToInstructions");
        StaticData.AvatarImageName = buttonImage.sprite.name;
        Debug.Log("This is the avatar image name: " + buttonImage.sprite.name);
        SceneManager.LoadScene(3);
    }

}
