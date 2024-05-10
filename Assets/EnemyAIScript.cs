using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour {
    public int health;
    public int damage;
    private float speed;
    public float aggroSpeed;
    public float aggroTime;
    public bool aggro;
    public float detectTime;
    private float initialSpeed;
    public bool playerDetected; 
    public Transform playerLocation;
    public enum AIBehaviour {Idle, Patrol, DetectPlayer, ChasePlayer, AggroIdle};
    public AIBehaviour aiBehaviour;
    private void Start() {
        initialSpeed = speed;
    }

    private void Update() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        switch (aiBehaviour) {
            case AIBehaviour.Idle:
                speed = 0;
                break;
            case AIBehaviour.Patrol:
                speed = initialSpeed; 
                break;
            case AIBehaviour.DetectPlayer:
                speed = 0;
                break;
            case AIBehaviour.ChasePlayer:
                speed = aggroSpeed;
                break;
            case AIBehaviour.AggroIdle:
                speed = 0;
                break;
            
        } 
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Player") && !aggro) {
            StopCoroutine("AggroTimer");
            StartCoroutine("DetectTimer");
        }
        if(coll.gameObject.CompareTag("Player") && aggro) {
            StopCoroutine("AggroTimer");
            aiBehaviour = AIBehaviour.ChasePlayer;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerDetected = false;
            if (!aggro){
                StopCoroutine("DetectTimer");
                StartCoroutine("DetectTimer");
            }
            if (aggro) {
                StartCoroutine("AggroTimer");
                StartCoroutine("AggroTimer");
            } 
        } 
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && aggro) {
            StopCoroutine("AggroTimer");
            aiBehaviour = AIBehaviour.ChasePlayer;
        }
    }

    IEnumerator DetectTimer() {
        aiBehaviour = AIBehaviour.DetectPlayer;
        yield return new WaitForSeconds(detectTime);
        if (playerLocation == true) {
            aggro = true; 
            aiBehaviour = AIBehaviour.ChasePlayer;
        }
        if (playerLocation == false) {
            aggro = false; 
            aiBehaviour = AIBehaviour.Idle;
        }
    }
    IEnumerator AggroTimer() {
        yield return new WaitForSeconds(aggroTime);
        aiBehaviour = AIBehaviour.AggroIdle;
        yield return new WaitForSeconds(aggroTime);
        if (aiBehaviour != AIBehaviour.ChasePlayer) {
            aiBehaviour = AIBehaviour.Idle;
            aggro = false; 
        }
    }
}
