using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject patientPrefab;
    [SerializeField] int numPatients;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPatient", 5);
    }


    void SpawnPatient()
    {
        Instantiate(patientPrefab, transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(2,15));
    }
}
