using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    //Create List of collidables
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectCollisions();
    }


    //AABB Collision logic
    bool Collision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x &&
           spriteB.RectMax.x > spriteA.RectMin.x &&
           spriteB.RectMin.y < spriteA.RectMax.y &&
           spriteB.RectMax.y > spriteA.RectMin.y;
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

                isColliding = Collision(spriteA, spriteB);


                //if isColliding is true, mark each sprite as colliding
                if(isColliding)
                {
                    spriteA.IsColliding = isColliding;
                    spriteB.IsColliding = isColliding;
                }
            }
        }
    }

    //Add collidables method
    public void AddCollidable(SpriteInfo collidable)
    {
        collidables.Add(collidable);
    }

    //Remove collidable method
    public void RemoveCollidable(SpriteInfo collidable)
    {
        collidables.Remove(collidable);
    }
}
