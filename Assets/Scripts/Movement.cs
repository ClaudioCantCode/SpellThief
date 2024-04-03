using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float JumpTime = 0.3f;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float JumpTimer;
   
    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump")) { 
            isJumping = true;
            rb.velocity = Vector2.up * jumpforce;
           }
        if (isJumping && Input.GetButton("Jump")) {
            if (JumpTimer < JumpTime) {
                rb.velocity = Vector2.up * jumpforce;
                
                JumpTimer += Time.deltaTime;
            } else { 
                isJumping = false;
            }

        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
            JumpTimer = 0;
        }

    }
}
