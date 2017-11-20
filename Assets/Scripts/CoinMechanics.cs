using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMechanics : MonoBehaviour {
    //this is a variable of the type AudioSource
    private AudioSource audioSource = new AudioSource();
    private BoxCollider2D boxCollider2D = new BoxCollider2D();
    private SpriteRenderer spriteRenderer = new SpriteRenderer();

    public static int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectCoin();
    }

    private void Start()
    {
        /* this searches the game object for the component AudioSource
        and applies it to the instance of the class we made up there.
        this is initialized now. I can reach it and change shit.
        anything I do to audioSource changes my Coin's AudioSource component */
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void CollectCoin()
    {
        audioSource.Play();

        //make it so you cant touch it
        boxCollider2D.enabled = false;

        //make it so you can't see it
        spriteRenderer.enabled = false;

        //add 10 to score
        IncreaseScore();
        
    }

    void IncreaseScore()
    {
        score = score + 10;
    }
}
