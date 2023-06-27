using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 16.81f * 2f;
    public float jumpForce = 7f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if(character.isGrounded)
        {
            direction = Vector3.down;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
