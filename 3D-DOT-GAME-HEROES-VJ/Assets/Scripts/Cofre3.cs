using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre3 : MonoBehaviour
{
    public GameObject boto1;
    public GameObject boto2;
    public GameObject boto3;
    public GameObject key;
    public GameObject cofre;
    public bool obert = false;
    private AudioSource audioSource;

    private void Start()
    {
        key.SetActive(false);
        audioSource = cofre.GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool valorUnblocked1 = boto1.GetComponent<Button>().unBlocked;
        bool valorUnblocked2 = boto2.GetComponent<Button>().unBlocked;
        bool valorUnblocked3 = boto3.GetComponent<Button>().unBlocked;

        if (valorUnblocked1 && valorUnblocked2 && valorUnblocked3 && !obert)
        {
            obert = true;
            key.SetActive(true);
            audioSource.Play();
        }
    }
}
