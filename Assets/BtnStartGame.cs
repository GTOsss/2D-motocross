using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnStartGame : MonoBehaviour {

    string strWait = "ОЖИДАНИЕ ИГРОКА";
    string strStart = "СТАРТ";

    Button btn;
    public Button Btn { get { return btn; } }

    Text txt;

    static BtnStartGame btnsg;
    public static BtnStartGame btnStartGame { get { return btnsg; } } 

    void Awake()
    {
        btnsg = this;
    }

    void Start ()
    {
        btn = gameObject.GetComponent<Button>();
        txt = gameObject.GetComponentInChildren<Text>();

        txt.text = strWait;
        btn.interactable = false;
	}
	
	void Update ()
    {
	
	}

    public void Readiness()
    {
        txt.text = strStart;
        btn.interactable = true;
    }
}
