using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy1ia : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float speed = 20;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) <120 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) < 120 )
        {
            transform.LookAt(Target.gameObject.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 back = transform.forward * -3;
            transform.Translate(back, Space.World);
            Debug.Log("atras");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Calcular la dirección y la magnitud de la fuerza de la colisión
        Vector3 impulse = collision.impulse / Time.fixedDeltaTime;
        float magnitude = impulse.magnitude;

        // Aplicar la fuerza de la colisión al objeto utilizando el método AddForce
       // rb.AddForce(-impulse, ForceMode.Impulse);
        //rb.AddForce(Vector3.down * magnitude, ForceMode.Impulse);

        // Opcionalmente, puedes establecer la propiedad useGravity en false para asegurarte de que el objeto siempre se mantenga pegado al suelo
       // rb.useGravity = false;
    }
}
