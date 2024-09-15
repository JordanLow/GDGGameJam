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

    public void UpdatePaperStack(PaperStack obj)
    {
        paperStack = obj;
    }
	
	public void UpdateStapler(Stapler obj) {
		stapler = obj;
	}

   /* void OnMouseDown()
    {
        Debug.Log("Destroy object");
		stapler.RemovedStaple();
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        paperStack.hoveringOnItem = true;
    }*/
	
	void Update()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0f;
		if (GetComponent<Collider2D>().bounds.Contains(mousePos)) {
			Debug.Log("Hovering");
			paperStack.hoveringOnItem = true;
		}
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log(GetComponent<Collider2D>().bounds);
			
		}
		if (Input.GetMouseButtonDown(0) && GetComponent<Collider2D>().bounds.Contains(mousePos)) {
			Debug.Log("Destroy object");
			stapler.RemovedStaple();
			Destroy(gameObject);
		}
	}
}
