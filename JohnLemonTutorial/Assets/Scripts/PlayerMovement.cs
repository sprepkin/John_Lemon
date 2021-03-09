using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 m_Movement; //create movement vector

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
