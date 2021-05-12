using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isJumping;
    public bool IsGrounded { get; set; }

    private Rigidbody2D body;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
            Jump();
        }

        anim.SetBool("isJumping", IsGrounded == false);
        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));
    }

    private void FixedUpdate() {
        if(Input.GetAxisRaw("Horizontal") != 0) {
            var x = Input.GetAxisRaw("Horizontal");
            Move(x);
        }
    }

    private void Move(float x) {
        if (x < 0) transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else if (x > 0) transform.rotation = Quaternion.Euler(Vector3.zero);
        body.velocity = new Vector2(x * speed * Time.deltaTime, body.velocity.y);
    }

    private void Jump() {
        body.AddForce(Vector2.up * jumpForce);
        IsGrounded = false;
    }
}
