using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //소녀와 소녀의 그림자 변수 선언
    public GameObject Girl;
    public GameObject Girl_Shadow;
    
    //소녀와 소녀의 그림자 Transform 변수 선언
    Transform girl_Transform;
    Transform girl_Shadow_Transform;
    
    //카메라 이동 속도
    //변수값 조절 가능
    float speed = 8.0f;

    //카메라가 이동해야 할 구간의 길이
    //(8 - (-7.5))
    public float distance = 15.5f;
    float i = 0f;
    int num = 1;

    void Start()
    {
        //Transform 변수 초기화
        girl_Transform = Girl.GetComponent<Transform>();
        girl_Shadow_Transform = Girl_Shadow.GetComponent<Transform>();
    }

    void Update()
    {
        //소녀와 그림자 모두 해당 위치에 있을 때
        if((girl_Transform.position.x >= 8f) && (girl_Shadow_Transform.position.x >= 8f) && (num == 1) && (i <= distance)){
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            i += speed * Time.deltaTime;
        }
        if((girl_Transform.position.x >= 23.5f) && (girl_Shadow_Transform.position.x >= 23.5f) && (num == 2) && (i <= distance)){
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            i += speed * Time.deltaTime;
        }

        if(i > distance){
            num++;
            i = 0;
        }
    }
}
