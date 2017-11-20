using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float yPosition;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float cameraSpeed = 5f;

    float zOffset;
    bool cameraIsUp = false;

	// Use this for initialization
	void Start () {
        zOffset = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCameraX();
    }

    void FixedUpdate()
    {
        CheckYPosition();
    }

    void MoveCameraX()
    {
        ChangePosition();
    }

    void CheckYPosition()
    {
        //checks if player's y position is over a certain amount
        //this will only move up if the camera isn't already up.
        if (objectToFollow.transform.position.y >= 2.7 && cameraIsUp == false)
        {
            cameraIsUp = true;
            MoveYCameraUp();
        }

        else if (objectToFollow.transform.position.y <= 2.5 && cameraIsUp == true)
        {
            cameraIsUp = false;
            MoveYCameraDown();
        }
    }

    void MoveYCameraUp()
    {
        yPosition = yPosition + 5;
        ChangePosition();
    }

    void MoveYCameraDown()
    {
        yPosition = yPosition - 5;
        ChangePosition();
    }

    void ChangePosition()//this moves the camera. If i change the yPosition and then call this, it'll move the camera up!
    {
        Vector3 playerLocation =
            new Vector3(objectToFollow.position.x + xOffset,
            yPosition, zOffset);

        Vector3 adjustedPosition =//tells the camera to go from current position to new position in a certain amount of time.
            Vector3.Lerp(transform.position, playerLocation, cameraSpeed * Time.deltaTime);

        transform.position = adjustedPosition;
    }
}
