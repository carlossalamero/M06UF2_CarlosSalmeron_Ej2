using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   private SFXManager sfxmanager;

   private BCMManager bgmmanager;

   int ContCoin;


   void Awake()
   {

      sfxmanager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
      bgmmanager = GameObject.Find("BGMManager").GetComponent<BCMManager>();

   }

   public void DeathMario()
   {

      sfxmanager.DeathSound();
      bgmmanager.STOPBGM();
      


   }

    public void levelCoin()
   {

      sfxmanager.levelSound();

   }

   public void DeathGoomba(GameObject goomba)
   {
        //Variable para el animator del goomba
        Animator goombaAnimator;
        Enemies goombaScript;
        BoxCollider2D goombaCollider;
        //valor asignado
        goombaScript = goomba.GetComponent<Enemies>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();
        //cambiamos a animacion de muerte
        goombaAnimator.SetBool("GoombaDeath", true);

        goombaScript.isAlive = false;
        /*
        goombaCollider.size = new Vector2(1, 0.5f);
        goombaCollider.offset = new Vector2(0, 0.25f);*/

        goombaCollider.enabled = false;

        Destroy(goomba, 0.3f);

        sfxmanager.GoombaSound();
     
       
   }
 

   public void Catchcoin(GameObject Coin)
   {
        Animator coinAnimator;
        BoxCollider2D coinCollider;
        //valor asignado
        coinCollider = Coin.GetComponent<BoxCollider2D>();
        coinAnimator = Coin.GetComponent<Animator>();
        sfxmanager.CoinSound();
     
       
   }
    public void CatchFlag(GameObject Bandera)
   {
        BoxCollider2D BanderaCollider;
        //valor asignado
        BanderaCollider = Bandera.GetComponent<BoxCollider2D>();
        
        sfxmanager.levelSound();
     
       
   }
     public void  Contarmoneda (GameObject contador){

      ContCoin = ContCoin+1;
      Debug.Log("Tienes "+ContCoin+" monedas");




   }
      
}
