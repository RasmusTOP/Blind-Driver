using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour {

    [HideInInspector]
    public VoiceLine lastVoiceLineStarted;
    public AudioSource audioSource;

    public Emotion emotion;
    public enum Emotion {
        Neutral,
        Pissed
    }

    public void BumperCall(Bumper.Direction direction, Bumper.IntensityLevel intensity)
    {
        // Todo: Add logic for responses depending on passenger and emotion
    }
}
