using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour {

    AudioSource audioSource = new AudioSource();

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            //respawn at beginning

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
