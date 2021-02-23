using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    ThrusterSystem _thrusters;
    AbilitySystem _abilities;
    InputDetector _inputDetector;
    Vector2 _moveDirection;
    Vector2 _lookDirection;

    const int PlayerAbilityCount = 2;
    List<bool> _abilityUsages = new List<bool>(PlayerAbilityCount);

    Camera _mainCamera;

    void Start() {
        _thrusters = GetComponent<ThrusterSystem>();
        _abilities = GetComponent<AbilitySystem>();
        _inputDetector = GetComponent<InputDetector>();
        _mainCamera = Camera.main;

        for (var i = 0; i < PlayerAbilityCount; i++) {
            _abilityUsages.Add(false);
        }
    }

    void Update() {
        GetInputs(_inputDetector.State);

        // fuck me for loving this shit
        // Enumerable.Range(0, PlayerAbilityCount)
        //     .Where(i => _abilityUsages[i]).ToList()
        //     .ForEach(i => _abilities.ActivateAbility(i));

        for (var i = 0; i < PlayerAbilityCount; i++) {
            if (_abilityUsages[i]) {
                _abilities.ActivateAbility(i);
            }
        }
    }

    void GetInputs(InputDetector.EInputState inputState) {
        var prefix = "";
        if (inputState == InputDetector.EInputState.Controller) {
            prefix = InputDetector.ControllerPrefix;
        }
        
        var moveHorizontal = Input.GetAxisRaw(prefix + "MoveHorizontal");
        var moveVertical = Input.GetAxisRaw(prefix + "MoveVertical");
        _moveDirection = new Vector2(moveHorizontal, moveVertical);

        if (inputState == InputDetector.EInputState.MouseKeyboard) {
            var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lookDirection = mousePos - transform.position;
        }
        else {
            var lookHorizontal = Input.GetAxisRaw("ControllerLookHorizontal");
            var lookVertical = Input.GetAxisRaw("ControllerLookVertical");
            _lookDirection = new Vector2(lookHorizontal, lookVertical);
        }

        for (var i = 0; i < PlayerAbilityCount; i++) {
            _abilityUsages[i] = Input.GetButtonDown(prefix + "Ability" + i);
        }
    }

    void FixedUpdate() {
        _thrusters.Move(_moveDirection);
        _thrusters.Turn(_lookDirection);
    }
}
