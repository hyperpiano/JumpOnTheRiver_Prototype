using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==================================상자 시스템적인 요소=====================================
//대응되는 상자들과 상자 그림자들의 Position X값은 서로 동일함
//그림자가 상자 그림자를 밀 경우, 상자가 상자 그림자의 X값에 맞춰서 이동됨
//소녀가 상자를 밀 경우, 상자 그림자가 상자의 X값에 맞춰서 이동됨
public class BoxController : MonoBehaviour
{
    public GameObject Girl;
    public GameObject Shadow;
    public GameObject BoxShadow;

    public float distance;

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
        if(girlControl.isSit){
            transform.position = new Vector2(BoxShadow.transform.position.x, transform.position.y);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.collider.tag == "Player"){
            if(other.contacts[0].normal.y < 0.7f){
                if(Girl.GetComponent<GirlController>().isSit)
                    //상자와 소녀 사이의 X축에 대한 거리 업데이트
                    //소녀가 앉았을 경우, 해당 거리만큼의 차이를 두고 같이 움직이도록 할 것
                    Girl.transform.position = new Vector2(transform.position.x - distance, Girl.transform.position.y);
            }
        }
    }
}
