using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxshadowController : MonoBehaviour
{
    public GameObject Girl;
    public GameObject Shadow;
    public GameObject Box;

    float distance;

    GirlController girlControl;

    // Start is called before the first frame update
    void Start()
    {
        // GirlController 초기화
        girlControl = Girl.GetComponent<GirlController>();
    }

    // Update is called once per frame
    void Update()
    {       
        //만약 소녀가 앉았을 경우 플레이 주체가 소녀의 그림자이므로
        //상자의 Position X 값이 대응되는 상자 그림자의 Position X값이어야 한다. 
        if(!(girlControl.isSit)){
            transform.position = new Vector2(Box.transform.position.x, transform.position.y);
        }
    }
}
