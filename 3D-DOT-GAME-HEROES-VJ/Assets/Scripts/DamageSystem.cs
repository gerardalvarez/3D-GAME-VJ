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
        
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (other.tag == "Enemy1" && !inmune)
        {
            Debug.Log("daño");
            inventory.perderVida();

            blinkTime = blinkDuration;
            inmune = true;
            

        }
    }
}
