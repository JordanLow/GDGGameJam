using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaperStack : MonoBehaviour
{
    [SerializeField] private List<GameObject> paperList = new List<GameObject>();

    private Dictionary<Rigidbody2D, Vector2> originalVelocities = new Dictionary<Rigidbody2D, Vector2>();
    private Dictionary<Rigidbody2D, float> originalAngularMomentums = new Dictionary<Rigidbody2D, float>();

    private float originalGravity = 1f;
    public bool isFrozen = true; // Track toggle state, true for frozen, false for play
    [SerializeField] Sprite freeze;
    [SerializeField] Sprite play;
    [SerializeField] Image spriteRenderer;

    public bool hoveringOnItem = false;

    // Scrapped
    // private int toolSelection = 0;
    // 0: paper dragging
    // 1: stapler
    // 2: pin
    // private string[] tools = { "Dragging", "Stapler", "Pin" };

    void Start()
    {
        DisableGravity();
    }

    void Update()
    {
        hoveringOnItem = false;
    }

    // public void ChangeTool()
    // {
    //     toolSelection++;
    //     toolSelection %= 3;
    //     toolText.text = tools[toolSelection];
    // }

    // Method to disable gravity on all pieces of paper
    private void DisableGravity()
    {
        isFrozen = true;
        spriteRenderer.sprite = play;
        foreach (GameObject robj in paperList)
        {
            Rigidbody2D rb = robj.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            originalVelocities[rb] = rb.velocity;
            rb.velocity = Vector2.zero;
            originalAngularMomentums[rb] = rb.angularVelocity;
            rb.angularVelocity = 0f;
        }
    }

    // Method to re-enable gravity on all pieces of paper
    public void EnableGravity()
    {
        isFrozen = false;
        spriteRenderer.sprite = freeze;
        foreach (GameObject robj in paperList)
        {
            Rigidbody2D rb = robj.GetComponent<Rigidbody2D>();
            rb.gravityScale = originalGravity;
            rb.velocity = originalVelocities[rb];
            rb.angularVelocity = originalAngularMomentums[rb];
        }
    }

    public void Toggle()
    {
        if (isFrozen)
        {
            EnableGravity();
        }
        else
        {
            DisableGravity();
        }
    }

    public void AddElement(GameObject elem)
    {
        paperList.Add(elem);
		Debug.Log("Added: " + elem);
        this.DisableGravity();
		Debug.Log("disabling gravity");
    }
}
