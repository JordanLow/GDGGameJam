using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removable : MonoBehaviour
{
    [SerializeField] PaperStack paperStack;
    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdatePaperStack(PaperStack obj)
    {
        paperStack = obj;
    }


    void OnMouseDown()
    {
        Debug.Log("Destroy object");
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        paperStack.hoveringOnItem = true;
    }
}
