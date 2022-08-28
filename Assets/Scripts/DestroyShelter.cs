using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShelter : MonoBehaviour
{
    private float lowerBound = -20.0f;

    void Update()
    {
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            SpawnManager.ShelterExist = false;
            EscapeCivil.CivilianExist = false;
            SpawnManager.RepeatRate = Time.time + Random.Range(2.0f, 10.0f);
        }
    }
}
