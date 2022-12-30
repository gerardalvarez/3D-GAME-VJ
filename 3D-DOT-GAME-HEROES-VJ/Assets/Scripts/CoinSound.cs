using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = coin.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hola");
        audioSource.Play();
    }
}
