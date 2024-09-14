using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    private Stackable posLogic;
    [SerializeField] Collider2D playArea;
    private AudioSource audioSource;

    void Start()
    {
        posLogic = GetComponent<Stackable>();
        audioSource = GetComponent<AudioSource>();
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
        //Play sound
        audioSource.Play();
        
        Debug.Log("clicked");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posLogic.ShowFullSize();
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Bounds objectBounds = GetComponent<Collider2D>().bounds;
        Bounds areaBounds = playArea.bounds;
        if (!areaBounds.Contains(objectBounds.min) || !areaBounds.Contains(objectBounds.max)) {
            posLogic.ResetToStack();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}