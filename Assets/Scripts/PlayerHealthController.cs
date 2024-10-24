using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    
    public int maxHealth, currentHealth;
      
    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;
    //private Collider2D playerCollider;

    public bool isColored;

    public GameObject deathEffect;
    private void Awake()
    {
        instance = this;

        theSR = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);

                /*if (playerCollider.IsTouching(DamagePlayer.instance.spikeCollider))
                {
                    DealDamage();
                }*/

                isColored = true;
                
                
            }
        }

        
    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {

            //currentHealth--; => takeAwayOne      currentHealth++; => addOne
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);

                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();

            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                
                AudioManager.instance.PlaySFX(9);

                PlayerController.instance.KnockBack();


            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth++;
        UIController.instance.UpdateHealthDisplay();
    }



    
    

}
