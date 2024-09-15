using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stapler : MonoBehaviour
{
    [SerializeField] GameObject staple;
    [SerializeField] PaperStack toggleScript;
    [SerializeField] StapleIndicators stapleUI;
    [SerializeField] int numStaples;

    void Start()
    {
        staple.GetComponent<Removable>().UpdatePaperStack(toggleScript);
        staple.GetComponent<Removable>().UpdateStapler(this);
    }

    void OnRightClick()
    {
        if (!toggleScript.hoveringOnItem && toggleScript.isFrozen)
        {
            PlaceStaple();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaceStaple();
        }
    }


    void PlaceStaple()
    {
        if (numStaples <= 0 || !toggleScript.isFrozen) return;
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);
        bool touchingPaper = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Paper")) touchingPaper = true;
        }
        if (touchingPaper)
        {
            GameObject newStaple = Instantiate(staple, mousePosInWorld, Quaternion.identity);
            numStaples--;
            stapleUI.RemoveStaple();
            foreach (Collider2D collider in colliders)
            {
                if (!collider.gameObject.CompareTag("Paper")) continue;
                Rigidbody2D rb = collider.attachedRigidbody;
                if (rb != null)
                {
                    HingeJoint2D hinge = newStaple.AddComponent<HingeJoint2D>();
                    toggleScript.AddElement(newStaple);
                    hinge.connectedBody = rb;
                }
            }
        }
    }

    public void RemovedStaple()
    {
        stapleUI.AddStaple();
        numStaples++;
        Debug.Log("staples " + numStaples);
    }
}
