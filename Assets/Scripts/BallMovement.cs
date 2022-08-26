using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rg2d;
    Vector3 mousePos;
    Vector2 direction;
    public bool isShot = false;
    public bool hasShot = false;

    [SerializeField] float moveSpeed = 30f;

    private GenerateBrick generateScript;
    [SerializeField] GameObject floor;
    
    void Start() 
    {        
        rg2d = GetComponent<Rigidbody2D>();
        generateScript = floor.GetComponent<GenerateBrick>();
    }

    void Update() 
    {
        MouseRotation();        
    }

    void MouseRotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;

        if (!isShot)
        {
            // rotate ball to look at the cursor            
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            transform.eulerAngles = new Vector3 (0,0, angle);
        }        
    }

    private void FixedUpdate() {
        if (Input.GetMouseButtonDown(0) && !isShot)
        {        
            // rg2d.constraints = RigidbodyConstraints2D.None;
            rg2d.AddForce(direction.normalized * moveSpeed);
            isShot = true;
            hasShot = true;
            generateScript.isSpawned = false;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Floor")
        {
            rg2d.velocity = Vector2.zero;                
            // rg2d.constraints = RigidbodyConstraints2D.FreezePosition;         
            isShot = false;
            Debug.Log("touched");
        }
    }    
    
    
}
