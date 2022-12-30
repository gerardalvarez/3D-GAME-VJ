using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre2 : MonoBehaviour
{
    public GameObject boto;
    public GameObject key;
    public GameObject cofre;
    public bool obert = false;
    private AudioSource audioSource;

    void Start()
    {
        key.SetActive(false);
        audioSource = cofre.GetComponent<AudioSource>();
    }

    void Update()
    {
        bool valorUnblocked1 = boto.GetComponent<Button2>().unBlocked;

        if (valorUnblocked1 && !obert)
        {
            obert = true;
            key.SetActive(true);
            audioSource.Play();
        }
    }
}
