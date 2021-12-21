using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticData.isSendingMail = false;
        StaticData.isErrorSendingMail = false;
    }
}
