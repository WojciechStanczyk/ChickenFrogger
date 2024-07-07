using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> cars;
    [SerializeField] Transform carSpawner;
    [SerializeField] float carCooldown;
    [SerializeField] float randoTimeMin = 0.2f;
    [SerializeField] float randoTimeMax = 1.5f;


    float lastStartTime;
    float AddRandomSpawnTime;

    private void Start()
    {
        AddRandomSpawnTime = Random.Range(randoTimeMin, randoTimeMax);
    }

    private void Update()
    {
        if (!IsCooldown())
        {
            RandomCarSpawn();
            lastStartTime = Time.time;
            AddRandomSpawnTime = Random.Range(randoTimeMin, randoTimeMax);
        }
    }

    void RandomCarSpawn()
    {
       
        int randomIndex = Random.Range(0, cars.Count);
        Instantiate(cars[randomIndex], carSpawner.position, carSpawner.rotation);
    }
    private bool IsCooldown()
    {
        return lastStartTime + carCooldown + AddRandomSpawnTime >= Time.time;
    }


}