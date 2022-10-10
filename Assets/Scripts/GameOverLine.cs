using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    LevelManager levelManager;

    void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)     {
        

        
        if (other.tag == "Brick")
        {                                 
            levelManager.LoadGameOver();
        } 
    }
}
