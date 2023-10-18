using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sRenderer;

    [SerializeField]
    Vector2 rectSize = Vector2.one;

    bool isColliding = false;

    [SerializeField]
    bool useRendererBounds = true;

    enum sprites
    {
        player,
        bullet,
        enemy
    }

    public Vector2 RectMin
    {
        get { return (Vector2)transform.position - (rectSize / 2); }
    }

    public Vector2 RectMax
    {
        get { return (Vector2)transform.position + (rectSize / 2); }
    }

    public bool IsColliding { set { isColliding = value; } }

    // Update is called once per frame
    void Update()
    {
        if(isColliding)
        {
            sRenderer.color = Color.red;
        }
        else
        {
            sRenderer.color = Color.white;
        }

        if(useRendererBounds)
        {
            rectSize = sRenderer.bounds.extents * 2;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        //Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}
