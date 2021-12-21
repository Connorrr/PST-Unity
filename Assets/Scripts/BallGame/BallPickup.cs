using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    public AudioSource AS;


    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickupHit()
    {
        if (isActive)
        {
            GetComponent<MeshRenderer>().enabled = false;
            AS.Play();
            isActive = false;
        }
    }
}
