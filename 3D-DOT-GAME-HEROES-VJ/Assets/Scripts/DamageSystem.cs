using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageSystem : MonoBehaviour
{
   
    Vector3 reverseDirection;
    public float blink;
    public bool inmune;
    public float inmuneTime;
    public float blinkTime;
    public float blinkDuration = 2;
    public float blinkIntensity = 10;
    private Rigidbody rb;


    // Calcula el vector de dirección reflejado a partir del vector de dirección de la colisión
    Vector3 reflectedDirection;

    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        blinkDuration = 0.5f;
        blinkIntensity = 10;
        inmuneTime= 3;
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        if (inmuneTime > 0)
        {
            blinkTime -= Time.deltaTime;
            inmuneTime -= Time.deltaTime;
            float lerp = Mathf.Clamp01(blinkTime / blinkDuration);
            float intensity = lerp * blinkIntensity + 1.0f;
            meshRenderer.material.color = Color.white * intensity;
            

        }
        else
        {
            inmune = false;
            inmuneTime = 3;
            //hit = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("pum  ");
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if ((other.tag == "Enemy1" || other.tag == "Enemy2" || other.tag == "disparo") && !inmune)
        {
            Debug.Log("daño");
            inventory.perderVida();

            blinkTime = blinkDuration;
            inmune = true;
            

        }
        if (other.tag == "Enemy4")
        {
            inventory.perderVida();
            inventory.perderVida();
            blinkTime = blinkDuration;
            inmune = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Calcular la dirección y la magnitud de la fuerza de la colisión
        Vector3 impulse = collision.impulse / Time.fixedDeltaTime;
        float magnitude = impulse.magnitude;

        // Aplicar la fuerza de la colisión al objeto utilizando el método AddForce
        rb.AddForce(-impulse, ForceMode.Impulse);
       // rb.AddForce(Vector3.down * magnitude, ForceMode.Impulse);

        // Opcionalmente, puedes establecer la propiedad useGravity en false para asegurarte de que el objeto siempre se mantenga pegado al suelo
        
    }
}
