using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static SpriteInfo;

public class CollisionManager : MonoBehaviour
{
    //Create List of collidables
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();

    //Create SpriteTypes object
    SpriteInfo sprite;
    SpriteTypes spriteType;
    EnemySpawner spawner;

    public void SetEnemySpawner(EnemySpawner spawner)
    {
        this.spawner = spawner;
    }

    // Start is called before the first frame update
    void Start()
    {
        collidables[0].spriteType = SpriteTypes.player;
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
            collidable.IsColliding = false;
        }

        //use nested for loops to loop through my list (collidables)
        for (int i = 0; i < collidables.Count - 1; i++)
        {
            //Check each sprite against eacchother for collisions
            for (int j = i + 1; j < collidables.Count; j++)
            {
                SpriteInfo spriteA = collidables[i];
                SpriteInfo spriteB = collidables[j];

                bool isColliding = false;

                isColliding = Collision(spriteA, spriteB);


                //if isColliding is true, mark each sprite as colliding
                //**********************ADD COLLISION LOGIC FOR EACH SPRITETYPE****************************************************
                if (isColliding)
                {
                    spriteA.IsColliding = isColliding;
                    spriteB.IsColliding = isColliding;
                }

                //if pBullet collides with enemy type, remove both sprites
                if ((spriteA.spriteType == SpriteTypes.pBullet && spriteB.spriteType == SpriteTypes.enemy) || (spriteA.spriteType == SpriteTypes.enemy && spriteB.spriteType == SpriteTypes.pBullet) && isColliding)
                {
                    if (spriteA.spriteType == SpriteTypes.pBullet)
                    {
                        spawner.RemoveRedEnemy(spriteB);///********************************FIX
                        RemoveCollidable(spriteB);
                        Destroy(spriteB.gameObject);
                        RemoveCollidable(spriteA);
                        Destroy(spriteA.gameObject);
                    }
                    else if (spriteB.spriteType == SpriteTypes.pBullet)
                    {
                        spawner.RemoveRedEnemy(spriteA);///*********************************************FIX
                        RemoveCollidable(spriteA);
                        Destroy(spriteA.gameObject);
                        RemoveCollidable(spriteB);
                        Destroy(spriteB.gameObject);
                    }
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
