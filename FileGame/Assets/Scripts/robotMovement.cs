using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMovement : MonoBehaviour {

public float speed = 2.0f; 
public float origX;
public float useSpeed;
public float directionSpeed;
public float distance = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

 //if(moving)
         {
             if(origX - transform.position.x > distance)
             {
                 useSpeed = directionSpeed; //flip direction
             }
             else if(origX - transform.position.x < -distance)
             {
                 useSpeed = -directionSpeed; //flip direction
             }
             //Debug.Log (origX + " - " + transform.position.x + " = " + (origX - transform.position.x));
             transform.Translate(useSpeed*Time.deltaTime,0,0);
         }
     }
}