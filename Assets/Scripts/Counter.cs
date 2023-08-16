using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    [SerializeField] float speed;
    [SerializeField] GameObject[] balls = new GameObject[5];

    private Rigidbody rb;
    private int Count = 0;
    private float randomZ;
    private float minZ = -19;
    private float maxZ = 19;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Count = 0;

        InvokeRepeating("SpawnObjects", 1, 1.5f);
    }

    private void Update()
    {
        randomZ = Random.Range(minZ, maxZ);
    }

    void SpawnObjects()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            
            Vector3 spawnPos = new Vector3(0, 20, randomZ);

            GameObject obj = Instantiate(balls[i], spawnPos, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            print("test");
            Count += 1;
            CounterText.text = "Count : " + Count;
            Destroy(other.gameObject);
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.AddForce(Vector3.forward * speed * horizontalInput);
    }
}
