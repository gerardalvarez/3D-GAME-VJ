using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4ia : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public float rotationSpeed = 100f;

    private bool iswandering= false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking  = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!iswandering)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight)
        {
            transform.Rotate(transform.up*Time.deltaTime*rotationSpeed);
        }
        if (isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if (isWalking)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotarionDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        iswandering= true;
        yield return new WaitForSeconds(walkWait);
        isWalking= true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotarionDirection==1)
        {
            isRotatingLeft= true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft= false;
        }
        if (rotarionDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        iswandering= false;

    }
}
