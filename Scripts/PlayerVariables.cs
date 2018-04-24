using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playervariables : MonoBehaviour
{

    public Transform startPosition;
    public float health = 100;

    private float damageTimer;


    void Start()
    {
        health = 100;
    }


    void Update()
    {
        damageTimer += Time.deltaTime;
        GameController.GameControllerInstance.PlayerHealth = health;
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
}