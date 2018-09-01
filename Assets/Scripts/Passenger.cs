using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour {

    [HideInInspector]
    public VoiceLine lastVoiceLineStarted;
    public AudioSource audioSource;

    public Emotion emotion;
    public enum Emotion {
        Neutral = 0
    }
}
