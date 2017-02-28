using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    Canvas canvas;

    static bool finish = false;
    public static bool IsFinish { get { return finish; } set { finish = value; } }

    void Start ()
    {
        canvas = GUIlvl.GetGUIlvl.GetComponentInChildren<Canvas>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        MotoController.motoController.Stop();
        canvas.enabled = true;
        finish = true;
    }
}
