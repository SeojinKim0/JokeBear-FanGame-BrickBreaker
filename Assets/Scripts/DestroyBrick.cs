using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{    
    [SerializeField] GameObject floor;
    private GenerateBrick generateScript;

    private void Start() {
        generateScript = floor.GetComponent<GenerateBrick>();
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Brick")
        {
            // maybe I should differentiate objects by their position
            // and grab the specific item of index and do remove at i guess
            // generateScript.brickSpawns.Remove(other.gameObject);
            // int index = generateScript.brickSpawns.IndexOf(other.gameObject);
            generateScript.brickSpawns.Remove(other.gameObject);
            Destroy(other.gameObject);            
        }
        
    }
}
