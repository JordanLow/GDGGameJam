using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDetectorLogic : MonoBehaviour
{
    public bool touchingPaper;
    void Start()
    {
        touchingPaper = false;
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            touchingPaper = true;
        }
    }
}
