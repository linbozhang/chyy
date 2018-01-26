using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {
    public GameObject[] showContent;
    private DefaultTrackableEventHandler preHandler;
    public void TriggerTarget(DefaultTrackableEventHandler handler)
    {
        preHandler = handler;
    }
    public void LostTarget(DefaultTrackableEventHandler handler,int index)
    {
        if(preHandler!=null&&preHandler==handler)
        {
            if (DefaultTrackableEventHandler.canShowContent)
            {
                if (showContent != null && showContent.Length > index)
                {
                    showContent[index].SetActive(true);
                }
                DefaultTrackableEventHandler.canShowContent = false;
            }
        }
        
    }

    public void BackToAR()
    {
        DefaultTrackableEventHandler.canShowContent = true;
    }
	// Use this for initialization
	void Start () {
		
	}
}
