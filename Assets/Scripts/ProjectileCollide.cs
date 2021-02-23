using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour {
    public float damage;
    public float radius;

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        var targets = new List<HealthSystem>();

        if (radius == 0) {
            var targetHealth = other.gameObject.GetComponent<HealthSystem>();
            if (targetHealth) {
                targets.Add(targetHealth);
            }
        }
        else {
            var entitiesWithHealth = 
                Physics2D.OverlapCircleAll(transform.position, radius)
                .Select(c => c.gameObject.GetComponent<HealthSystem>()).ToArray()
                .Where(h => h);
            targets.AddRange(entitiesWithHealth);
        }

        foreach (var target in targets) {
            target.InflictDamage(damage);
        }
    }
}
