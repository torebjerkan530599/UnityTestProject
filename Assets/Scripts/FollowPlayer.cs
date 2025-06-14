using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private readonly float speed = 150;

    // Update is called once per frame
    void LateUpdate() //Lateupdate happens on the current object (camera) after the vehicle has moved. Meaning after the Update method of the vehicle script
    {
        if (player == null) // in case no prefab is assigned, a failsafe
        {
            // Attempt to find the player from the SpawnManager
            player = SpawnManager.Instance.player;
        }

        //rotate the camera with the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(horizontalInput * speed * Time.deltaTime * Vector3.up);


        //follow the player
        transform.position = player.transform.position;


    }
}
