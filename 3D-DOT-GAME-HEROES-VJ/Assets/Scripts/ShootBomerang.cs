using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBomerang : MonoBehaviour
{
    public GameObject boomerang;
    public GameObject boomerangObj;
    public float force = 10f;
    private bool canShoot;
    private GameObject boomerangThrow;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = boomerang.GetComponent<AudioSource>();
        canShoot = false;
    }

    private void Update()
    {
        
        if (boomerangThrow != null)
        {
            canShoot = boomerangThrow.GetComponent<Boomerang>().getcanShoot();
        }
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            Vector3 posicio = new Vector3(transform.position.x, 17f, transform.position.z);
            Quaternion rotacio = transform.rotation;
            boomerangThrow = Instantiate(boomerang, posicio, rotacio);
            boomerangThrow.GetComponent<Boomerang>().speed = force;
            canShoot = false;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BoomerangObject")){
            canShoot = true;
        }
    }
}

