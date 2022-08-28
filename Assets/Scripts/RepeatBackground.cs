using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatLenght;

    void Start()
    {
        startPos = transform.position;
        repeatLenght = GetComponent<BoxCollider>().size.z / 0.2f;
    }

    void Update()
    {
        if (transform.position.z < startPos.z - repeatLenght)
        {
            transform.position = startPos;
        }
    }
}
