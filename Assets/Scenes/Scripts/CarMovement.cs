using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] float damage;

    private int scoreSpeed;



    private void Awake()
    {
        
        
    }

    private void Update()
    {
        scoreSpeed = TerrainSpawner.score;
        velocity = velocity + scoreSpeed * Time.deltaTime;
        rigidbody.velocity =transform.right * velocity;
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}