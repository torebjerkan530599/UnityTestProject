using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movementDirection;
    private readonly float speed = 10.0f;
    private GameObject focalPoint; //parent of the Camera
    private FollowPlayer cameraFollowScript;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        cameraFollowScript = focalPoint.GetComponent<FollowPlayer>();
        cameraFollowScript.player = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
            // Get the forward direction of the camera
            Vector3 cameraForward = Camera.main.transform.forward;
            //Vector3 cameraRight = Camera.main.transform.right; // for reference only, since left/right is handled by the camera and the player does not move sideways*


            // Zero out the Y component to ensure movement is only on the XZ plane
            cameraForward.y = 0;
            cameraForward.Normalize();

            // Get input (WASD or Arrow Keys)
            //float horizontal = Input.GetAxis("Horizontal"); //*
            float vertical = Input.GetAxis("Vertical"); //only use forward facing direction

            // Combine input with camera's forward and right vectors
            movementDirection = (cameraForward * vertical); //+ (cameraRight * horizontal);
            movementDirection.y = 0; // Ensure no vertical movement
            movementDirection.Normalize();

            // Move the player
            transform.position += speed * Time.deltaTime * movementDirection;
            //transform.Translate(speed * Time.deltaTime * movementDirection); //Local space by default, and less control compared to line above
    }

}

