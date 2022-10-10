using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpLine : MonoBehaviour
{
    [SerializeField] float blinkOnWaitTime = 0.5f;
    [SerializeField] float blinkOffWaitTime = 0.5f;
    [SerializeField] GameObject gameOverLine;
    SpriteRenderer rend;
    bool isTriggered = false;
    
    

    void Start() 
    {
        rend = gameOverLine.GetComponent<SpriteRenderer>();  
              
    }
    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Brick" && !isTriggered)
        {            
            isTriggered = true;
            // rend.enabled = true;
            // Debug.Log("trigger works");
            StartCoroutine(Blink());
            
            
            
        }  
        
    }

    // TODO: if the bricks are not touching the line anymore, stop bricks blinking
    // private void OnTriggerExit2D(Collider2D other) 
    // {
    //     if (other.tag == "Brick" && isTriggered)
    //     {            
    //         isTriggered = false;
    //         // rend.enabled = true;
    //         // Debug.Log("trigger works");
    //         // StartCoroutine(Blink()); 
    //         StopCoroutine(Blink());     
            
            
    //     } 
    // }

    // private void OnTriggerExit2D(Collider2D other) 
    // {
    //     if (other.tag == "Brick")
    //     {            
    //         rend.enabled = true;
    //         Debug.Log("trigger works");
    //         StartCoroutine(Blink());
            
            
    //     }  
    // }
    IEnumerator Blink()
    {
        while(true)
        {
            rend.enabled = true;            
            yield return new WaitForSeconds(blinkOnWaitTime);
            rend.enabled = false;
            yield return new WaitForSeconds(blinkOffWaitTime);
            
            // Debug.Log("blink workds");
        }
        
    }

    
}
