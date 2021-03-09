using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f; //create turn speed for character

    Animator m_Animator; //create animator animator
    Vector3 m_Movement; //create movement vector
    Rigidbody m_Rigidbody; //create rigidbody
    Quaternion m_Rotation = Quaternion.identity; //create stored rotation variable

    // Start is called before the first frame update
    void Start()
    {
        //get animator on start
        m_Animator = GetComponent<Animator>();
        //get rigidbody on start
        m_Rigidbody = GetComponent<Rigidbody>();
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

        //rotate character forward and create rotation in direction of given parameter
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    // applies root motion
    void OnAnimatorMove()
    {
        //move rigidbody and apply rotation
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
