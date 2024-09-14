using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour
{
    [SerializeField] Vector3 initialPosition;
    [SerializeField] Vector3 initialScale;
    void Start()
    {
        ResetToStack();
    }

    public void ResetToStack() 
    {
        transform.position = initialPosition;
        transform.localScale = initialScale;
    }

    public void ShowFullSize() 
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
