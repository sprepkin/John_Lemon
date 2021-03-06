using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //duration of fade variable
    public float displayImageDuration = 1f; //duration of image display
    public GameObject player; //Reference John Lemon (player) character
    public CanvasGroup exitBackgroundImageCanvasGroup; //Canvas group for the end game image
    public AudioSource exitAudio; //variable for exit audio
    public CanvasGroup caughtBackgroundImageCanvasGroup; //Canvas group for if player loses
    public AudioSource caughtAudio; //variable for caught audio

    bool m_IsPlayerAtExit; //variable for if player is at the exit
    bool m_IsPlayerCaught; //variable for if player is caught
    float m_Timer; //variable for timer
    bool m_HasAudioPlayed; //variable if audio has played

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

    //executes caught player
    public void CaughtPlayer()
    {
        //player is set to caught
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        //check if player is at exit
        if (m_IsPlayerAtExit)
        {
            //trigger exit end of level
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        //check if player was caught
        else if (m_IsPlayerCaught)
        {
            //trigger caught end of level
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    //executes on end of level
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        //if audio has played
        if (!m_HasAudioPlayed)
        {
            //play audio and set that audio has been played
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        //timer increases by change in time
        m_Timer += Time.deltaTime; 

        //change end game image's alpha by time over fade duration
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        //if the timer is greater than the fade duration and image display duration
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //if restart is called
            if (doRestart)
            {
                //load scene at start
                SceneManager.LoadScene (0);
            }
            else
            {
                //Quit the game
                Application.Quit ();
            }
        }
    }
}
