using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        GetScore();
    }

    void GetScore()
    {
        //I think this is an amalgamation of various setting of component shit.
        GetComponent<Text>().text = "Score: " + CoinMechanics.score.ToString();
    }
}
