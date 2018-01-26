using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetModel : MonoBehaviour {
    public GameObject target;

    void OnEnable()
    {
        target.transform.localPosition = Vector3.zero;
        target.transform.localEulerAngles = Vector3.zero;
        target.transform.localScale = Vector3.one;
    }
    void OnDisable()
    {
        target.transform.localPosition = Vector3.zero;
        target.transform.localEulerAngles = Vector3.zero;
        target.transform.localScale = Vector3.one;
    }
	// Use this for initialization
	void Start () {
		
	}
}
