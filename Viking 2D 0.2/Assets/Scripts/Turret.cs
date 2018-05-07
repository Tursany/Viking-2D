using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject target;
    public GameObject bullet;
    public Transform barrel;
    public int health = 3;

    private Animator anim;
    private float fireDelay;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (Vector2.Distance(target.transform.position, transform.position) < 5.0f && fireDelay > 0.5f && transform.position.x > target.transform.position.x)
        {

            anim.SetTrigger("Fire");
            Fire();

        }

            fireDelay += Time.deltaTime;

    }

    private void Fire()
    {
        fireDelay = 0;
        Instantiate(bullet, barrel.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}