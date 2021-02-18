using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterSystem : MonoBehaviour {
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector2 directionInput;
    public float acceleration = 10;
    public float deceleration = 15;
    public float speed = 8;
    public float rotationSpeed = 1440;

    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 input) {
        Vector2 accelerationVector;
        if (input.magnitude != 0) {
            accelerationVector = input.normalized * acceleration;
        }
        else {
            accelerationVector = rb.velocity.normalized * (deceleration * -1);
        }
        var speedVector = rb.velocity + accelerationVector * Time.fixedDeltaTime;
        rb.velocity = ApplySpeedConstraint(speedVector, speed);
    }

    Vector2 ApplySpeedConstraint(Vector2 speed, float maxSpeed) {
        if (speed.magnitude <= maxSpeed) {
            return speed;
        }

        return speed.normalized * maxSpeed;
    }

    public void Turn(Vector2 direction) {
        if (direction == Vector2.zero) {
            direction = rb.velocity;
        }
        
        var rawAngle = Vector2.SignedAngle(transform.up, direction);
        var turnDirection = Mathf.Sign(rawAngle);
        var maxRotation = rotationSpeed * Time.deltaTime;

        var angle = turnDirection * Mathf.Min(Mathf.Abs(rawAngle), maxRotation);
        transform.Rotate(Vector3.forward, angle);
    }
}
