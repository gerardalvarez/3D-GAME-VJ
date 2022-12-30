using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre1 : MonoBehaviour
{
    public GameObject key;
    public GameObject cofre;
    public bool obert = false;
    private AudioSource audioSource;

    void Start()
    {
        key.SetActive(false);
        audioSource = cofre.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            obert = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (obert)
        {
            key.SetActive(true);
        }
    }
}
