using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private static float playerHeight = 2.0f;
    private float constantSpeed = 0.3f;
    public static float speed;
    public static Vector3 playerPos;
    private float xRange = 10.0f;
    private float yRange = 4.0f;
    public bool gameOver = false;
    public AudioSource playerAudio;
    public AudioClip launchSound;
    public AudioClip crashSound;
    public GameObject projectilePrefab;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        speed = constantSpeed;
    }

    void Update()
    {
        //Calculate Player's speed based on its height
        playerHeight = transform.position.y;
        if (playerHeight < 0.1f)
        {
            speed = 0;
        }
        else
        {
            speed = 3.0f * (playerHeight);
        }
        if (speed == 0)
        {
            playerPos = transform.position;
        }

        //Launch a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.2f), projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(launchSound, 1.0f);
        }

        //destroy objects by projectile
        if (DetectCollisions.Crash)
        {
            DetectCollisions.Crash = false;
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

        //create horizontal bounds 4 the Player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
 
        //horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        //create vertical bounds 4 the Player
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        //vertical input
        verticalInput = Input.GetAxis("Vertical");

        //Player's landing/uplift
        if (speed != 0)
        {
            transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.up);
        }
        else
        {
            transform.Translate(constantSpeed * Time.deltaTime * verticalInput * Vector3.up);
        }
    }
}
