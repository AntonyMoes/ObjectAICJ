using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {
    readonly float _maxCooldown;
    public float MaxCooldown => _maxCooldown;
    float _currentCooldown;
    public float CurrentCooldown => _currentCooldown;
    bool _isOnCooldown;

    public Ability(float maxCooldown) {
        _maxCooldown = maxCooldown;
    }
    
    // Need to pass several args:
    // 1) Projectile spawn point
    // 2) Ship's rigidbody
    // 3) Ship's transform
    // 4) Inputs
    // I'll start using as few of these as possible

    public void Activate(Transform projectileSpawnPoint) {
        if (_isOnCooldown) {
            return;
        }

        _isOnCooldown = true;
        _currentCooldown = _maxCooldown;
        ActivationLogic(projectileSpawnPoint);
    }

    protected abstract void ActivationLogic(Transform projectileSpawnPoint);

    void Update() {
        if (!_isOnCooldown) {
            return;
        }
        
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown <= 0) {
            _isOnCooldown = false;
        }
    }
}
