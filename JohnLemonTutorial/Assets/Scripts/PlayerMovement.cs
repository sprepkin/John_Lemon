﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed; //create turn speed for character

    Animator m_Animator; //create animator animator
    Vector3 m_Movement; //create movement vector

    // Start is called before the first frame update
    void Start()
    {
        //get animator on start
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //create variables for horizontal and vertical movements
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //set movement and normalize it (to a unit of 1)
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //Identify if there is player movement, is walking if vertical or horizontal have value
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //set animator to walking animation
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
    }
}
