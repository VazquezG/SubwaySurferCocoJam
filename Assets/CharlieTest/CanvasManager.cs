using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private static bool created = false;
  

    void Awake()
    {
        if (!created)
        {

            // Esto hace que el objeto al que está adjunto el script no se destruya al cargar una nueva escena.
            DontDestroyOnLoad(this.gameObject);
            created = true; // Asegura que el objeto se crea solo una vez.
        }
        else
        {
            // Si ya existe un objeto, destruye cualquier duplicado adicional que se pueda crear.
            Destroy(this.gameObject);
        }
    }
}

