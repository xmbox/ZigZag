using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform takipEt;
    Vector3 fark;

    void Start()
    {
        //kameramla takip edilecek topun pozisyonu arasindaki farki aliyorum
        fark = transform.position - takipEt.position;
    }


    void Update()
    {
        
    }

    //kamera olaylarini late updatede yapiyorduk
    void LateUpdate()
    {
        //top dusmedigi surece takip et diyoruz
        if (Player.dustumu == false)
        {
            transform.position = takipEt.position + fark;
        }

    }
}
