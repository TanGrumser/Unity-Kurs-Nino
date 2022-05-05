using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour{
public Transform player;
Vector3 offset;


    // Start is called before the first frame update
    void Start() {
        offset = transform.position - player.position;
      
        Rigidbody2D rb;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        transform.position = player.position + offset;
    }
}