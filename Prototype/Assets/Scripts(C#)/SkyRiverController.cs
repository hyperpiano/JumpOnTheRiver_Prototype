using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRiverController : MonoBehaviour
{
    //속도 변수 선언
    float skyriverSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //1초에 5.4px의 속도로 움직임
        skyriverSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x - skyriverSpeed * Time.deltaTime, transform.localPosition.y);
        
    }
}
