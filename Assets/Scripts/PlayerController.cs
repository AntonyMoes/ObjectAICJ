using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    ThrusterSystem _thrusters;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _mousePos;

    void Start() {
        _thrusters = GetComponent<ThrusterSystem>();
    }

    void Update() {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        var inputs = new Vector2(_horizontalInput, _verticalInput);
        _thrusters.Move(inputs);
        
        var direction = ((Vector2) (_mousePos - transform.position)).normalized;
        _thrusters.Turn(direction);
    }
}
