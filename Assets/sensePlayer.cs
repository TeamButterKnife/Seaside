using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Hero")
        {
            Debug.Log("Hello world, You're close enough to talk!");
        }
    }
}
