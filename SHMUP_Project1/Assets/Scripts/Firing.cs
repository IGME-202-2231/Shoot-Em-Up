using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    [SerializeField] 
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float bulletSpeed = 10f;

    [SerializeField]
    private CollisionManager collisionManager; // Reference to the CollisionManager.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;

        SpriteInfo bulletInfo = bullet.GetComponent<SpriteInfo>();
        Bullet bullet1 = bullet.GetComponent<Bullet>();

        if (bulletInfo != null && collisionManager != null)
        {
            collisionManager.AddCollidable(bulletInfo);
        }
        //if (!bullet1.IsOnScreen())
        //{
        //    collisionManager.RemoveCollidable(bulletInfo);
        //}
    }
    
}
