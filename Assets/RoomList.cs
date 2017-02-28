using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomList : MonoBehaviour {

    public GameObject item;
    public RectTransform pointStart;
    RectTransform itemRect;
    
    static List<string> roomList = new List<string>();
    public static List<string> RoomsList { get { return roomList; } set { roomList = value; } }

    static RoomList rl;
    public static RoomList roomListReference { get { return rl; } }

    int indentY = 4;

    List<RectTransform> roomListRect = new List<RectTransform>();


    void Start ()
    {
        GenerateListPos();
        rl = this;
        itemRect = item.GetComponent<RectTransform>();
    }
	
	void Update ()
    {

	}

    public void GenerateListPos()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            //if (roomListRect.Exists((a) => a.gameObject.name == roomList[i]))
            //    return;

            RectTransform rt = Instantiate(item).GetComponent<RectTransform>();
            Vector3 v = new Vector3(pointStart.position.x, (i * -1) * (indentY + rt.sizeDelta.y) + pointStart.transform.position.y, pointStart.position.z);
            rt.position = v;
            rt.gameObject.name = roomList[i];
            rt.GetComponentInChildren<Text>().text = roomList[i];
            rt.parent = gameObject.transform;
            roomListRect.Add(rt);
        }
    }

    public void Clear()
    {
        foreach (var item in roomListRect)
        {
            Destroy(item.gameObject);
        }

        roomListRect.Clear();
        roomList.Clear();

        Debug.Log(roomList.Count);
    }


}
