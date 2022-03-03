using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float speed = 4.5f;
    
    private int directionX = 1;

    private Rigidbody2D rigiBody;

    public bool isAlive = true;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAlive)
        {

            rigiBody.velocity = new Vector2(directionX * speed, rigiBody.velocity.y);

        }else
        {

            rigiBody.velocity = Vector2.zero;

        }
        
        
    }

    void OnCollisionEnter2D(Collision2D hit)
   
    {
         if(hit.gameObject.tag == "Tuberias" || hit.gameObject.tag == "Goombas")
         {

                if(hit.gameObject.tag == "Tuberias")
                {

                    
                    if(directionX == 1)
                    {

                        directionX = -1;

                    }else
                    {

                        directionX = 1;

                    }

                }
                else if(hit.gameObject.tag == "MuereMario")
                {
                    
                    Destroy(hit.gameObject);
                    gameManager.DeathMario();

                }



    }
    }
}
