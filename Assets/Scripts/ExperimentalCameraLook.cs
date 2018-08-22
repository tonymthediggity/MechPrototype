using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalCameraLook : MonoBehaviour {

    public GameObject player;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = player.transform.position - (transform.position * 1.5f);
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed ;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);
        

        

        float desiredAngleY = player.transform.eulerAngles.y;
        float desiredAngleX = player.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredAngleX, desiredAngleY, 0);
        
        transform.position = player.transform.position - (rotation * offset);
        

        transform.LookAt(player.transform.position);
    }
}
