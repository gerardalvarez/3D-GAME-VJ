using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 75.0f;
    private AudioSource audioSource2;

    private void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        transform.Rotate(0, rotationAmount, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            audioSource2.Play();
            Destroy(gameObject, 0.12f);
        }
    }
}
