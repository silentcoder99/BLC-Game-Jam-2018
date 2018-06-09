using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rigBod;
    private GameObject turret;
    public float speed;

    private Vector2 one = new Vector2(1, 1);

    void Start ()
    {
        //turret = GameObject.FindWithTag("Turret1");
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        rigBod.velocity = transform.up * speed;
        //Debug.Log(turret.transform.up);
    }
}
