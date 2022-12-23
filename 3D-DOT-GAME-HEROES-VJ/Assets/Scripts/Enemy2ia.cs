using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy2ia : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float speed = 20;
    private CharacterController characterController;
    private bool attacked;
    private bool justattacked;
    private float attackedTime;
    private float rechargeTime;
    private Rigidbody rb;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        attackedTime = 0.5f;
        attacked = false;
        justattacked = false;
        rechargeTime=3;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!justattacked)
        {
            transform.LookAt(Target.gameObject.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (!attacked) {
            if (!justattacked && Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) < 80 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) < 80)
            {

                attacked = true;
                speed =20* 6;

            }
            else
            {

                rechargeTime -= Time.deltaTime;
                if (rechargeTime <= 0)
                {
                    attackedTime = 0.5f;
                    attacked = false;
                    justattacked = false;
                    rechargeTime = 6;
                }
            }
        } else {
            attackedTime -= Time.deltaTime;
            if (attackedTime <= 0)
            {
                attacked = false;
                speed=20/ 6;
                justattacked = true;
                attackedTime = 0.5f;
            }

        }
    }

    /*IEnumerator MoveTowardsTarget()
    {
        transform.LookAt(Target.gameObject.transform.position);
        float distance = Vector3.Distance(transform.position, Target.gameObject.transform.position);
        Vector3 t = Target.gameObject.transform.position;
        while (distance > attackRange)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * 3);
            distance = Vector3.Distance(transform.position, t);
            yield return null;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        speed= 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Calcular la dirección y la magnitud de la fuerza de la colisión
        // Vector3 impulse = collision.impulse / Time.fixedDeltaTime;
        //float magnitude = impulse.magnitude;
        speed = 0;

        // Aplicar la fuerza de la colisión al objeto utilizando el método AddForce
        //rb.AddForce(-impulse, ForceMode.Impulse);
        // rb.AddForce(Vector3.down * magnitude, ForceMode.Impulse);

        // Opcionalmente, puedes establecer la propiedad useGravity en false para asegurarte de que el objeto siempre se mantenga pegado al suelo

    }
}

