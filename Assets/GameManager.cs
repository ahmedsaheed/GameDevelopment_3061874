using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public float playerHealth;
    public float playerScore;
    public float maxPlayerHealth;
    public GameObject player; 
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);    
    }
    // Start is called before the first frame update
    void Start()
    {
        
      player = GameObject.FindWithTag("Player");
       playerSpawnPoint = GameObject.FindWithTag("Start").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float score)
    {
        playerScore += score;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
    
    public void UpdateSpawnPoint(Transform newSpawnPoint) {
        playerSpawnPoint = newSpawnPoint;
    }

    public void RespawnPlayer() {
        player.transform.position = playerSpawnPoint.position;
    }
}
