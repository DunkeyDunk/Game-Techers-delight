using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed = 10;
    private float moveInputx;
    private float moveInputy;
    private float rotationAngle;
    private bool dashing;
    private Rigidbody2D rb;
    public Transform sword;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
            //simple movement
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
        rotateSword();
    }

    IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.2f);
        dashing = false;
        Debug.Log("dash end");
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0, 0);
    }

        //function til at rotate sword alt efter hvilken vej du går
    void rotateSword()
    {
        //right
        if(moveInputx == 1 && moveInputy == 0)
        {
            rotationAngle = 0;
        }

        //down and right
        if(moveInputx == 1 && moveInputy == -1)
        {
            rotationAngle = -45;
        }

        //down
        if (moveInputx == 0 && moveInputy == -1)
        {
            rotationAngle = -90;
        }

        //down and left
        if (moveInputx == -1 && moveInputy == -1)
        {
            rotationAngle = -135;
        }

        //left
        if (moveInputx == -1 && moveInputy == 0)
        {
            rotationAngle = -180;
        }

        //up and left
        if (moveInputx == -1 && moveInputy == 1)
        {
            rotationAngle = -225;
        }

        //up
        if (moveInputx == 0 && moveInputy == 1)
        {
            rotationAngle = -270;
        }

        //up and right
        if (moveInputx == 1 && moveInputy == 1)
        {
            rotationAngle = -315;
        }

        //handles sword rotation
        sword.RotateAround(this.transform.position, new Vector3(0,0,1), rotationAngle);
    }
}
