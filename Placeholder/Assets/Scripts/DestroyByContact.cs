using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Boundary")) {
            Debug.Log("object collision, destroying");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

