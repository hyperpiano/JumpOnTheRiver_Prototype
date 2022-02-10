using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    public GameObject Girl;

    GirlController girlControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        girlControl = Girl.GetComponent<GirlController>();
        transform.localPosition = new Vector2(transform.localPosition.x - girlControl.direction * girlControl.speed * 0.00015f, transform.localPosition.y);
    }
}
