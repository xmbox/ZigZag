using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renkler : MonoBehaviour
{
    public Color[] renkler;
    Color ilkRenk;
    Color ikinciRenk;
    int birRenk;

    //zemin rengini degistirmek icin semin materyaleine ulasiyorum
    public Material zeminmat;

    void Start()
    {
        //ilk secilecek rengi aliyorum
        birRenk = Random.Range(0, renkler.Length);
        //ilk rengi materyal rengine esitliyorum
        zeminmat.color = renkler[birRenk];
        //kamera arka planini da degistirelim
        Camera.main.backgroundColor = renkler[birRenk];
        ikinciRenk = renkler[IkinciRenk()];
    }

    int IkinciRenk()
    {
        int ikiRenk;
        if (renkler.Length <= 1)
        {
            ikiRenk = birRenk;
            return ikiRenk;
        }

        ikiRenk = Random.Range(0, renkler.Length);

        while (ikiRenk == birRenk)
        {
            ikiRenk = Random.Range(0, renkler.Length);
        }

        return ikiRenk;
    }


    void Update()
    {
        Color fark = zeminmat.color - ikinciRenk;

        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b) < 0.2f)
        {
            ikinciRenk = renkler[IkinciRenk()];
        }

        //renkler arasi gecisi tanimlayalim
        zeminmat.color = Color.Lerp(zeminmat.color, ikinciRenk, 0.008f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.008f);
    }
}
