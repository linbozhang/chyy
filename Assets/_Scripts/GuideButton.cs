using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class GuideButton : MonoBehaviour {

    public GameObject[] showContent;
    public GameObject[] hideContent;
    private Button button
    {
        get
        {
            return GetComponent<Button>();
        }
    }
    void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }
    void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }
    void OnClick()
    {
        if(showContent!=null)
        {
            for(int i=0;i<showContent.Length;i++)
            {
                if(showContent[i])
                {
                    showContent[i].SetActive(true);
                }
            }
        }
        if(hideContent!=null)
        {
            for(int i=0;i<hideContent.Length;i++)
            {
                if(hideContent[i])
                {
                    hideContent[i].SetActive(false);
                }
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
