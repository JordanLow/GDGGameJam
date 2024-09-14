using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stapler : MonoBehaviour
{
    [SerializeField] GameObject staple;
    [SerializeField] TogglePlayFreeze toggleScript;

    void OnRightClick() {
        Debug.Log("click");
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorld.z = 0f;

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosInWorld);

        Debug.Log(colliders);

        if (colliders.Length > 0) {
            GameObject newStaple = Instantiate(staple, mousePosInWorld, Quaternion.identity);
            foreach (Collider2D collider in colliders)
            {
                Rigidbody2D rb = collider.attachedRigidbody;
                if (rb != null)
                {
                    HingeJoint2D hinge = newStaple.AddComponent<HingeJoint2D>();
                    toggleScript.AddElement(newStaple.GetComponent<Rigidbody2D>());
                    hinge.connectedBody = rb;
                }
            }
        }
    }
}
