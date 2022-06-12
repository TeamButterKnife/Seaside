using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShuttleMovement : MonoBehaviour
{
    public float speed;
    public int lives;

    public bool canMove = true;

    private Rigidbody2D rigidbody2D;

    [SerializeField] Vector2 inputWatcher;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = new Vector2( this.transform.position.x + speed * inputWatcher.x * Time.deltaTime, this.transform.position.y);
        if(canMove)
        {
            rigidbody2D.velocity = new Vector2(speed * inputWatcher.x, speed * inputWatcher.y);
        }
    }

    private void OnMove(InputValue moveInput)
    {
       Vector2 movementVector = moveInput.Get<Vector2>();
       inputWatcher = movementVector;
       Debug.Log(movementVector);
    }

    public void CanTalk(GameObject focus)
    {
        Debug.Log("We can talk to " + focus.name);
    }
    public void CannotTalk(GameObject focus)
    {
        Debug.Log("We can't talk to " + focus.name);
    }
}
