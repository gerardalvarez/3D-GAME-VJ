using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreB : MonoBehaviour
{
    public GameObject boomerang;
    public GameObject cofre;
    public bool obert = false;
    public bool jaAconseguit = false;
    private AudioSource audioSource;

    void Start()
    {
        boomerang.SetActive(false);
        audioSource = cofre.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !jaAconseguit){
            obert = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (obert && !jaAconseguit)
        {
            jaAconseguit = true;
            boomerang.SetActive(true);
        }
    }
}
