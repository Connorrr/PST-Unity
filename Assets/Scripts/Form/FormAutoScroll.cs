using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormAutoScroll : MonoBehaviour
{
    public ScrollRect scroll;
    public GameObject parent;

    private float normHeight;
    private float normPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(scrollDown());
        normHeight = GetComponent<RectTransform>().rect.height - parent.GetComponent<RectTransform>().rect.height;
    }

    private IEnumerator scrollDown()
    {
        yield return new WaitForSeconds(0.2f);
        float normPos = ((900f - 340f) - (parent.GetComponent<RectTransform>().rect.height/2)) /normHeight;//1.0f - ((340f + (parent.GetComponent<RectTransform>().rect.height / 2)) / (height - (parent.GetComponent<RectTransform>().rect.height / 2)));
        scroll.verticalNormalizedPosition = normPos;
        
    }

    private void Update()
    {
        if (normPos != scroll.normalizedPosition.y)
        {
            normPos = scroll.normalizedPosition.y;
            Debug.Log(normPos);
        }
    }

    private void scrollBetweenPoints()
    {
        // top = 0
        // q1 = 0.27
        // q2 = 450
        // q3 = 547
        // q4 = 647
    }

}
