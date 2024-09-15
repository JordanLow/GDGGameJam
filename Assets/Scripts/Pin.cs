using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject pin;
    [SerializeField] PaperStack paperStack;
    [SerializeField] private int numofPins;
	[SerializeField] PinUI firstPinIndicator;
	[SerializeField] PolygonCollider2D pinnableZone;

    private bool triggered;

    void Start()
    {
        pin.GetComponent<Removable>().UpdatePaperStack(paperStack);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!triggered && !paperStack.hoveringOnItem)
            {
                PlacePin();
            }
            triggered = true;
        }
        else
        {
            triggered = false;
        }
    }

    void PlacePin()
    {
		if (numofPins <=0 || !paperStack.isFrozen) return;
        Debug.Log("PlacePin");
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;
		if (!pinnableZone.OverlapPoint(mousePosInWorld)) return;
        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);
        GameObject newPin = Instantiate(pin, mousePosInWorld, Quaternion.identity);
		numofPins--;
		try {
			GameObject nextpin = firstPinIndicator.NextPin();
			firstPinIndicator.Remove();
			firstPinIndicator = nextpin.GetComponent<PinUI>();
		} catch {
			Debug.Log("outta pins");
		}
		foreach (Collider2D collider in colliders)
		{
			Rigidbody2D rb = collider.attachedRigidbody;
			if (rb != null)
			{
				HingeJoint2D hinge = newPin.AddComponent<HingeJoint2D>();
				hinge.connectedBody = rb;
			}
		}
    }
}
