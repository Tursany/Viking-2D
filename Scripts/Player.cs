using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public float movespeed = 10.0f;
    public float jumpstrength = 10.0f;
    public Transform Groundcheck;
    public LayerMask whatisGround;
    public Transform spawnPosition;

    private Rigidbody2D rgbd2D;
    private Animator anim;
    private float jumptimer;
    private bool Grounded;
    private float Groundradius = 0.2f;

    void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(Groundcheck.position, Groundradius, whatisGround);

        float move = Input.GetAxis("Horizontal");

        rgbd2D.velocity = new Vector2(move * movespeed, rgbd2D.velocity.y);

        if (move >= 0.1f || move <= -0.1f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }


        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    void Update()
    {
        if (Input.GetButton("Jump") && Grounded && jumptimer > 0.2f)
        {
            Jump();

        }

        
        jumptimer += Time.deltaTime;
     

        anim.SetFloat("vSpeed", Mathf.Abs(rgbd2D.velocity.y));
    }
    private void Jump()
    {
        jumptimer = 0;
        rgbd2D.AddForce(new Vector2(0, jumpstrength), ForceMode2D.Impulse);
    }

    public void Respawn()
    {
        transform.position = spawnPosition.position;
    }

}
