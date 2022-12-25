using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float tiempoVida = 2.0f; // tiempo de vida del disparo en segundos

    void Update()
    {
        tiempoVida -= Time.deltaTime; // restamos el tiempo transcurrido en cada frame

        if (tiempoVida <= 0) // si el tiempo de vida del disparo se ha agotado
        {
            Destroy(gameObject); // destruimos el disparo
        }
    }
}