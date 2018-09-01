using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerController : MonoBehaviour {

    [HideInInspector]
    public VoiceLine lastVoiceLineStarted;
    public AudioSource audioSource;

    public Passenger passenger;

    public Emotion emotion;
    public enum Emotion {
        Neutral,
        Pissed
    }

    public void BumperCall(Bumper.Direction direction, Bumper.IntensityLevel intensity)
    {
        Debug.Log("BumperCall");

        // These responses are mostly panic based. If the intensity is moderate, then the emotion takes part,
        // but any closer and it's pure panic
        Passenger.Directions sound_pool = null;
        switch (intensity)
        {
            case Bumper.IntensityLevel.Moderate:
                break;
            case Bumper.IntensityLevel.Intense:
                sound_pool = passenger.intense;
                Debug.Log("Intense");
                break;
            case Bumper.IntensityLevel.Extreme:

                break;
        }

        if (sound_pool == null) return;

        switch (direction) {
            case Bumper.Direction.Front:
                PlaySound(sound_pool.front);
                break;
            case Bumper.Direction.Right:
                PlaySound(sound_pool.right);
                break;
            case Bumper.Direction.Left:
                PlaySound(sound_pool.left);
                break;
        }
    }

    public void PlaySound(AudioClip[] clips)
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
