using System.Collections;
using System;
using UnityEngine;

public class BossIA1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Target;
    public float speed = 20f;
    public float rotationSpeed = 100f;

    private bool iswandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private Rigidbody rb;
    private Animator anim;
    bool walking = false;
    public GameObject door;
    bool despierto = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (door != null)
        {
            despierto = door.GetComponent<RotateDoor3>().getunLocked();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (door != null)
        {
            despierto = door.GetComponent<RotateDoor3>().getunLocked();
        }
        if (despierto)
        {
            if (Math.Abs(Target.gameObject.transform.position.x - this.transform.position.x) < 220 && Math.Abs(Target.gameObject.transform.position.z - this.transform.position.z) < 220)
            {
                transform.LookAt(Target.gameObject.transform.position);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                if (!walking)
                {

                    anim.Play("Walk");
                    walking = true;

                }

            }
            else
            {
                if (!iswandering)
                {
                    StartCoroutine(Wander());
                }
                if (isRotatingRight)
                {
                    transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
                    if (walking)
                    {
                        anim.Play("Idle");
                        walking = false;
                    }
                }
                if (isRotatingLeft)
                {
                    transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
                    if (walking)
                    {
                        anim.Play("Idle");
                        walking = false;
                    }
                }
                if (isWalking)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 back = transform.forward * -3;
            transform.Translate(back, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 impulse = collision.impulse / Time.fixedDeltaTime;
        float magnitude = impulse.magnitude;
    }

    IEnumerator Wander()
    {
        int rotationTime = UnityEngine.Random.Range(1, 3);
        int rotateWait = UnityEngine.Random.Range(1, 3);
        int rotarionDirection = UnityEngine.Random.Range(1, 3);
        int walkWait = UnityEngine.Random.Range(1, 3);
        int walkTime = UnityEngine.Random.Range(1, 3);

        iswandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotarionDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotarionDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        iswandering = false;

    }
}
