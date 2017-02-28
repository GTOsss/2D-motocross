using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ClickEventHandler : MonoBehaviour {

    static ClickEventHandler clickEvtHndl;
    public static ClickEventHandler clickEventHandler { get { return clickEvtHndl; } }

    public void Awake()
    {
        clickEvtHndl = this;
    }

    public void LoadLvl(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
    }

    public void ButtonMenuClick(string nameCanvas)
    {
        List<RectTransform> Elements = GUIMainMenu.elements;

        for (int i = 0; i < Elements.Count; i++)
        {
            string[] splits = Elements[i].name.Split(' ');
            if(splits.Length >= 2)
            {
                Canvas canvas = Elements[i].gameObject.GetComponent<Canvas>();
                if (splits[1] == "Main" && splits[0] == "Canvas")
                    canvas.enabled = !canvas.enabled;
                else if (splits[1] == nameCanvas && splits[0] == "Canvas")
                    canvas.enabled = !canvas.enabled;
            }
        }
    }

    public void ButtonMenuClick2(string nameCanvas2)
    {
        List<RectTransform> Elements = GUIMainMenu.elements;
        string[] namesCanvas = nameCanvas2.Split(' ');
        for (int i = 0; i < Elements.Count; i++)
        {
            string[] splits = Elements[i].name.Split(' ');
            if (splits.Length >= 2)
            {
                Canvas canvas = Elements[i].gameObject.GetComponent<Canvas>();
                if (splits[1] == namesCanvas[0] && splits[0] == "Canvas")
                    canvas.enabled = !canvas.enabled;
                else if (splits[1] == namesCanvas[1] && splits[0] == "Canvas")
                    canvas.enabled = !canvas.enabled;
            }
        }
    }

    public void CreateRoom()
    {
        RoomList.roomListReference.Clear();
        string itemtext = DropdownRoomLvls.dropdownRoomLvls.GetComponent<Text>().text;
        itemtext = itemtext.Split(' ')[1];
        ServerConnect.CreateRoom(itemtext);
    }

    public void Refresh()
    {
        RoomList.roomListReference.Clear();
        ServerConnect.GetRoomsList();
    }

    public void CancelCreateRoom()
    {
        ServerConnect.CancelCreateRoom(RoomNameText.roomNameText.GetNameRoom());
    }

    public void SelectRoom(string nameItemRoom)
    {
        Console.WriteLine(nameItemRoom);
        ServerConnect.SelectRoom(nameItemRoom);
    }

    public void StartNetworkGame()
    {
        BtnStartGame.btnStartGame.Btn.interactable = false;
        ServerConnect.StartNetworkGame();
    }
}
