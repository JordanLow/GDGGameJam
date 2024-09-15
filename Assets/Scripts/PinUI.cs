using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUI : MonoBehaviour
{
    [SerializeField] GameObject next_pin;
    
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject NextPin()
    {
        return next_pin;
    }
	
	public void Remove() {
		Destroy(gameObject);
	}
}
