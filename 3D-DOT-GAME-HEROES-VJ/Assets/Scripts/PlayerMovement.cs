using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private CharacterController characterController;

    public GameObject objectToDrag;
    private Rigidbody objectRigidbody;
    private bool isDraggingObject;
    
    public float rayDistance = 20f;
    private RaycastHit hitInfo;
    private Vector3 targetDirection;
    private float elapsedTime = 0f;
    string dir ="n";
    bool change = true;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        targetDirection = new Vector3(0, 0, 1);
    }
    

    // Update is called once per frame
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 0.5f)
            {
                change=!change;
                elapsedTime = 0f;
            }// else { north =  new Vector3(0, 0, 1); }
            Quaternion toRotation1;
            
            // Calcula la dirección hacia la que debe moverse el objeto
            if (horizontalInput > 0 && verticalInput == 0)
            {
                targetDirection = new Vector3(1, 0, 0); 
                dir = "e";
            }
            else if (horizontalInput < 0 && verticalInput == 0) { 
                targetDirection = new Vector3(-1, 0, 0);
                dir = "w";
            }
            else if (verticalInput < 0 && horizontalInput == 0) {
                targetDirection = new Vector3(0, 0, -1);
                dir = "s";
            }
            else if (verticalInput > 0 && horizontalInput == 0) { 
                targetDirection = new Vector3(0, 0, 1);
                dir = "n";
            }
            else 
            { 
                switch(dir)
                {
                    case "n":
                        targetDirection = new Vector3(0, 0, 1);
                        break;
                    case "s":
                        targetDirection = new Vector3(0, 0, -1);
                        break;
                    case "w":
                        targetDirection = new Vector3(-1, 0, 0);
                        break;
                    case "e":
                        targetDirection = new Vector3(1, 0, 0);
                        break;
                }
            }

            if (change) {
                toRotation1 = Quaternion.AngleAxis(5f, Vector3.up);
                targetDirection = toRotation1 * targetDirection;
            } else
            {
                toRotation1 = Quaternion.AngleAxis(-5f, Vector3.up);
                targetDirection = toRotation1 * targetDirection;
            }

            // Haz que el objeto mire hacia la dirección de movimiento
            Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else
        {


        }

        transform.position= new   Vector3(transform.position.x, 0, transform.position.z);

        

    }



}