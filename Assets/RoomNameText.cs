using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomNameText : MonoBehaviour {

    static RoomNameText rNT;
    public static RoomNameText roomNameText { get { return rNT; } }

    void Awake()
    {
        rNT = this;
    }

	void Start ()
    {
	}
	
	void Update ()
    {
	
	}

    public void SetNameRoom(string name)
    {
        gameObject.GetComponent<Text>().text = name;
    }

    public string GetNameRoom()
    {
        return gameObject.GetComponent<Text>().text;
    }

    public void StartLvl()
    {
        string[] sp = gameObject.GetComponent<Text>().text.Split(' ');
        Console.WriteLine(sp[0]);
        Console.WriteLine(sp[1]);
        ClickEventHandler.clickEventHandler.LoadLvl(int.Parse(sp[1]));
    }

}
