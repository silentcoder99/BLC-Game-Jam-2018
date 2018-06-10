using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public AudioClip explosion;
    public GameObject explosionParticle;
    private AudioSource audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        audio = GameObject.Find("AudioController").GetComponent<AudioSource>();

        if (!other.tag.Equals("Boundary")) {
            Debug.Log("object collision, destroying");

            //Play appropriate sound
            if (!other.tag.Equals("Boundary"))
            {

                audio.PlayOneShot(explosion);
            }
            //obstacles can only be destroyed by the boundary
            if (!other.gameObject.tag.Equals("Obstacle"))
            {
                Instantiate(explosionParticle, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }
            if (!gameObject.tag.Equals("Obstacle"))
            {
                Instantiate(explosionParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}

