using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianEscape : MonoBehaviour
{
    private Vector3 targetPosition;
    private float distance;
    public float speed = 100.0f;

    void Update()
    {
        targetPosition = PlayerController.playerPos;
        distance = Vector3.Distance(transform.position, targetPosition);
        if (PlayerController.speed == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if(distance < 1.0f)
        {
            Destroy(gameObject);
            EscapeCivil.CivilianExist = false;
        }
    }
}
