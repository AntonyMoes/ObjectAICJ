using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5;
    public float rotationSpeed = 360;

    void Update() {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        Move(verticalInput, horizontalInput);
        
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = ((Vector2) (mousePos - transform.position)).normalized;
        Turn(direction);
    }

    void Move(float verticalInput, float horizontalInput) {
        var movement = new Vector2(horizontalInput, verticalInput).normalized * (speed * Time.deltaTime);
        transform.Translate(movement);
    }

    void Turn(Vector2 direction) {
        var rawAngle = Vector2.SignedAngle(transform.up, direction);
        var turnDirection = Mathf.Sign(rawAngle);
        var maxRotation = rotationSpeed * Time.deltaTime;

        var angle = turnDirection * Mathf.Min(Mathf.Abs(rawAngle), maxRotation);
        transform.Rotate(Vector3.forward, angle);
    }
}
