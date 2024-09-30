using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float horizontalInput;
    public float verticalInput;
    public float jumpForce = 7f;
    public bool isGrounded;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(verticalInput, 0, -horizontalInput);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); 
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
