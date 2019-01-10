using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminci : MonoBehaviour
{
    //her zaman son zemine eklenecegi icin son zemine ulasiyorum
    public GameObject sonZemin;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            ZeminOlustur();
        }
    }

    public void ZeminOlustur()
    {
        Vector3 yon;

        //0 gelirse yani x ekseninde saga ekleyecek
        if (Random.Range(0,2) == 0)
        {
            yon = Vector3.right;
        }
        //1 gelirse de z ekseninde ileriye ekleyecek
        else
        {
            yon = Vector3.back;
        }

        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
    }

    void Update()
    {
        
    }
}
