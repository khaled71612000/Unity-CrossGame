using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [HideInInspector] public float Speed;
    [SerializeField] Rigidbody rb;
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        Vector3 moveDir = (EndPosition - StartPosition).normalized;
        rb.velocity = Speed * moveDir * Time.deltaTime;
    }
}
