using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigBod;
    public GameObject turret;
    public GameObject prompt;
    public float speed;
    public string key;
    private bool init;
    //colour stuff
    private SpriteRenderer sprite;
    public Color colour;
    //projectile stuff
    private float fireTimer;
    public float fireRate;
    public GameObject bolt;
    private float time = 0.0f;
    //colliders
    public CircleCollider2D colliderTrigger;
    public CircleCollider2D colliderPhysics;


    void Start()
    {
       
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rigBod = gameObject.GetComponent<Rigidbody2D>();
        fireTimer = 0.0f;
        init = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if ((Input.GetKey(key)) && (time > fireTimer))
        {
            if (!init) {
                colliderPhysics.enabled = true;
                colliderTrigger.enabled = true;
                sprite.color = colour;
                Destroy(prompt);
                init = false;
            }
            //fires laser
            fireTimer = time + fireRate;
            Instantiate(bolt, turret.transform.position + turret.transform.up, turret.transform.rotation);
            fireTimer = fireTimer - time;
            time = 0.0f;

            //Go pew
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            //moves player
            Vector3 movement = turret.transform.up;
            rigBod.AddForce(movement * -speed);
            //Debug.Log(rigBod.velocity);
        }
    }
}
