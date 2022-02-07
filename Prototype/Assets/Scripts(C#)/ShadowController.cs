using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public GameObject Girl; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GirlController girlControl =  Girl.GetComponent<GirlController>();
        Rigidbody2D shadowRigid= GetComponent<Rigidbody2D>();
        Vector2 jumpVector = new Vector2(0, girlControl.jumpForce * -1f);
        Vector2 _position = transform.position;

        //소녀가 움직일 경우 따라서 움직임
        if(girlControl.isMove){
            _position.x = girlControl.transform.position.x;
            transform.position = _position; 
        }
        
        //소녀가 점프할 경우 따라서 점프함
        if(girlControl.isJump){
            shadowRigid.velocity = jumpVector;
        }

        //소녀가 앉았을 경우 혼자서 움직임
        if(girlControl.isSit){
            float direction = Input.GetAxis("Horizontal");
            _position.x = _position.x + girlControl.speed * direction * Time.deltaTime;
            transform.position = _position;
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                shadowRigid.velocity = jumpVector;
            }
        }
    }
}
