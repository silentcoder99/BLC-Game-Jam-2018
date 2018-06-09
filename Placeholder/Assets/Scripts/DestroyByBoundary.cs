using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("object exiting boundary");
        Destroy(other.gameObject);
	}
}
