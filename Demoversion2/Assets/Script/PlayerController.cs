using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator anim;
    private enum State {idle ,running , jumping,falling};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private int Coin = 0;
    [SerializeField] private Text Cointext;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumForce = 10f;
    [SerializeField] private int hp = 6;
    public GameObject pnlEndGame;
    
    [SerializeField] private Text hptext;
    [SerializeField] private LayerMask ground;

    public SoundManager sound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }


    private void Update()
    {


         
        float hDirection = Input.GetAxis("Horizontal");


        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            
        }


        else if(hDirection > 0 )
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
          
        }
        else
        {
         
        }


        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumForce);

            state = State.jumping;
        }

        VelocityState ();
        anim.SetInteger("state", (int)state);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hp = hp - 1;
            hptext.text = hp.ToString();
            if (hp <= 0)
            {
                pnlEndGame.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gem")
        {
            sound.Playsound("coins");
            Destroy(collision.gameObject);
            Coin += 100;
            Cointext.text = Coin.ToString();
        }

        if (collision.tag == "cherry")
        {
            sound.Playsound("coins");
            Destroy(collision.gameObject);
            Coin += 10;
            Cointext.text = Coin.ToString();
        }       

    }
    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }

        }
        else  if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x)> 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
      
    }
    
}
