using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    //Create List of collidables
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();

    //Determine collision mode
    public enum CollisionMode
    {
        AABB,
        Circle
    }

    //set collision mode default
    CollisionMode collisionMode;
    
    // TextMesh object to display information
    public TextMesh controlsText;

    // Start is called before the first frame update
    void Start()
    {
        // Find TextMesh object in the scene
        controlsText = GameObject.Find("controlsText").GetComponent<TextMesh>();

        UpdateControlsText();
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollisions();

        // Switch collision mode on left click
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCollisionMode();
        }
    }


    void ToggleCollisionMode()
    {
        if (collisionMode == CollisionMode.AABB)
        {
            collisionMode = CollisionMode.Circle;
        }
        else
        {
            collisionMode = CollisionMode.AABB;
        }

        UpdateControlsText();
    }

    //AABB Collision logic
    bool AABBCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x &&
           spriteB.RectMax.x > spriteA.RectMin.x &&
           spriteB.RectMin.y < spriteA.RectMax.y &&
           spriteB.RectMax.y > spriteA.RectMin.y;
    }

    //Circle Collision Logic
    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        float radiusA = spriteA.radius;
        float radiusB = spriteB.radius;

        // Calculate the distance between the centers of the circles
        float distance = Vector2.Distance(spriteA.transform.position, spriteB.transform.position);

        // Check if the distance is less than the sum of the radii
        return distance < (radiusA + radiusB);
    }

    void UpdateControlsText()
    {
        controlsText.text = "Click Left to Change Mode: \n" +
            "Collision Mode: " + collisionMode.ToString();
    }


    //Method to detect collisions
    void DetectCollisions()
    {
        //Set all collidables isColliding to false
        foreach (SpriteInfo collidable in collidables)
        {
            collidable.GetComponent<SpriteInfo>().IsColliding = false;
        }

        //use nested for loops to loop through my list (collidables)
        for (int i = 0; i < collidables.Count - 1; i++)
        {
            //Check each sprite against eacchother for collisions
            for (int j = i + 1; j < collidables.Count; j++)
            {
                SpriteInfo spriteA = collidables[i].GetComponent<SpriteInfo>();
                SpriteInfo spriteB = collidables[j].GetComponent<SpriteInfo>();

                bool isColliding = false;

                if (collisionMode == CollisionMode.AABB)
                {
                    isColliding = AABBCollision(spriteA, spriteB);
                }
                else if (collisionMode == CollisionMode.Circle)
                {
                    isColliding = CircleCollision(spriteA, spriteB);
                }

                //if isColliding is true, mark each sprite as colliding
                if(isColliding)
                {
                    spriteA.IsColliding = isColliding;
                    spriteB.IsColliding = isColliding;
                }
            }
        }
    }
}
