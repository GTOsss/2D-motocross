using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTrigger : MonoBehaviour
{
    public List<GameObject> GameObjects = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObjects.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObjects.Remove(col.gameObject);
    }

    void OnTriggerStay2D(Collider2D col)
    {
    }

}
