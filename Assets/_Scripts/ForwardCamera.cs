using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCamera : MonoBehaviour {
    public Transform center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
       Vector3 euler=(Quaternion.FromToRotation( transform.forward,Camera.main.transform.forward)).eulerAngles;
        //Debug.Log(euler);
        if(euler.y>90&&euler.y<270)
        {
            center.localEulerAngles = new Vector3(0,180,0);
        }else
        {
            center.localEulerAngles = new Vector3(0, 0, 0);
        }
        //transform.forward = transform.position - Camera.main.transform.position;
	}
}
