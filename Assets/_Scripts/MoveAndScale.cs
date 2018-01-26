using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndScale : MonoBehaviour {
    public Transform targetTrans;
    private Touch oldTouch1;
    private Touch oldTouch2;
    private Vector3 touchCenter;
    private Vector3 oldPos;
    private Vector3 realOldScale;
	// Use this for initialization
	void Start () {
		
	}
    void OnEnable()
    {
        targetTrans.localPosition = Vector3.zero;
        targetTrans.localScale = Vector3.one;
        targetTrans.localRotation = Quaternion.identity;
    }

    void OnDisable()
    {
        targetTrans.localPosition = Vector3.zero;
        targetTrans.localScale = Vector3.one;
        targetTrans.localRotation = Quaternion.identity;
    }

    private bool isFirstDTouch = true;
    void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2,10)));
        if (Input.touchCount <= 0)
        {
            return;
        }
        
        if(1==Input.touchCount)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;
            Vector3 targetPos = targetTrans.localPosition + new Vector3(0, deltaPos.y, 0);
            //if(deltaPos.y>deltaPos.x)
            //{
            //    if (targetPos.y > 1280 || targetPos.y < -1280)
            //    {

            //    }
            //    else
            //    {
            //        targetTrans.localPosition = targetPos;// new Vector3(0, deltaPos.y, 0);
            //    }
            //}
            //else
            {
                Vector3 oldE = targetTrans.localEulerAngles;
                oldE.y += deltaPos.x * 0.2f;
                targetTrans.localEulerAngles = oldE;
            }
           
          
            //targetTrans.localPosition = targetPos;
        }

        if(2==Input.touchCount)
        {
            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);

            if(isFirstDTouch)
            {
                oldTouch1 = newTouch1;
                oldTouch2 = newTouch2;
                touchCenter = (newTouch1.position + newTouch2.position) / 2;
                touchCenter.z = 10;
                touchCenter=Camera.main.ScreenToWorldPoint(touchCenter);
                touchCenter=targetTrans.InverseTransformPoint(touchCenter);
                oldPos = targetTrans.localPosition;
                realOldScale = targetTrans.localScale;
                isFirstDTouch = false;
                return;
            }
            //if (newTouch2.phase == TouchPhase.Began)
            //{
            //    oldTouch1 = newTouch1;
            //    oldTouch2 = newTouch2;
            //}

            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

            float offset = newDistance - oldDistance;
            float scaleFactor = offset * Time.deltaTime*0.2f;
            Vector3 localScale = targetTrans.localScale;
            Vector3 scale = new Vector3(localScale.x + scaleFactor, localScale.y + scaleFactor,localScale.z+scaleFactor);
            Vector3 oldScale = targetTrans.localScale;
            if (scale.x > 1 && scale.y > 1 &&scale.x<5&&scale.y<5)
            {
                targetTrans.localScale = scale;
            }

            float value = targetTrans.localScale.x / realOldScale.x;
            Vector3 center = touchCenter;// Camera.main.ScreenToWorldPoint(touchCenter);
            Vector2 offset1 = (oldPos - center)*value;

            //targetTrans.localPosition = new Vector3(center.x+ offset1.x,center.y+ offset1.y, targetTrans.localPosition.z);

            oldTouch1 = newTouch1;
            oldTouch2 = newTouch2;
        }else
        {
            isFirstDTouch = true;
        }
        
    }
}
