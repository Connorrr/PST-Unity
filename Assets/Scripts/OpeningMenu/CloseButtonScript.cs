using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonScript : MonoBehaviour
{
    public void closeApplication()
    {
        Debug.Log("Closing Application");
        Application.Quit();
    }
}
