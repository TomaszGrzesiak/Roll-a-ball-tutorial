using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed  = 5f;
    public float rotationSpeed = 200f;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winTextObject.SetActive(false);
    }

    // Unity will execute this function when the object moves anything
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    //
    // private void FixedUpdate()
    // {
    //     // Below is the answer to exercise 4
    //     // adding force (pushing) the player - enforcing its movement
    //     Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    //     rb.AddForce(movement * speed);
    // }

    private void Update()
    {
        // Rotation (A & D keys)
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A)) rotation -= rotationSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D)) rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        
        // Movement (W & S keys)
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.W)) moveDirection = 1f;
        else if (Input.GetKey(KeyCode.S)) moveDirection = -1f;
        
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object 
            Destroy(gameObject);
            
            // Set the text to "You Lose!"
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

    
    // OnTriggerEnter is first executed when the player collides with the object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            
            SetCountText();
        }
    }
    
    
}
