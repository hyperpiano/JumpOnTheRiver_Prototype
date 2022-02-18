using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //1초에 10.8px의 속도로 움직임
        cloudSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //배경 흐르게 하기
        transform.localPosition = new Vector2(transform.localPosition.x - cloudSpeed * Time.deltaTime, transform.localPosition.y);
        if(transform.localPosition.x < -62.0f){
            transform.localPosition = new Vector2(150.8f, 0f);
        }
    }
}
