using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject pin;

    void OnClick() {
        Debug.Log("click");
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);

        Debug.Log(colliders);

        if (colliders.Length > 0) {
            GameObject newPin = Instantiate(pin, mousePosInWorld, Quaternion.identity);
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
