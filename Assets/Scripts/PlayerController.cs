using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float acceleration = 10;
    public float deceleration = 15;
    public float speed = 8;
    public float rotationSpeed = 360;

    Rigidbody2D rb;
    float _verticalInput;
    float _horizontalInput;
    Vector3 _mousePos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        
        Move(_verticalInput, _horizontalInput);
        
        var direction = ((Vector2) (_mousePos - transform.position)).normalized;
        Turn(direction);
    }

    void Move(float verticalInput, float horizontalInput) {
        var input = new Vector2(horizontalInput, verticalInput);
        Vector2 accelerationVector = Vector2.zero;
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

    void Turn(Vector2 direction) {
        var rawAngle = Vector2.SignedAngle(transform.up, direction);
        var turnDirection = Mathf.Sign(rawAngle);
        var maxRotation = rotationSpeed * Time.deltaTime;

        var angle = turnDirection * Mathf.Min(Mathf.Abs(rawAngle), maxRotation);
        transform.Rotate(Vector3.forward, angle);
    }
}
