using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {

    float timer = 0;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3((100 * Time.time) * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3((-100 * Time.time) * Time.deltaTime, 0, 0);


        if (timer <= Time.time)
        {
            timer = Time.time + 0.05f;
            NetworkMotoController.networkMotoController.SendTransform(transform.position, transform.rotation);
        }
    }
}
