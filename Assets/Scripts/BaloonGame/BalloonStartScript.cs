using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonStartScript : MonoBehaviour
{

    public AudioSource ASPop;

    public BaloonGameScript gameScript;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnMouseDown()
    {
        ASPop.Play();
        Destroy(this.gameObject);
        gameScript.startGame();
    }
}
