using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    private Transform playerPosition;
    public bool followPlayerRotation;
    public float rotationSpeed = 10f;
	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            playerPosition = player.transform;
        }
        SetMinimapIcons();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerPosition)
        {
            transform.position = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z);
            if (followPlayerRotation)
            {
                Quaternion to = Quaternion.Euler(90f, playerPosition.rotation.eulerAngles.y, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, to, rotationSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            }
        }
	}
    public void SetMinimapIcons()
    {
        

    }
    
}
