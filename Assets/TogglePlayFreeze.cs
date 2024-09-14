using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayFreeze : MonoBehaviour
{
    public List<Rigidbody2D> paperList = new List<Rigidbody2D>();

    private Dictionary<Rigidbody2D, Vector2> originalVelocities = new Dictionary<Rigidbody2D, Vector2>();
    private Dictionary<Rigidbody2D, float> originalAngularMomentums = new Dictionary<Rigidbody2D, float>();

    private float originalGravity = 1f;
    private bool isFrozen = true; // Track toggle state, true for frozen, false for play

    void Start() {
        DisableGravity();
    }

    // Method to disable gravity on all pieces of paper
    private void DisableGravity()
    {
        Debug.Log("Disabled Gravity");
        isFrozen = true;
        foreach (Rigidbody2D rb in paperList)
        {
            rb.gravityScale = 0f;
            originalVelocities[rb] = rb.velocity;
            rb.velocity = Vector2.zero;
            originalAngularMomentums[rb] = rb.angularVelocity;
            rb.angularVelocity = 0f;
            Debug.Log(rb.velocity);
            Debug.Log(rb.angularVelocity);
        }
    }

    // Method to re-enable gravity on all pieces of paper
    private void EnableGravity()
    {
        isFrozen = false;
        foreach (Rigidbody2D rb in paperList)
        {
            rb.gravityScale = originalGravity;
            rb.velocity = originalVelocities[rb];
            rb.angularVelocity = originalAngularMomentums[rb];
        }
    }

    public void Toggle()
    {
        if (isFrozen) {
            EnableGravity();
        } else {
            DisableGravity();
        }
    }
}
