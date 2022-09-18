using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanHareket : MonoBehaviour
{
    float arkaplanKonum;
    float mesafe = 10.24f;

    // Start is called before the first frame update
    void Start()
    {
        arkaplanKonum = transform.position.y;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaplanKonum);
    }

    // Update is called once per frame
    void Update()
    {
        if (arkaplanKonum + mesafe <Camera.main.transform.position.y)
        {
            ArkaplanYerlestir();
        }
    }

    void ArkaplanYerlestir()
    {
        arkaplanKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaplanKonum);
        Vector2 yenipozisyon = new Vector2(0, arkaplanKonum);
        transform.position = yenipozisyon;
    }
}
