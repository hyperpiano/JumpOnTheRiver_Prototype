using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public GameObject Girl; 

    GirlController girlControl;
    Rigidbody2D shadowRigid;
    Vector2 jumpVector;
    Vector2 _position;

    float direction;
    bool isJump;
    // Start is called before the first frame update
    void Start()
    {   
        _position = transform.position;
        girlControl =  Girl.GetComponent<GirlController>();
        shadowRigid= GetComponent<Rigidbody2D>();
        jumpVector = new Vector2(0, girlControl.jumpForce * -1f);
    }

    // Update is called once per frame
    void Update()
    {
        //소녀가 점프할 경우 따라서 점프함
        Move();
        Jump();
        //Land();
    }

    void Move(){
        //소녀가 움직일 경우 따라서 움직임
        if(girlControl.isMove){
            direction = girlControl.direction;
            
            _position.x = girlControl.transform.position.x;
            transform.position = _position; 
        }
        //소녀가 앉았을 경우 혼자서 움직임
        if(girlControl.isSit){
            direction = Input.GetAxis("Horizontal");
            _position.x = _position.x + girlControl.speed * direction * Time.deltaTime;
            transform.position = this._position;
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                shadowRigid.velocity = jumpVector;
            }
        }
        if(direction < 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(direction > 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Jump(){
        if(girlControl.isJump){
            shadowRigid.velocity = jumpVector;
        }
        else if(girlControl.isSit){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                isJump = true;
                Rigidbody2D girlRigid= GetComponent<Rigidbody2D>();
                girlRigid.velocity = jumpVector;
            }
        }
        
    }

    // void Land(){
    //     land = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), -Vector2.up, 1.5f);
    //     if(isJump && (land.collider != null) && GetComponent<Rigidbody2D>().velocity.y < 0){
    //         GirlAnimator.SetBool("isLand", true);
    //     }
    // }

    void Push(){
        if(Input.GetKey(KeyCode.LeftControl)){
            Move();
        }
        else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "Platform"){
    //         if(other.contacts[0].normal.y > 0.7f){
    //             isJump = false;
    //             isGrounded = true;
    //             GirlAnimator.SetBool("isGrounded", true);
    //             GirlAnimator.SetBool("isLand", false);
    //         }
    //     }
    // }

    // private void OnCollisionStay2D(Collision2D other) {
    //     if(other.gameObject.tag == "Box"){
    //         if(other.contacts[0].normal.x < 0f){
    //             Push();
    //         }
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other) {
    //     if(other.gameObject.tag == "Platform"){
    //             isGrounded = false;
    //             GirlAnimator.SetBool("isGrounded", false);
    //     }
    // }
}



