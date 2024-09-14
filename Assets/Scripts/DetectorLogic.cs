using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorLogic : MonoBehaviour
{
    private bool outerDetectsPaper;
    public TMP_Text statusText;

    public List<InnerDetectorLogic> innerDetectors = new List<InnerDetectorLogic>();
    public int numInner;

    void Start()
    {
        statusText.text = "Not complete";
        outerDetectsPaper = false;
    }

    void Update()
    {
        outerDetectsPaper = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Paper"))
        {
            outerDetectsPaper = true;
            Debug.Log("Collider is touching paper");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            outerDetectsPaper = false;
            Debug.Log("Collider is not touching paper");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            outerDetectsPaper = true;
        }
    }

    public bool CheckInnerDetectors()
    {
        int touchingCount = 0;
        foreach (InnerDetectorLogic innerDetector in innerDetectors)
        {
            if (innerDetector.touchingPaper)
            {
                touchingCount++;
            }
        }
        Debug.Log("Touching: " + touchingCount);
        return touchingCount == numInner;
    }

    public void CheckCompletion()
    {
        Debug.Log("Outer: " + outerDetectsPaper);
        if (outerDetectsPaper || !CheckInnerDetectors())
        {
            statusText.text = "Does not fit :(";
        }
        else
        {
            statusText.text = "YAYAYAYAYYAYAYAY GOOD JOB";
        }
    }
}
