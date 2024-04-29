using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBF : MonoBehaviour
{
    float desviacion, jump;
    float caidoTimer, caidoLimit;
    Rigidbody2D rb;
    bool saltando, tropesando;
    public int monedas;
    public AudioSource sourceCoin;
    public AudioSource sourceHit;
    public AudioClip SFXCoin;
    public AudioClip[] SFXHit;

    [Header("UI")]
    public GameObject gameOver;
    void Start()
    {
        monedas = 0;
        caidoLimit = 1.3f;
        saltando = false;
        jump = 300;
        desviacion = 3.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 3)
        {
            transform.position = new Vector3(transform.position.x + desviacion, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -3)
        {
            transform.position = new Vector3(transform.position.x - desviacion, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !saltando)
        {
            rb.AddForce(Vector2.up * jump);
            saltando = true;
        }

        if(tropesando)
        {
            caidoTimer += Time.deltaTime;
            if(caidoTimer > caidoLimit)
            {
                caidoTimer = 0;
                tropesando= false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Piso")
        {
            saltando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstaculo" && !saltando)
        {
            ChecarMuerte();
            int SFXRandom = Random.Range(0, 2);
            sourceHit.PlayOneShot(SFXHit[SFXRandom]);
            Destroy(collision.gameObject);
            
        }
        
        if(collision.tag == "Moneda")
        {
            monedas++;
            sourceCoin.PlayOneShot(SFXCoin);
            Destroy(collision.gameObject);
        }
    }

    private void ChecarMuerte()
    {
        if (tropesando)
        { 
            Time.timeScale = 0;//stop the time
            AudioListener.volume = 0f;//reactivate audio
            gameOver.gameObject.SetActive(true);
            print("gameOver");
        }
        else
        {
            tropesando = true;
        }
    }
}
