using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    List<GameObject> gezegenler = new List<GameObject>();
    List<GameObject> kullanilanGezegenler = new List<GameObject>();
    private void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");

        for(int i = 1; i < sprites.Length; i++)
        {
            GameObject gezegen = new GameObject();
            SpriteRenderer spriteRenderer = gezegen.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)sprites[i];
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0.7f;
            spriteRenderer.color = spriteColor;
            gezegen.name = sprites[i].name;
            spriteRenderer.sortingLayerName = "Gezegen";
            Vector2 pozisyon = gezegen.transform.position;
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);
        }
    }

    public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayicisi.instance.Yukseklik;
        float genislik = EkranHesaplayicisi.instance.Genislik;

        //1.Bolge
        float xDeger1 = Random.Range(0,genislik);
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        Debug.Log(refY);
        GameObject gezegen1 = RandomGezegen();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);
        //2.Bolge
        float xDeger2 = Random.Range(-genislik, 0);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        Debug.Log(refY);
        GameObject gezegen2 = RandomGezegen();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);
        //3.Bolge
        float xDeger3 = Random.Range(-genislik, 0);
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        Debug.Log(refY);
        GameObject gezegen3 = RandomGezegen();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);
        //4.Bolge
        float xDeger4 = Random.Range(0, genislik);
        float yDeger4 = Random.Range(refY - yukseklik, refY);
        Debug.Log(refY);
        GameObject gezegen4 = RandomGezegen();
        gezegen4.transform.position = new Vector2(xDeger4, yDeger4);
    }

    GameObject RandomGezegen()
    {
        if(gezegenler.Count > 0)
        {
            int random;
            if(gezegenler.Count == 1)
            {
                random = 0;
            }
            else
            {
                random= Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                gezegenler.Add(kullanilanGezegenler[i]);
            }
            kullanilanGezegenler.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;

        }
        
    }
}
