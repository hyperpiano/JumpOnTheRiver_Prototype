using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //카메라의 움직임의 최대, 최솟값
    float min = -7.5f;
    float max = 1500.0f;

    //소녀와 그림자 게임 오브젝트
    public GameObject Girl;
    public GameObject Shadow;

    //소녀 오브젝트 안의 GirlController 컴포넌트와
    //그림자 오브젝트 안의 ShadowController 컴포넌트
    GirlController girlControl;
    ShadowController shadowControl;
    // Start is called before the first frame update
    void Start()
    {
        girlControl = Girl.GetComponent<GirlController>();
        shadowControl = Shadow.GetComponent<ShadowController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Girl.transform.position.x < min){
            gameObject.transform.position = new Vector3(min - min ,gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if(Girl.transform.position.x > max){
            gameObject.transform.position = new Vector3(max - min ,gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else{
            gameObject.transform.position = new Vector3(Girl.transform.position.x - min, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        
    }
}
