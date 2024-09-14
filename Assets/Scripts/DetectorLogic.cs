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
        Collider2D[] colliders = new Collider2D[10];
        int numColliders = Physics2D.OverlapCollider(GetComponent<Collider2D>(), new ContactFilter2D().NoFilter(), colliders);
        outerDetectsPaper = numColliders>1;
        Debug.Log(numColliders);
        Debug.Log(colliders[0]);
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
