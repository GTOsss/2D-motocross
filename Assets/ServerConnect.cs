using UnityEngine;
using System.Collections;

public class ServerConnect : MonoBehaviour {

    static ServerConnect sc;
    public static ServerConnect serverConnect { get { return sc; } }

	void Start ()
    {
        sc = this;
        GetRoomsList();
	}
	
	void Update ()
    {
	
	}

    public static void GetRoomsList()
    {
        Application.ExternalCall("GetRoomsList");
    }

    public static void CreateRoom(string str)
    {
        Application.ExternalCall("CreateRoom", str);
    }

    public static void CancelCreateRoom(string str)
    {
        Application.ExternalCall("CancelCreateRoom", str);
    }

    public static void SelectRoom(string str)
    {
        Application.ExternalCall("SelectRoom", str);
    }

    public static void StartNetworkGame()
    {
        Application.ExternalCall("StartNetworkGame");
    }

    public void _GetRoomsList(string str)
    {
        RoomList.RoomsList.Add(str);
        RoomList.roomListReference.GenerateListPos();
    }

    public void _ClearListRooms()
    {
        RoomList.roomListReference.Clear();
    }

    public void _GetNameRoom(string name)
    {
        RoomNameText.roomNameText.SetNameRoom(name);
    }

    public void _Readiness()
    {
        Console.WriteLine("_Readiness");
        BtnStartGame.btnStartGame.Readiness();
    }

    public void _StartNetworkGame()
    {
        RoomNameText.roomNameText.StartLvl();
    }

}
