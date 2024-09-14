using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorLogic : MonoBehaviour
{
    private bool detectsPaper;
    public TMP_Text statusText;

    void Start()
    {
        statusText.text = "Not complete";
        detectsPaper = false;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            detectsPaper = true;
            Debug.Log("Collider is touching paper");
        }
    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Paper"))
    //     {
    //         detectsPaper = true;
    //         Debug.Log("touching paper");
    //     }
    // }

    public void CheckCompletion()
    {
        Debug.Log(detectsPaper);
        if (detectsPaper)
        {
            statusText.text = "Does not fit :(";
        }
        else
        {
            statusText.text = "YAYAYAYAYYAYAYAY GOOD JOB";
        }
    }
}
