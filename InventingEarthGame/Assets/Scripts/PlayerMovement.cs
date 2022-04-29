using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirections(direction);
    }


}
