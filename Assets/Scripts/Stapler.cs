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
        if (!toggleScript.hoveringOnItem)
        {
            PlaceStaple();
        }
    }

    void PlaceStaple()
    {
		if (numStaples <= 0) return;
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);

        if (colliders.Length > 0)
        {
            GameObject newStaple = Instantiate(staple, mousePosInWorld, Quaternion.identity);
			numStaples--;
			stapleUI.RemoveStaple();
            foreach (Collider2D collider in colliders)
            {
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
	}
}
