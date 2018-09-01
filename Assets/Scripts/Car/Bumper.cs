using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bumper : MonoBehaviour {
    public enum Direction { Left, Right, Front }
    public enum IntensityLevel { Moderate, Intense, Extreme }

    public Direction Position;
    public IntensityLevel Intensity;
    public PassengerController Reciever;
    
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Reciever.BumperCall(Position, Intensity);
    }
}
