using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    [SerializeField] Sprite freeze;
    [SerializeField] Sprite play;
    private SpriteRenderer spriteRenderer;
    bool state = true;
    private void OnMouseDown() {
        Debug.Log("down");
        if (state) {
            spriteRenderer.sprite = freeze;
            state = !state;
        } else {
            spriteRenderer.sprite = play;
            state = !state;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
