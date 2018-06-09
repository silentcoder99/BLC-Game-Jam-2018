using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigBod;
    public GameObject turret;
    //projectile stuff
    private float fireTimer;
    public float fireRate;
    public GameObject bolt;
    private float myTime = 0.0F;

    void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        fireTimer = 0.0f;
    }

    void Update()
    {
        myTime += Time.deltaTime;
        if ((Input.GetButton("Fire1")) && (myTime > fireTimer))
        {
            fireTimer = myTime + fireRate;
            Instantiate(bolt, turret.transform.position, turret.transform.rotation);
            fireTimer = fireTimer - myTime;
            myTime = 0.0f;
        }
    }
}
