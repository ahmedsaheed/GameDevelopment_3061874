using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    
    public float scoreValue;
    public GameManager gameManagerScript;
    public GameObject pickupEffect;    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript =  GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.gameObject.tag == "Player")
       {
           gameManagerScript.AddScore(scoreValue);
           Instantiate(pickupEffect, transform.position, transform.rotation);
           Destroy(gameObject);
       } 
    }
}
