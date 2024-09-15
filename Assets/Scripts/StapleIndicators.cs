using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleIndicators : MonoBehaviour
{
	[SerializeField] List<SpriteRenderer> indicators;
    private int top = 0;

    public void RemoveStaple() {
		indicators[top].enabled = false;
		top++;
	}
	
	public void AddStaple() {
		indicators[top-1].enabled = true;
		top--;
	}
}
