using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerBF : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI marcador;
    [SerializeField]
    PlayerMovementBF player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        marcador.text = player.monedas.ToString();
    }
}
