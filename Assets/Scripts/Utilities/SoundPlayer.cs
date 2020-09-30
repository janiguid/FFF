using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public enum soundName{
        RealmOne,
        RealmTwo,
        BuildUp,
        BattleMusic,
        Calm,
        Triumph
    }

    [SerializeField] soundName soundToPlay;
    [SerializeField] float distanceBeforeStopping;
    [SerializeField] float minDistanceBeforePlaying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioManager.Instance.PlayAudio(soundToPlay.ToString());
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (AudioManager.Instance == null) return;
            if (AudioManager.Instance.IsPlaying() == false)
            {
                AudioManager.Instance.PlayAudio(soundToPlay.ToString());
                print("found player");
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.Instance.StopAudio();

        }
    }

}
