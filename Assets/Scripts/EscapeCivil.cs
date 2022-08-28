using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeCivil : MonoBehaviour
{
    private static int shelterCapacity;
    public GameObject civilianPrefab;
    private static bool civilianExist = false;

    public static int ShelterCapacity { get => shelterCapacity; set => shelterCapacity = value; }
    public static bool CivilianExist { get => civilianExist; set => civilianExist = value; }

    void Start()
    {
        shelterCapacity = Random.Range(1, 5);
    }

    void Update()
    {
        //Initiate civilians in shelter
        for (int i = 0; i < shelterCapacity && !CivilianExist; shelterCapacity--)
        {
            Instantiate(civilianPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.2f), civilianPrefab.transform.rotation);
            CivilianExist = true;
        }
 
    }
}
