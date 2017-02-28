using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    static Text txt;

	void Start ()
    {
        txt = GetComponentInChildren<Text>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
            gameObject.GetComponent<Canvas>().enabled = !gameObject.GetComponent<Canvas>().enabled;

        if (gameObject.GetComponent<Canvas>().enabled && Input.GetKeyDown(KeyCode.C))
            txt.text = "";
    }

    public static void WriteLine(string str)
    {
        txt.text += "\n" + str; 
    }
}
