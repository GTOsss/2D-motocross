using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UINastart : MonoBehaviour {

    static UINastart UiNastart;
    static public UINastart uiNastart { get { return UiNastart; } }

    void Awake()
    {
        UiNastart = this;
    }

	void Start ()
    {
	    
	}
	
	void Update ()
    {
	
	}

    public void SetText(string str)
    {
        GetComponentInChildren<Text>().text = str;
    }

}
