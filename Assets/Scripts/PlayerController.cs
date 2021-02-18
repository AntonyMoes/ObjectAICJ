using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    ThrusterSystem _thrusters;
    InputController _inputController;
    Vector2 _moveDirection;
    Vector2 _lookDirection;
    
    Camera _mainCamera;

    void Start() {
        _thrusters = GetComponent<ThrusterSystem>();
        _inputController = GetComponent<InputController>();
        _mainCamera = Camera.main;
    }

    void Update() {
        switch (_inputController.State) {
            case InputController.EInputState.MouseKeyboard:
                (_moveDirection, _lookDirection) = GetMouseKeyboardInputs();
                break;
            case InputController.EInputState.Controller:
                (_moveDirection, _lookDirection) = GetControllerInputs();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    (Vector2, Vector2) GetMouseKeyboardInputs() {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");
        var moveVertical = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector2(moveHorizontal, moveVertical);
        
        var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var lookDirection = mousePos - transform.position;
        return (moveDirection, lookDirection);
    }
    
    (Vector2, Vector2) GetControllerInputs() {
        var moveHorizontal = Input.GetAxisRaw("MoveHorizontal");
        var moveVertical = Input.GetAxisRaw("MoveVertical");
        var moveDirection = new Vector2(moveHorizontal, moveVertical);
        
        var lookHorizontal = Input.GetAxisRaw("LookHorizontal");
        var lookVertical = Input.GetAxisRaw("LookVertical");
        var lookDirection = new Vector2(lookHorizontal, lookVertical);
        return (moveDirection, lookDirection);
    }

    void FixedUpdate() {
        _thrusters.Move(_moveDirection);
        _thrusters.Turn(_lookDirection);
    }
}
