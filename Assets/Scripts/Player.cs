using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool watchingDir = false;
    [SerializeField] public float jumpPower = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Physics
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.71f, 0.17f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetButton("Horizontal")) Run("H");
        if (Input.GetButton("Vertical")) Jump("V");
    }
    private void Jump(string moveType)
    {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    private void Run(string moveType)
    {
        if (moveType == "H")
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            if (watchingDir != (dir.x < 0.0f))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                watchingDir = !watchingDir;
            }   
        }
    }

}
