using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPos;
    Vector2 playerPos;
    [SerializeField]
    float platformDistance = default;
    // Start is called before the first frame update
    void Start()
    {
        PlatformUret();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }

    void PlatformUret()
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
        player.transform.parent = ilkPlatform.transform;
        platforms.Add(ilkPlatform);
        SonrakiPlatformPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = true;


        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if(i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatformPozisyon();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPos, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPlatformPozisyon();
    }

    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPos;
            if (platforms[i + 5].CompareTag("Platform"))
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastgeleAltin = Random.Range(0, 1f);
                if(rastgeleAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }

            
            SonrakiPlatformPozisyon();
        }
    }
    void SonrakiPlatformPozisyon()
    {
        platformPos.y += platformDistance;
        SiraliPozisyon();
    }
    //void KarmaPozisyon()
    //{
    //    float random = Random.Range(0, 1f);
    //    if (random < 0.5f)
    //    {
    //        platformPos.x = EkranHesaplayicisi.instance.Genislik / 2;
    //    }
    //    else
    //    {
    //        platformPos.x = -EkranHesaplayicisi.instance.Genislik / 2;
    //    }
    //}

    bool yon = true;
    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPos.x = EkranHesaplayicisi.instance.Genislik / 2;
            yon = false;
        }
        else
        {
            platformPos.x = -EkranHesaplayicisi.instance.Genislik / 2;
            yon = true;
        }
    }
}
