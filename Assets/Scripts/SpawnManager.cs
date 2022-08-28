using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject shelterPrefab;
    private static float repeatRate = 10.0f;
    private static bool shelterExist = false;

    public static bool ShelterExist { get => shelterExist; set => shelterExist = value; }
    public static float RepeatRate { get => repeatRate; set => repeatRate = value; }

    void Update()
    {
        //Create new shelter if other one not exist
        if (Time.time > RepeatRate && !ShelterExist)
        {
            Instantiate(shelterPrefab, new Vector3(Random.Range(-10.0f, 10.0f), 0, 50), shelterPrefab.transform.rotation);
            ShelterExist = true;
        }
    }
}
