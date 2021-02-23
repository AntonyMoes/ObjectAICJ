using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityJet : Ability
{
    const float Cooldown = 5;
    Object _projectilePrefab;

    public AbilityJet() : base(Cooldown) {}

    void Start() {
        _projectilePrefab = Resources.Load("Prefabs/JetProjectile");
    }

    protected override void ActivationLogic(Transform projectileSpawnPoint) {
        Instantiate(_projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }
}
