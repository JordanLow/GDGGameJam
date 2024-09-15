using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorLogic : MonoBehaviour
{
    private bool outerDetectsPaper;
    [SerializeField] PaperStack paperStack;
    [SerializeField] LevelComplete levelComplete;
	[SerializeField] TMP_Text timer; 
	[SerializeField] float checkDuration;

    public List<InnerDetectorLogic> innerDetectors = new List<InnerDetectorLogic>();
    public int numInner;
	private float timeLeft;

    void Start()
    {
		timeLeft = checkDuration;
		timer.text = string.Format("{0:N1}", timeLeft);
    }
	
	void Update() {
		timer.text = string.Format("{0:N1}", timeLeft);
		if (timeLeft == -999f) {
			return;
		}
		if (timeLeft <= 0) {
			timer.text = "0.0";
			timeLeft = -999f;
            levelComplete.CompletedLevel();
			return;
		}
		if (paperStack.isFrozen) {
			timeLeft = checkDuration;
		} else {
			if (DetermineCompletion()) {
				timeLeft -= Time.deltaTime;
			} else {
				timeLeft = checkDuration;
			}
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
        //Debug.Log("Touching: " + touchingCount);
        return touchingCount == numInner;
    }

    public void RestartLevel()
    {
        levelComplete.RetryLevel();
    }

    public bool DetermineCompletion()
    {
        Collider2D[] colliders = new Collider2D[10];
        int numColliders = Physics2D.OverlapCollider(GetComponent<Collider2D>(), new ContactFilter2D().NoFilter(), colliders);
        outerDetectsPaper = numColliders > 1;
        return !(outerDetectsPaper || !CheckInnerDetectors());
    }
}