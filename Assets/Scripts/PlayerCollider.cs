using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour {

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(!Finish.IsFinish)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
