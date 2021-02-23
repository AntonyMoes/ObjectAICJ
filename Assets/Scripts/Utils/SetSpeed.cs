using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpeed : MonoBehaviour {
    public float speed;
    
    void Start() {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
}
