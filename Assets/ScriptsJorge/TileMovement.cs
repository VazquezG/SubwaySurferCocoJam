using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoDeVida = 5f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }
}
