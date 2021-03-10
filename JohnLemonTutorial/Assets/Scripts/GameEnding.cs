using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //duration of fade variable
    public GameObject player; //Reference John Lemon (player) character

    //executes on trigger of collider
    void OnTriggerEnter(Collider other)
    {
        //make sure only John Lemon can trigger
        if (other.gameObject == player)
        {

        }
    }
}
