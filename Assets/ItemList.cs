using UnityEngine;
using System.Collections;

public class ItemList : MonoBehaviour {

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void SelectRoomItem()
    {
        RoomNameText.roomNameText.SetNameRoom(gameObject.name);
        ClickEventHandler.clickEventHandler.SelectRoom(gameObject.name);
    }
}
