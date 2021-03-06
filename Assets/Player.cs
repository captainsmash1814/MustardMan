﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 100;
    private float moveX;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            anim.SetInteger("State", 1);

        }

        PlayerMove();

    
        //if (Input.GetKeyUp(KeyCode.RightArrow))
        //{

        //    anim.SetInteger("State", 0);

        //}
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")){
            Jump();

        }
        //Animations
        //Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();


        } else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();

        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);

    }


    void FlipPlayer() {

        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}



    

