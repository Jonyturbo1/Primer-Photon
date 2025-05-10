using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSControl : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;
    public float jumpForce = 3.0f;
    public float gravity = -9.81f;

    public static float health = 100f;
    public TMP_Text miVida;

    public static Vector3 ubicacion;

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 velocity;
    private float verticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        miVida.text = health.ToString();

        ubicacion = transform.position;

        float moveHorizontal = ((Input.GetKey(KeyCode.D)? 1 : 0) + (Input.GetKey(KeyCode.A)? -1 : 0)) * speed;
        float moveVertical = ((Input.GetKey(KeyCode.W)? 1 : 0) + (Input.GetKey(KeyCode.S)? -1 : 0)) * speed;

        /*if (Input.GetKeyUp("up"))
        {
            moveVertical = speed * 0f;
        }
        if (Input.GetKeyDown("up"))
        {
            moveVertical = speed * 1f;
        }
        

        if (Input.GetKey("down"))
        {
            moveVertical = -speed * Time.deltaTime;
        }

        if (Input.GetKey("right"))
        {
            moveHorizontal = speed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            moveHorizontal = -speed * Time.deltaTime;
        }*/
        //float moveHorizontal = 0.0f; // Input.GetAxis("Horizontal") * speed;
        //float moveVertical = 0.0f;  // Input.GetAxis("Vertical") * speed;

        Vector3 moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
        characterController.Move(moveDirection * Time.deltaTime);

        //Aplicar gravedad

        velocity.y += gravity * Time.deltaTime;
        if (characterController.isGrounded && velocity.y <= 0)
        {
            velocity.y = 0f;
        }
        characterController.Move(velocity * Time.deltaTime);

        //Salto
        if(Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        //Rotacion de la camara
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;  //El "-" invierte el eje

        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); 

        transform.Rotate(0, mouseX, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        
    }
}
