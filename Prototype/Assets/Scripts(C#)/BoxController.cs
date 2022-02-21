using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject Girl;
    public GameObject Shadow;
    public GameObject BoxShadow;

    float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //소녀 오브젝트의 GirlController 컴포넌트를 호출
        GirlController girlControl = Girl.GetComponent<GirlController>();
        
        //만약 소녀가 앉았을 경우
        if(girlControl.isSit){
            transform.position = new Vector2(BoxShadow.transform.position.x, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player"){
            if(other.contacts[0].normal.y < -0.7f){
                distance = transform.position.x - Girl.transform.position.x;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.collider.tag == "Player"){
            if(other.contacts[0].normal.y < -0.7f){
                if(Girl.GetComponent<GirlController>().isSit)
                    Girl.transform.position = new Vector2(transform.position.x - distance, Girl.transform.position.y);
            }
        }
    }
}
