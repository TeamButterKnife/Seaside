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
            // get hero by their object
            // 
            // other.game
            other.gameObject.GetComponent<PlayerTalk>().TalkRange(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.name == "Hero")
        {
            Debug.Log("You've left talking range, see you soon!");
            other.gameObject.GetComponent<PlayerTalk>().TalkRange(false);
        }
    }
}
