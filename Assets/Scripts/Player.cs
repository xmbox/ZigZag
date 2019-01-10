using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 yon;
    public float hiz;
    public zeminci zeminYap;
    public static bool dustumu;
    public float zorluk;
    public int puanArtir;
    public Text puanText;
    float skor;
    int bestSkor;

    void Start()
    {
        //en yuksek skoru burada get ile aliyorum
        bestSkor = PlayerPrefs.GetInt("bestskor");
        dustumu = false;
        yon = Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        if (dustumu)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0)
            {
                yon = Vector3.right;
            }
            else
            {
                yon = Vector3.back;
            }
        }

        // dusup dusmedigini kontrol edelim
        if (transform.position.y < 0.1f)
        {
            Oldun();
        }
    }

    void Oldun()
    {
        if (bestSkor < (int)skor)
        {
            bestSkor = (int)skor;
            PlayerPrefs.SetInt("bestskor", bestSkor);
        }

        dustumu = true;
    }

    private void FixedUpdate()
    {
        if (dustumu)
        {
            return;
        }

        Vector3 hareket = yon * Time.deltaTime * hiz;
        transform.position += hareket;
        //oyunun zorluk yani hizlanmasini ayarlayalim
        hiz += zorluk * Time.deltaTime;

        //puan artirma kontrolunu yapalim
        skor += (puanArtir * hiz * Time.deltaTime);
        puanText.text = ((int)skor).ToString();
    }

    void OnCollisionExit(Collision col)
    {
        //Collision olunca gameobject.tag diyoruz
        if (col.gameObject.tag == "zemin")
        {
           StartCoroutine(Yoket(col.gameObject));
            zeminYap.ZeminOlustur();
        }
    }

    IEnumerator Yoket(GameObject kaldir)
    {
        yield return new WaitForSeconds(0.3f);
        kaldir.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1.5f);
        Destroy(kaldir);
    }
}
