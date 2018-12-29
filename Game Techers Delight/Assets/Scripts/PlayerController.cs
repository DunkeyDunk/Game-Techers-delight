using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    private float moveInputx;
    private float moveInputy;
    private bool dashing;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        if (!dashing)
        {
            moveInputx = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInputx * speed, rb.velocity.y);

            moveInputy = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, moveInputy * speed);
        }
            //dash
        if(!dashing && Input.GetKeyDown(KeyCode.LeftShift))//left shift as default
        {
            dashing = true;
            Debug.Log("dash start");
            rb.velocity += rb.velocity * 2;
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.2f);
        dashing = false;
        Debug.Log("dash end");
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0, 0);
    }
}
