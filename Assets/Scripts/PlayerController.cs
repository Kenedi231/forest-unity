using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // keep player
    void SetLimitPosition(float xRange)
    {
        transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if (transform.position.x < -xRange)
        {
            SetLimitPosition(-xRange);
        }

        if (transform.position.x > xRange)
        {
            SetLimitPosition(xRange);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

    }
}
