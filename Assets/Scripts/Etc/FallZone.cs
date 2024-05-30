using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    // 떨어지는 물건 낚아채는 용도 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(0f, 0.7f, 0f);
        }
        else
        {
            Destroy(collision.gameObject); // 발사형 투사체들이 사라지지 않게 유의할 것
        }
    }
}
