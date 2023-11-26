using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_runner : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float forSpeed;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, forSpeed, forSpeed);
    }
}
