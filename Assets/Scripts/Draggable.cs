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
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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
        if (!BoundedInPlay())
        {
            posLogic.ResetToStack();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
	
	private bool BoundedInPlay()
    {
        Bounds areaBounds = playArea.bounds;
		PolygonCollider2D polygon = GetComponent<PolygonCollider2D>();

        // Get all the points (vertices) of the polygon in world space
        for (int i = 0; i < polygon.points.Length; i++)
        {
            // Convert local space point to world space
            Vector2 worldPoint = polygon.transform.TransformPoint(polygon.points[i]);

            // Check if the point is inside the box bounds
            if (!areaBounds.Contains(worldPoint))
            {
                // If any point is outside the box, the polygon is not fully enclosed
                return false;
            }
        }

        // All points are inside the box
        return true;
    }
}