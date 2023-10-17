using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    SpriteInfo bulletInfo;
    
    private CollisionManager collisionManager; // Reference to the CollisionManager.
    //private static Singleton instance;

    private void Start()
    {
        //Find collision manager in scene and assign it
        collisionManager = FindObjectOfType<CollisionManager>();
    }

    private void Update()
    {
        // Check if the bullet is off-screen
        if (!IsOnScreen())
        {
            collisionManager.RemoveCollidable(bulletInfo);
            //CollisionManager.instance.RemoveCollidable(bulletInfo);
            Destroy(gameObject);            
        }
    }

    public bool IsOnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
