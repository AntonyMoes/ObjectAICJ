using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour {
    List<Ability> _abilities = new List<Ability>();
    Transform _projectileSpawnPoint;
    
    void Start() {
        _projectileSpawnPoint = transform.GetChild(0).GetComponent<Transform>();
        _abilities.Add(gameObject.AddComponent<AbilityRapid>());
        _abilities.Add(gameObject.AddComponent<AbilityJet>());
    }
    
    public void ActivateAbility(int number) {
        _abilities[number].Activate(_projectileSpawnPoint);
    }
}
