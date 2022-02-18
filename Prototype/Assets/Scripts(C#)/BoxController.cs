using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject Girl;
    public GameObject Shadow;
    public GameObject BoxShadow;
    

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
}
