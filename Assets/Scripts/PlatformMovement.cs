using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    float amountToChangeBy = .2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update (){
        
	}

    void FixedUpdate()
    {
        MovePlatform();
    }


    void MovePlatform()
    {
        if (ButtonScript.buttonPressed == true)
        {
            ChangePosition();
            if (transform.position.x <= 37)
            {
                GoForward();
            }

            if (transform.position.x >= 52)
            {
                GoBackward();
            }
        }
    }

    void GoForward()
    {
        amountToChangeBy = .1f;
    }

    void GoBackward()
    {
        amountToChangeBy = -.1f;
    }

    void ChangePosition()
    {
        transform.Translate(amountToChangeBy, 0, 0);
    }
}
