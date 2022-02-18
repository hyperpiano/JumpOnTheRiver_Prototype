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

    Animator GirlAnimator;

    RaycastHit2D land;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        jumpForce = 4f;
        isSit = false;
        isMove = false;
        direction = 0;
        GirlAnimator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Sit();
        if(isSit == false){
            GirlAnimator.SetBool("isCrouch", false);
            Move();
            Jump();
        }
        Land();

        Debug.Log("Girl isGrounded = " + isGrounded);
        Debug.Log("Girl land = " + land.collider);
        if(land.collider != null){
            Debug.Log(land.collider.tag);
        }
    }

    void Move(){
        direction = Input.GetAxis("Horizontal");
        GirlAnimator.SetFloat("Speed", Mathf.Abs(direction));
        if(isSit){
            direction = 0f;
        }

        if(direction != 0){
            isMove = true;
        }
        else{
            isMove = false;
        }

        if(direction < 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(direction > 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector2 _position = transform.position;
        _position.x = _position.x + speed * direction * Time.deltaTime;
        transform.position = _position;
    }

    void Jump(){
        Vector2 jumpVector = new Vector2(0, jumpForce);
        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded)){
            isJump = true;
            Rigidbody2D girlRigid= gameObject.GetComponent<Rigidbody2D>();
            girlRigid.velocity = jumpVector;
        }
    }
    
    void Sit(){
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            isSit = !isSit;
        }
        if(isSit){
            GirlAnimator.SetBool("isCrouch", true);
        }
    }

    void Land(){
        land = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), -Vector2.up, 1.5f);
        if(!isGrounded && (land.collider != null) && GetComponent<Rigidbody2D>().velocity.y <= 0){
            GirlAnimator.SetBool("isLand", true);
        }
    }

    void Push(){
        if(Input.GetKey(KeyCode.LeftControl)){
            Move();
        }
        else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
            if(other.contacts[0].normal.y > 0.7f){
                isJump = false;
                isGrounded = true;
                GirlAnimator.SetBool("isGrounded", true);
                GirlAnimator.SetBool("isLand", false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Box"){
            if(other.contacts[0].normal.x < 0f){
                Push();
            }
        }
        if(other.gameObject.tag == "Platform"){
            if(other.contacts[0].normal.y > 0.7f){
                isJump = false;
                isGrounded = true;
                GirlAnimator.SetBool("isGrounded", true);
                GirlAnimator.SetBool("isLand", false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
                isGrounded = false;
                GirlAnimator.SetBool("isGrounded", false);
        }
        else if (other.gameObject.tag == "Platform" && other.contacts[0].normal.y == 0){
            isGrounded = false;
            GirlAnimator.SetBool("isGrounded", false);
        }
    }
}
