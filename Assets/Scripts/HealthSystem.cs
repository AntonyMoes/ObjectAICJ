using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour {
    [SerializeField] float maxHealth;
    public float MaxHealth => maxHealth;
    float _currentHealth;
    public float CurrentHealth => _currentHealth;

    void Start() {
        _currentHealth = maxHealth;
    }
    
    public void InflictDamage(float damage) {
        _currentHealth -= Mathf.Min(_currentHealth, damage);
        if (_currentHealth == 0) {
            Destroy(gameObject);
        }
    }
}
