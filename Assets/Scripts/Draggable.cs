using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    private Stackable posLogic;
    [SerializeField] Collider2D playArea;

    void Start()
    {
        posLogic = GetComponent<Stackable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            // mousePosInWorld.z = 0f;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posLogic.ShowFullSize();
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        Bounds objectBounds = GetComponent<Collider2D>().bounds;
        Bounds areaBounds = playArea.bounds;
        if (!areaBounds.Contains(objectBounds.min) || !areaBounds.Contains(objectBounds.max)) {
            posLogic.ResetToStack();
        }
    }
}