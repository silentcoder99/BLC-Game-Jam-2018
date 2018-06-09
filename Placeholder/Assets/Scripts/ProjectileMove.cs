using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rigBod;
    private GameObject turret;
    public float speed;
    private float time = 0.0f;
    private Vector2 one = new Vector2(1, 1);

    void Start ()
    {
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        rigBod.velocity = transform.up * speed;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
