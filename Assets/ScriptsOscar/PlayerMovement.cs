using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float desviacion , jump;
    Rigidbody2D rb;
    bool saltando;
    void Start()
    {
        saltando= false;
        jump = 300;
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
        if (Input.GetKeyDown(KeyCode.Space) && !saltando)
        {
            rb.AddForce(Vector2.up * jump);
            saltando= true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Piso")
        {
            saltando = false;
        }
    }
}
