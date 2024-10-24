using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public static DamagePlayer instance;
    //public Collider2D spikeCollider;

    public bool isTouching;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //spikeCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealthController.instance.isColored && isTouching)
        {
            PlayerHealthController.instance.DealDamage();
            PlayerHealthController.instance.isColored = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Hit");
            //FindObjectOfType<PlayerHealthController>().DealDamage();

            PlayerHealthController.instance.DealDamage();
                     
            isTouching = true;                        
        }
        
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            isTouching = false;           
        }
    }




}
