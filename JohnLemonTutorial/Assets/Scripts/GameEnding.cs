using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //duration of fade variable
    public GameObject player; //Reference John Lemon (player) character

    bool m_IsPlayerAtExit; //variable for if player is at the exit

    //executes on trigger of collider
    void OnTriggerEnter(Collider other)
    {
        //make sure only John Lemon can trigger
        if (other.gameObject == player)
        {
            //set player is at exit to true
            m_IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        //check if exit is set
        if (m_IsPlayerAtExit)
        {

        }
    }
}
