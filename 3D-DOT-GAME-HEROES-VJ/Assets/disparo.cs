using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiempoVida = 2.0f; // tiempo de vida del disparo en segundos
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoVida -= Time.deltaTime; // restamos el tiempo transcurrido en cada frame

        if (tiempoVida <= 0) // si el tiempo de vida del disparo se ha agotado
        {
            Destroy(gameObject); // destruimos el disparo
        }
    }
}
