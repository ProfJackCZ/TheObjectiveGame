using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private InputMaster controls;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Awake()
    {
        controls = new InputMaster();

        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>()); 
        controls.Player.Movement.canceled += ctx => Move(ctx.ReadValue<Vector2>()); 
        controls.Player.Attack.performed += ctx => Attack();
    }

    void OnEnable()
    {
        controls.Enable();
        Debug.Log("controls enabled");
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        
        Debug.Log("Debug is working");
    }

    void Attack() {
        Debug.Log("Player tries to attack.");
    }

    void Move(Vector2 direction) {
        Debug.Log("Player moved to: " + direction);  
        horizontalMove = direction.x;
        if (direction.y == 1) {
            jump = true;
        }
        if (direction.y == -1 ) {
            crouch = true;
        } else if (direction.y != -1) {
            crouch = false;  
        }
    }

    // Update is called once per frame
    /*void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

    }*/



    void FixedUpdate() {
        //Debug.Log(Time.fixedDeltaTime);
        controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, crouch, jump);
        jump = false;

    }
}
