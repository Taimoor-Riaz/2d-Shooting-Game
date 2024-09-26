using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private float lifeTime = 5f;
    private int damage = 10;
    private GameObject impactEffect;
    private Vector3 moveDirection;  // Direction in which bullet will move

    // Initialize the bullet's speed, lifetime, and movement direction
    public void Initialize(float speedReceived, float lifeTimeReceived, Vector3 direction)
    {
        speed = speedReceived;
        lifeTime = lifeTimeReceived;
        moveDirection = direction.normalized; // Normalize the direction to ensure consistent movement
    }

    private void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Move the bullet in the initialized direction
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle bullet collision with target (you can add your damage or particle effect logic here)
        // Example: Destroy the bullet on collision
        Destroy(gameObject);
    }
}
