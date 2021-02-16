using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5;
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
        var speedVector = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = speedVector;
    }

    void Turn(Vector2 direction) {
        var rawAngle = Vector2.SignedAngle(transform.up, direction);
        var turnDirection = Mathf.Sign(rawAngle);
        var maxRotation = rotationSpeed * Time.deltaTime;

        var angle = turnDirection * Mathf.Min(Mathf.Abs(rawAngle), maxRotation);
        transform.Rotate(Vector3.forward, angle);
    }
}
