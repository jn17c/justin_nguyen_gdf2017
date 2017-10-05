using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_1pt : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float angle = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, angle));

	}
}
