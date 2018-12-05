using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectTablet : MonoBehaviour {

	 void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);	
	}
}
