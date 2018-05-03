using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 3f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    public Transform startPosition;
    public float health = 100;

    private float damageTimer;


    void Start()
    {
        health = 100;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Grabbable")
                {
                    grabbed = true;

                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }


                //throw
            }


        }

        if (grabbed)
            hit.collider.gameObject.transform.position = holdpoint.position;


        damageTimer += Time.deltaTime;
    }


    public void Harm(float dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
        }

        if (health < 1)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = startPosition.position;
        health = 100;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}