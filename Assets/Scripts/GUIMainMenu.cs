using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIMainMenu : MonoBehaviour {

    static float lvlProg = 2;
    public static float LevelsProgress { get { return lvlProg; } set { lvlProg = value; } }

    List<Button> Buttons = new List<Button>();
    static List<RectTransform> Elements = new List<RectTransform>();
    public static List<RectTransform> elements { get { return Elements; } }

    public float ImageHeight;

    void Awake()
    {
        Elements.Clear();
        Buttons.Clear();
        Elements.AddRange(GetComponentsInChildren<RectTransform>());

        for (int i = 0; i < Elements.Count; i++)
        {
            string[] splits = Elements[i].name.Split(' ');
            if (splits[0] == "Button")
                Buttons.Add(Elements[i].GetComponent<Button>());
            else if (splits[0] == "Image")
                ImageHeight = Elements[i].rect.height;
        }
    }

	void Start ()
    {
        if (MotoController.downEscape)
        {
            foreach (RectTransform el in Elements)
            {
                if (el != null && el.gameObject.name == "Canvas Lvls" && !el.gameObject.GetComponent<Canvas>().enabled)
                {
                    ClickEventHandler.clickEventHandler.ButtonMenuClick("Lvls");
                    break;
                }
            }
        }
    }

    void Update ()
    {
        ButtonsControl();
	}

    void ButtonsControl()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (i <= lvlProg - 1)
            {
                ColorBlock cb = Buttons[i].colors;
                cb.normalColor = new Color(255, 255, 255, 255);
                Buttons[i].colors = cb;
                Buttons[i].interactable = true;
            }
            else
            {
                ColorBlock cb = Buttons[i].colors;
                cb.disabledColor = new Color(0.2f, 0.2f, 0.2f, 255);
                Buttons[i].colors = cb;
                Buttons[i].interactable = false;
            }
        }
    }

}
