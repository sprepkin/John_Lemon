using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player; //variable to detect player

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
}
