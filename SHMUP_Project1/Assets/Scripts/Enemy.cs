using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;  //Stores vehicles position

    [SerializeField]
    float speed = 1.0f; //Stores vehicle's speed

    Vector3 direction = Vector3.down; //Stores vehicles direction

    Vector3 velocity = Vector3.zero;    //stores vehicles velocity

    //2 floats to store the width and height of the camera
    private float totalCamHeight;
    private float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;

        // Calculate the total height of the camera view
        totalCamHeight = 2f * Camera.main.orthographicSize;

        // Calculate the total width of the camera view
        totalCamWidth = totalCamHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        //Validate User Input and Movement

        // Check horizontal wrapping
        if (objectPosition.x > totalCamWidth / 2f)
        {
            // Wrap to the left side of the screen
            objectPosition = new Vector3(-totalCamWidth / 2f, objectPosition.y, objectPosition.z);
        }
        else if (objectPosition.x < -totalCamWidth / 2f)
        {
            // Wrap to the right side of the screen
            objectPosition = new Vector3(totalCamWidth / 2f, objectPosition.y, objectPosition.z);
        }

        // Check vertical wrapping
        if (objectPosition.y > totalCamHeight / 2f)
        {
            // Wrap to the bottom of the screen
            objectPosition = new Vector3(objectPosition.x, -totalCamHeight / 2f, objectPosition.z);
        }
        else if (objectPosition.y < -totalCamHeight / 2f)
        {
            // Wrap to the top of the screen
            objectPosition = new Vector3(objectPosition.x, totalCamHeight / 2f, objectPosition.z);
        }

        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
    }
}
