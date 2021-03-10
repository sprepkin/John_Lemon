using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //duration of fade variable
    public float displayImageDuration = 1f; //duration of image display
    public GameObject player; //Reference John Lemon (player) character
    public CanvasGroup exitBackgroundImageCanvasGroup; //Canvas group for the end game image

    bool m_IsPlayerAtExit; //variable for if player is at the exit
    float m_Timer; //variable for timer

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
        //check if player is at exit
        if (m_IsPlayerAtExit)
        {
            //trigger the end of the level if player is at exit
            EndLevel();
        }
    }

    //executes on end of level
    void EndLevel()
    {
        //timer increases by change in time
        m_Timer += Time.deltaTime; 

        //change exit image's alpha by time over fade duration
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        //if the timer is greater than the fade duration and image display duration
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //quit the game
            Application.Quit();
        }
    }
}
