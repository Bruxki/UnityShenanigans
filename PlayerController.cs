using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed 25.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //forward - backward
        transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);
        //left - right
        transform.Translate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
