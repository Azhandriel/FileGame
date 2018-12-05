using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletRotate : MonoBehaviour {

	// Use this for initialization

	public float speed = 10f;

	void Update () {

		transform.Rotate(Vector3.right, speed * Time.deltaTime);

	}
}
