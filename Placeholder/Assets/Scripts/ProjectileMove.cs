using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rigBod;

    public float speed;

    void Start ()
    {
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        rigBod.velocity = transform.up * speed;
    }
}
