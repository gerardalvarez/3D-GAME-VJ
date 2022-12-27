using System.Collections;
using System;
using UnityEngine;

public class Enemy1ia : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float speed = 20f;
    public float rotationSpeed = 100f;

    private bool iswandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
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
          
        } else
        {
            if (!iswandering)
            {
                StartCoroutine(Wander());
            }
            if (isRotatingRight)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            }
            if (isRotatingLeft)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            }
            if (isWalking)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
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
    IEnumerator Wander()
    {
        int rotationTime = UnityEngine.Random.Range(1, 3);
        int rotateWait = UnityEngine.Random.Range(1, 3);
        int rotarionDirection = UnityEngine.Random.Range(1, 3);
        int walkWait = UnityEngine.Random.Range(1, 3);
        int walkTime = UnityEngine.Random.Range(1, 3);

        iswandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotarionDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotarionDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        iswandering = false;

    }
}
