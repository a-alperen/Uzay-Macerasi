using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    
    Vector2 velocity;

    [SerializeField]
    float hiz = default;
    
    [SerializeField]
    float hizlanma = default;
    
    [SerializeField]
    float yavaslama = default;
    
    [SerializeField]
    float ziplamaGucu = default;

    int ziplamaSiniri = 3;
    int ziplamaSayisi =0;

    Joystick joystick;

    JoystickButon joystickButon;

    bool zipliyor;
    
    // Start is called before the first frame update
    void Start()
    {
        joystickButon = FindObjectOfType<JoystickButon>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick= FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
            KlavyeKontrol();
        #else
            JoystickKontrol();
        #endif


    }

    void KlavyeKontrol()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (horizontal> 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x,horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (horizontal < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        
        transform.localScale = scale;
        gameObject.transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ZiplamayiBaslat();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ZiplamayiDurdur();
        }
    }

    void JoystickKontrol()
    {
        float horizontal = joystick.Horizontal;
        Vector2 scale = transform.localScale;

        if (horizontal > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (horizontal < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontal * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        gameObject.transform.Translate(velocity * Time.deltaTime);

        if(joystickButon.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            ZiplamayiBaslat();

        }
        if (joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi < ziplamaSiniri)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rigidbody2d.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaSiniri, ziplamaSayisi);
        }
        
    }
    void ZiplamayiDurdur()
    {
        ziplamaSayisi++;
        animator.SetBool("Jump", false);
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaSiniri, ziplamaSayisi);
    }

    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaSiniri, ziplamaSayisi);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Olum"))
        {
            FindObjectOfType<OyunSahneKontrol>().OyunuBitir();
        }
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
