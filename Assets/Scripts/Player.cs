using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //varaibles para variables y fuerza de salto
    public float speed = 5f;

    public float jumpforce = 10f;

    //variable para detectar suelo
    public bool tocaSuelo;

    //variable movimiento input 
    float dirx;

    //variables de componentes
    public SpriteRenderer renderer;

    public Animator animatronix;

    Rigidbody2D rBody;

    private GameManager gameManager;

    private SFXManager sfxmanager;

    void Awake()
    {
        //asignamos los componentes a las variables
        animatronix = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        
        Debug.Log(dirx);

       /* transform.position += new Vector3(dirx, 0, 0) * speed * Time.deltaTime;*/

         if(dirx == -1)
        {
            renderer.flipX = true;
            animatronix.SetBool("Running", true);
        }
        else if(dirx == 1)
        {
            renderer.flipX = false;
            animatronix.SetBool("Running", true);
        }
        else
        {
            animatronix.SetBool("Running", false);
        }
        
        if(Input.GetButtonDown("Jump") && tocaSuelo) 
        {

            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); 
            animatronix.SetBool("Salto", true);

        }

    }

    void FixedUpdate(){

        rBody.velocity = new Vector2(dirx * speed, rBody.velocity.y);

    }







    void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.CompareTag("Monedas")){

            Debug.Log("Moneda cogida");
            Destroy(collider.gameObject);
            gameManager.Contarmoneda(gameObject);
            gameManager.Catchcoin(collider.gameObject);
                  
        }

          if(collider.gameObject.CompareTag("Bandera")){

            Debug.Log("Nivel completado");
            
                  
        }

        if(collider.gameObject.layer == 6){

            Debug.Log("Goomba muerto");
            //llamamos a la funcion DeathGoomba del scripts GameManager
            gameManager.DeathGoomba(collider.gameObject);

        }

        if(collider.gameObject.CompareTag("Dead_zone")){

            Debug.Log("Muerte");
            

        }




    }
}
