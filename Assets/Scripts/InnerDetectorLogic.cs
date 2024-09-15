using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InnerDetectorLogic : MonoBehaviour
{
    public bool touchingPaper;
    private int numCol;
    void Start()
    {
        numCol = 1;
        touchingPaper = false;
    }

    void Update()
    {
        touchingPaper = numCol > 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            //Debug.Log("touching" +gameObject.name);
            numCol++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            //Debug.Log("touching" +gameObject.name);
            numCol++;
        }
    }
}
