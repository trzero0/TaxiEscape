using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delay = 0.2f;
    public GameObject cube;

    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn()
    {
        Instantiate(cube, new Vector3(Mathf.RoundToInt(Random.Range(-20, 20)), 52, 0.6f), Quaternion.Euler(90, -180,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
