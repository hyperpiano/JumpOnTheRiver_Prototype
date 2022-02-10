using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRiverController : MonoBehaviour
{
    //속도 변수 선언
    float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x - speed * Time.deltaTime, transform.localPosition.y);
        
        if (transform.localPosition.x <= 10.0f){
            transform.localPosition = new Vector2(62.3f, transform.localPosition.y);
        }
    }
}
