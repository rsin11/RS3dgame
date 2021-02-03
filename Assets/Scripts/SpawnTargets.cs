using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    private Rigidbody targetRb;
    float minSpeed = 1;
    float maxSpeed = 5;
    float maxTorque = 2;
    private float xRange = 15;
    private float ySpawnPosition = 1;



    void Start()// Makes targets move up
    {
        targetRb = GetComponent<Rigidbody>();

       // targetRb.AddForce(RandomForce(), ForceMode.Force);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();


    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition, Random.Range(1, 10));
    }



}

