using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFixed : MonoBehaviour
{
    private Rigidbody2D rb;
    private Draggable drag;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drag = GetComponent<Draggable>();
    }

    void Update()
    {

    }

    public void FindFixed()
    {
        List<Rigidbody2D> foundPaper = new List<Rigidbody2D>();
        foundPaper.Add(rb);
        List<HingeJoint2D> processedHinges = new List<HingeJoint2D>();

        // Pin = rigidbody, static
        // Pin has component HingeJoints on it
        // These component HingeJoints have attachedbodies
        // Problem: Paper does not have pin / hingejoints attached to it

        // Keep looping through all hinge joints
        // If hingejoint is attached to a PAPER body we want, we consider it
        // Get the rigidbody the hingejoint is on (THE PIN)
        // if it is static, explode

        bool found = true;
        bool foundStatic = false;
        while (found)
        {
            found = false;
            var foundHinges = FindObjectsOfType<HingeJoint2D>();
            // Look at all hinges in the scene
            foreach (HingeJoint2D hinge in foundHinges)
            {
                // Dont double process hinges
                if (processedHinges.Contains(hinge))
                {
                    continue;
                }

                // Debug.Log("Hing eon paper " + hinge.connectedBody);

                // Process hinge if not procesed, and is on a paper we want
                if (!foundPaper.Contains(hinge.connectedBody))
                {
                    continue;
                }

                // Process all other hinges on this hinge
                found = true;
                processedHinges.Add(hinge);
                // Get the pin it belongs to and all other hinges
                Rigidbody2D body = hinge.attachedRigidbody;
                if (body.bodyType == RigidbodyType2D.Static)
                {
                    foundStatic = true;
                    break;
                }
                // Loop through all other hinges at this point, and add their papers
                HingeJoint2D[] newHinges = body.GetComponents<HingeJoint2D>();
                // Debug.Log("Found " + newHinges.Length + " on this pin");
                foreach (HingeJoint2D newHinge in newHinges)
                {
                    if (!foundPaper.Contains(newHinge.connectedBody))
                    {
                        foundPaper.Add(newHinge.connectedBody);
                    }
                }
            }
            if (foundStatic)
            {
                break;
            }
        }
        if (foundStatic)
        {
            Debug.Log("shouldnt move");
            drag.isFixed = true;
        }
        else
        {
            Debug.Log("can move");
            drag.isFixed = false;
        }
    }
	
	private void OnMouseDown()
    {
		FindFixed();
	}
}
