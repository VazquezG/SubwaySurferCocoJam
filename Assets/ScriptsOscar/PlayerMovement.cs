using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float desviacion , jump;
    Rigidbody2D rb;
    void Start()
    {
        //jump = 10;
        desviacion = 3.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x < 3)
        {
            transform.position = new Vector3(transform.position.x + desviacion, transform.position.y, 0);
        }
        if(Input.GetKeyDown(KeyCode.A) && transform.position.x > -3)
        {
            transform.position = new Vector3(transform.position.x - desviacion, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump);
        }
    }
}
