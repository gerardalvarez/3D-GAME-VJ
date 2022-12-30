using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBomerang : MonoBehaviour
{
    public GameObject boomerang;
    public float force = 10f;
    // private bool shooting = false;
    private GameObject boomerangThrow;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = boomerang.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 posicio = new Vector3(transform.position.x, 17f, transform.position.z);
            Quaternion rotacio = transform.rotation;
            boomerangThrow = Instantiate(boomerang, posicio, rotacio);
            boomerangThrow.GetComponent<Boomerang>().speed = force;
            audioSource.Play();
        }
    }
}

