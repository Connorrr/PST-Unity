using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioHandler : MonoBehaviour
{

    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.isReturnFromEnd)
        {
            AS.playOnAwake = false;
            AS.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
