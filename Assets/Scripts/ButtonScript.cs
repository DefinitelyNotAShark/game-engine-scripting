using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    private AudioSource audioSource = new AudioSource();
    public static bool buttonPressed = false;

    SpriteRenderer spriteRenderer = new SpriteRenderer();

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cube")
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        audioSource.Play();
        Debug.Log("Hit the button!");
        spriteRenderer.sprite = Resources.Load<Sprite>("button2");
        buttonPressed = true;

    }
}
