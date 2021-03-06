﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public new Rigidbody2D rigidbody;

    // Maybe have integer of how much velocity the car has an increase it by one or decrease by one 
    // when buttons are pressed
    // Then try and adjust velocity to fit this speed

    // Public so that you can edit them in the editor
    public float wheelFriction = 10;
    public float engineAcceleration = 1;

    void FixedUpdate() {

        bool brakes = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0);
        rigidbody.MoveRotation(rigidbody.rotation - rigidbody.velocity.magnitude * Time.deltaTime * Input.GetAxisRaw("Horizontal") * 60);
        Vector2 targetVelocity = brakes ? Vector2.zero : (Vector2)Vector3.ProjectOnPlane(rigidbody.velocity, transform.up);
        Vector2 delta = targetVelocity - rigidbody.velocity;
        float skid = delta.magnitude - Time.deltaTime * wheelFriction;
        if (skid > 0)
            delta = Vector2.ClampMagnitude(delta, Time.deltaTime * wheelFriction);
        rigidbody.AddForce(delta * rigidbody.mass, ForceMode2D.Impulse);
        if (!brakes)
            rigidbody.AddForce(transform.right * rigidbody.mass * Input.GetAxisRaw("Vertical") * Time.deltaTime * engineAcceleration, ForceMode2D.Impulse);

        //todo: change engine noise based on Input.GetAxisRaw("Vertical")
        //todo: play steering wheel noise based on Input.GetAxisRaw("Vertical")
        //todo: play skid noise
        //todo: play brake pedal noise
        //todo: change wheel noise pitch based on velocity
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        PassOnCollisionEnter2DToChildren(transform, collision);
        //todo: make crash noise
    }

    private void PassOnCollisionEnter2DToChildren(Transform t, Collision2D collision) {
        for (int i = t.childCount - 1; i >= 0; i--) {
            var child = t.GetChild(i);
            foreach (var voiceLine in child.GetComponents<VoiceLine>())
                voiceLine.OnCollide(collision);
            PassOnCollisionEnter2DToChildren(child, collision);
        }
    }
}
