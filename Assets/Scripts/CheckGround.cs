﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public CharacterController characterController;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ground")) {
            characterController.IsGrounded = true;
        }
    }
}
