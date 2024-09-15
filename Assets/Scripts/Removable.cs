using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removable : MonoBehaviour
{
    [SerializeField] PaperStack paperStack;
	[SerializeField] Stapler stapler;

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
	
	public void UpdateStapler(Stapler obj) {
		stapler = obj;
	}

    void OnMouseDown()
    {
        Debug.Log("Destroy object");
		stapler.RemovedStaple();
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        paperStack.hoveringOnItem = true;
    }
}
