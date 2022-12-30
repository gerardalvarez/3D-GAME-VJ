using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10f;
    public bool shoot = true;
    
    public GameObject player;
    public float tempsViatge = 0.2f;
    private float tempsRecorregut = 0f;
    private bool anantEnrere = false;

    private void Update()
    {
        Vector3 direccio = player.transform.forward;
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
            transform.position -= direccio * speed * Time.deltaTime;
            tempsRecorregut -= Time.deltaTime;
            if (tempsRecorregut <= 0f)
            {
                shoot = false;
                Destroy(gameObject);
            }
        }
    }
}
