using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File_rotation : MonoBehaviour {

   float speed;

	// Use this for initialization
	void Start () {

        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        speed = Random.Range(80, 180);

    }
	
	// Update is called once per frame
	void Update () {
        
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
