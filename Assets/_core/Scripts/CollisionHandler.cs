using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Class to print out what the player object has collided with.

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " has triggered " + other.gameObject.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " has collided with " + collision.gameObject.name);
    }


}
