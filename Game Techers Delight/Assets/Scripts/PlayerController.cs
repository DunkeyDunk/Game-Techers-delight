using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private float moveInputx;
    private float moveInputy;


    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        moveInputx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInputx * speed, rb.velocity.y);

        moveInputy = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveInputy * speed);
    }
}
