using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour {
    // public float damage;
    // public float radius = 0;

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
