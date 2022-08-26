using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBrick : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] GameObject ball;
    int numberToSpawn;
    int maxSpawnNum = 6;
    int minSpawnNum = 5;
    List<int> spawnPosList = new List<int>();
    public List<GameObject> brickSpawns = new List<GameObject>();    
    

    // Vector2 screenBounds;
    float brickWidth;
    float brickHeigth;
    [SerializeField] float initPosX = 5f;
    [SerializeField] float initPosY = 20f;  

    private BallMovement ballScript;

    private BoxCollider2D bRenderer;

    public bool isSpawned = false;


    void Start() 
    {
        ballScript = ball.GetComponent<BallMovement>();
        bRenderer = toSpawn.GetComponent<BoxCollider2D>();
        brickHeigth = bRenderer.size.y;        
        brickWidth = bRenderer.size.x;
        
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // make a possible pos list for spawning bricks
        for (int i=0; i<maxSpawnNum; i++)
        {
            spawnPosList.Add(i);            
        }

        spawnBricks();
        
    }
   

    void OnCollisionEnter2D(Collision2D other) 
    {
        // if isshot and mouse is clicked generate new line of bricks
        // when the ball touch the floor generate a new line of bricks
        // start = isShot false , ball in the air isShot true, touch isShot false again
        // 1. collide with floor(isShot) 2.    

        if (other.gameObject.tag == "Ball" && ballScript.hasShot && !isSpawned)
        {
            // if the ball hits the floor move existing bricks down by one line
            // and generate new line of bricks
            
            foreach (GameObject b in brickSpawns)
            {
                // b.transform.position = new Vector3 (10f,10f,0);
                b.transform.position = new Vector3 (b.transform.position.x, b.transform.position.y-brickHeigth*2+0.2f, 0);
                // b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y + 10f, b.transform.position.z);
            }
            spawnBricks();
        }
    }

    void spawnBricks() 
    {
        Vector2 pos;
        float screenX, screenY;
        

        numberToSpawn = Random.Range(minSpawnNum, maxSpawnNum) - 1;   
        Shuffle(spawnPosList);
        // for (int i=0;i<spawnPosList.Count;i++)
        // {
        //     Debug.Log(spawnPosList[i]);
        //     // Debug.Log(brickWidth);
        // }       
        

        for (int i=0; i<numberToSpawn;i++)
        {
            // screenX = Random.Range(-screenBounds.x, screenBounds.x);
            // shuffle the list and use index 0123
            
            screenX = initPosX + spawnPosList[i] * brickWidth*2;
            // screenX = initPosX;
            screenY = initPosY;

            pos = new Vector2(screenX, screenY);

            GameObject brick =  Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            brickSpawns.Add(brick);
        }
        isSpawned = true;
    }

    void Shuffle<T>(List<T> inputList)
    {
        for (int i=0;i<inputList.Count-1;i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
   
    
}
