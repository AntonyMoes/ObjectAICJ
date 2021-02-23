using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour {
    public float acceleration;
    public float maxSpeed;
    float _currentSpeed;
    Rigidbody2D _rb;
    
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _currentSpeed += acceleration * Time.deltaTime;
        _currentSpeed = Mathf.Min(_currentSpeed, maxSpeed);
        _rb.velocity = transform.up * _currentSpeed;
    }
}
