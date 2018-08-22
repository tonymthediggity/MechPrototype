using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 9.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    public float jetPackPower;

    bool isCoolingDown = false;
    public float coolDown = 3;
    public double howLongDashLasts = 3;







    private void Start()
    {

    }


    void Update()
    {




        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCoolingDown)
        {
            Dash();
            isCoolingDown = true;


        }

        if(Input.GetKey(KeyCode.Space))
        {
            // moveDirection.y += (gravity * 2) * Time.deltaTime;
            moveDirection.y = jetPackPower * Time.deltaTime;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), jetPackPower, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


        }

        if (coolDown <= 0)
        {
            isCoolingDown = false;
            coolDown = 3;
            speed = 9;
            howLongDashLasts = 3;
        }

        if (isCoolingDown)
        {
            coolDown -= Time.deltaTime;
            howLongDashLasts -= Time.deltaTime;
        }

        if (howLongDashLasts <= 0)
        {
            speed = 0;
            speed = 9;
        }







    }

    void Dash()
    {
        speed = 30;
    }
}
