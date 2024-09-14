using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject pin;
    [SerializeField] PaperStack paperStack;
    [SerializeField] private int numofPins;

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
        Debug.Log("PlacePin");
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);

        Debug.Log(colliders);

        if (colliders.Length > 0)
        {
            GameObject newPin = Instantiate(pin, mousePosInWorld, Quaternion.identity);
            numofPins--;
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
}
