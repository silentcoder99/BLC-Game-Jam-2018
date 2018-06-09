using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigBod;
    public GameObject turret;
    public float speed;
    public string key;
    //projectile stuff
    private float fireTimer;
    public float fireRate;
    public GameObject bolt;
    private float time = 0.0f;

    void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        fireTimer = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if ((Input.GetKey(key)) && (time > fireTimer))
        {
            //fires laser
            fireTimer = time + fireRate;
            Instantiate(bolt, turret.transform.position + turret.transform.up, turret.transform.rotation);
            fireTimer = fireTimer - time;
            time = 0.0f;
            //moves player
            Vector3 movement = turret.transform.up;
            rigBod.AddForce(movement * -speed);
            //Debug.Log(rigBod.velocity);
        }
    }
}
