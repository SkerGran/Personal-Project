using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 50.0f;
    private float lowerBound = -20.0f;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } else
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
