using UnityEngine;
using System.Collections;

public class ScrollPlayerMenu : MonoBehaviour {

    public float ScrollSpeed = 100;

    static ScrollPlayerMenu example;
    public static ScrollPlayerMenu scrollPlayerMenu { get { return example; } }

    void Awake()
    {
        example = this;
    }

	void Start ()
    {
	}
	
	void Update ()
    {
        transform.position = new Vector3(transform.position.x + ScrollSpeed * Time.deltaTime, transform.position.y, transform.position.z);
	}
}
