using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //duration of fade variable
    public float displayImageDuration = 1f; //duration of image display
    public GameObject player; //Reference John Lemon (player) character
    public CanvasGroup exitBackgroundImageCanvasGroup; //Canvas group for the end game image
    public CanvasGroup caughtBackgroundImageCanvasGroup; //Canvas group for if player loses

    bool m_IsPlayerAtExit; //variable for if player is at the exit
    bool m_IsPlayerCaught; //variable for if player is caught
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
            //trigger exit end of level
            EndLevel(exitBackgroundImageCanvasGroup);
        //check if player was caught
        else if (m_IsPlayerCaught)
        {
            //trigger caught end of level
            EndLevel(caughtBackgroundImageCanvasGroup);
        }
    }

    //executes on end of level
    void EndLevel(CanvasGroup imageCanvasGroup)
    {
        //timer increases by change in time
        m_Timer += Time.deltaTime; 

        //change end game image's alpha by time over fade duration
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        //if the timer is greater than the fade duration and image display duration
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //quit the game
            Application.Quit();
        }
    }
}
