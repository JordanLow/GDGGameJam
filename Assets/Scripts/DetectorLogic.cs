using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorLogic : MonoBehaviour
{
    private bool outerDetectsPaper;
    [SerializeField] PaperStack paperStack;
    [SerializeField] LevelComplete levelComplete;

    public List<InnerDetectorLogic> innerDetectors = new List<InnerDetectorLogic>();
    public int numInner;

    void Start()
    {
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

    public void RestartLevel()
    {
        levelComplete.RetryLevel();
    }

    public void DetermineCompletion()
    {
        Collider2D[] colliders = new Collider2D[10];
        int numColliders = Physics2D.OverlapCollider(GetComponent<Collider2D>(), new ContactFilter2D().NoFilter(), colliders);
        outerDetectsPaper = numColliders > 1;
        if (outerDetectsPaper || !CheckInnerDetectors())
        {
            Invoke("RestartLevel", 3.0f);
        }
        else
        {
            levelComplete.CompletedLevel();
        }
    }

    public void CheckCompletion()
    {
        //Enable gravity
        paperStack.EnableGravity();

        // Check for completion after 3 seconds
        Invoke("DetermineCompletion", 3.0f);
    }
}