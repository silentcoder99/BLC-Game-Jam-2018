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
    private float time = 0.0f;

    void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        fireTimer = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if ((Input.GetButton("Fire1")) && (time > fireTimer))
        {
            Vector3 spawnPos = turret.transform.position;
       //     spawnPos.y += ;
            fireTimer = time + fireRate;
            Instantiate(bolt, spawnPos, turret.transform.rotation);
            fireTimer = fireTimer - time;
            time = 0.0f;
        }
    }
}
