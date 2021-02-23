using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class AbilityRapid : Ability {
    const float Cooldown = 2;

    const float ShootDelay = 0.04f;
    const int ProjectileCount = 3;
    Object _projectilePrefab;

    public AbilityRapid() : base(Cooldown) {}

    void Start() {
        _projectilePrefab = Resources.Load("Prefabs/RapidProjectile");
    }

    protected override void ActivationLogic(Transform projectileSpawnPoint) {
        StartCoroutine(Shoot(projectileSpawnPoint));
    }

    IEnumerator Shoot(Transform projectileSpawnPoint) {
        for (var i = 0; i < ProjectileCount; i++) {
            Instantiate(_projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            yield return new WaitForSeconds(ShootDelay);
        }
    }
}
