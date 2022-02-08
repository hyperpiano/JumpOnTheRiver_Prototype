using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
     public float speed;
     public float jumpForce;
     public bool isSit;

     //for Reference
     public bool isMove;
     public bool isJump;
     public float direction;

     bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        jumpForce = 2.5f;
        isSit = false;
        isMove = false;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Sit();
        isJump = false;
        if(isSit == false){
            Move();
            Jump();
        }
    }

    void Move(){
        direction = Input.GetAxis("Horizontal");

        if(direction != 0){
            isMove = true;
        }
        else{
            isMove = false;
        }

        Vector2 _position = transform.position;
        _position.x = _position.x + speed * direction * Time.deltaTime;
        transform.position = _position;
    }

    void Jump(){
        Vector2 jumpVector = new Vector2(0, jumpForce);
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
            isJump = true;
            Rigidbody2D girlRigid= GetComponent<Rigidbody2D>();
            girlRigid.velocity = jumpVector;
        }
    }
    
    void Sit(){
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            isSit = !isSit;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
            if(other.contacts[0].normal.y > 0.7f){
                isGrounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
                isGrounded = false;
        }
    }
}
