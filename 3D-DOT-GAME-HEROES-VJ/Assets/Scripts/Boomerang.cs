using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10f;
    private GameObject Player;
    public float tempsViatge = 0.1f;
    private float tempsRecorregut = 0f;
    private bool anantEnrere = false;
    private bool canShoot = true;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if (Player == null)
        {
            Debug.LogError("No s'ha trobat cap objecte amb l'etiqueta 'Player' a l'escena!");
        }
    }

    private void Update()
    {
        canShoot = false;
        Vector3 direccio = transform.forward;
        if (!anantEnrere)
        {
            transform.position += direccio * speed * Time.deltaTime;
            tempsRecorregut += Time.deltaTime;
            if (tempsRecorregut >= tempsViatge)
            {
                anantEnrere = true;
            }
        }
        else
        {
            direccio = (Player.transform.position - transform.position).normalized;
            transform.position += direccio * speed * Time.deltaTime;
            tempsRecorregut -= Time.deltaTime;
            if (tempsRecorregut <= 0f)
            {
                canShoot = true;
                Destroy(gameObject, 0.025f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")){
            anantEnrere = true;
        }
    }

    public bool getcanShoot()
    {
        return canShoot;
    }
}
