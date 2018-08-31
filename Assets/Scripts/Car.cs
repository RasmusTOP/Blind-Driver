using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public new Rigidbody2D rigidbody;

    int gear;
    public float Speed {
        get {
            return gear;
        }
    }
    const float maxAcceleration = 10;
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.W) && gear < 3)
            gear++;

        if (Input.GetKeyDown(KeyCode.S) && gear > -3)
            gear--;

        if (Input.GetKeyDown(KeyCode.Space))
            gear = 0;
    }

    private void FixedUpdate() {
        rigidbody.MoveRotation(rigidbody.rotation - rigidbody.velocity.magnitude * Time.deltaTime * Input.GetAxisRaw("Horizontal") * 60);
        Vector2 targetVelocity = transform.right.normalized * Speed;
        Vector2 delta = targetVelocity - rigidbody.velocity;
        delta = Vector2.ClampMagnitude(delta, Time.deltaTime * maxAcceleration);
        rigidbody.AddForce(delta * rigidbody.mass, ForceMode2D.Impulse);
        
    }
}
