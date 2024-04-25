using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    [SerializeField]
    GameObject posFinal;
    bool visto;
    public float vel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 5)
        {
            transform.Translate(posFinal.transform.position * vel * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * vel * Time.deltaTime);
        }
    }


}
