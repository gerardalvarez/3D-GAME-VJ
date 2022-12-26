using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private CharacterController characterController;

    public GameObject objectToDrag;
    private Rigidbody objectRigidbody;
    private bool isDraggingObject;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) && isTouchingObjectToDrag())
        {
            isDraggingObject = true;
            objectRigidbody = objectToDrag.GetComponent<Rigidbody>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isDraggingObject = false;
        }

        if (isDraggingObject)
        {
            DragObject();
        }
    }

    private bool isTouchingObjectToDrag()
    {
        // Comprova si el personatge està tocant un objecte amb el qual col·lisiona pel sostre
        return characterController.collisionFlags == CollisionFlags.Below;
    }

    private void DragObject()
    {
        // Obte la velocitat del personatge
        Vector3 playerVelocity = characterController.velocity;

        // Calcula la posicio a la qual s'hauria de moure l'objecte en funcio de la velocitat del personatge
        Vector3 objectPosition = transform.position + playerVelocity * Time.deltaTime;

        // Manté la coordenada Y de l'objecte constant
        objectPosition.y = objectToDrag.transform.position.y;

        // Manté la coordenada Y del personatge constant
        Vector3 playerPosition = transform.position;
        playerPosition.y = objectToDrag.transform.position.y;
        transform.position = playerPosition;

        // Mou l'objecte cap a la posicio calculada utilitzant la funcio "MovePosition" del Rigidbody de l'objecte
        objectRigidbody.MovePosition(objectPosition);
    }



}
