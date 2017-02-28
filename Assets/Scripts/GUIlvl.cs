using UnityEngine;
using System.Collections;

public class GUIlvl : MonoBehaviour {

    static GUIlvl guilvl;
    public static GUIlvl GetGUIlvl { get { return guilvl; } }

    void Awake()
    {
        guilvl = this;
    }

    void Start ()
    {
    }
	
	void Update ()
    {
	
	}
}
