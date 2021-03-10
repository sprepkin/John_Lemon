using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player; //variable to detect player
    public GameEnding gameEnding; //reference gameEnding class

    bool m_IsPlayerInRange; //variable if player in contact with line of sight

    //when collides with trigger
    void OnTriggerEnter(Collider other)
    {   
        //if trigger is player
        if (other.transform == player)
        {
            //player is within range
            m_IsPlayerInRange = true;
        }
    }

    //check if something is in way of player and trigger
    void OnTriggerExit(Collider other)
    {
        //if trigger is player
        if (other.transform == player)
        {
            //player isn't in range
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        //if player is in range
        if (m_IsPlayerInRange)
        {
            //variable direction is looking toward John Lemon's center
            Vector3 direction = player.position - transform.position + Vector3.up;
            //creates ray in direction of direction (above)
            Ray ray = new Ray(transform.position, direction);
            //define raycastHit variable
            RaycastHit raycastHit;

            //check if anything has been hit in the ray and in range
            if (Physics.Raycast(ray, out raycastHit))
            {
                //check if what was hit by the ray is the player
                if (raycastHit.collider.transform == player)
                {

                }
            }
        }
    }
}
