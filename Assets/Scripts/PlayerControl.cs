using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class PlayerControl : MonoBehaviour {

    public float WalkSpeedForward = 10.0f;
    public float WalkSpeedBack = 5.00f;
    public float JumpValue = 4;

    public Transform trn;

    Rigidbody2D rigi;

    void Start ()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        ClickHandler();
    }

    void ClickHandler()
    {
        if (Input.GetKey(KeyCode.D))
            Walk(KeyCode.D, 0);
        else if (Input.GetKey(KeyCode.A))
            Walk(KeyCode.A, 0);

        //if (Input.GetKeyDown(KeyCode.W))
        //    Jump(KeyCode.W, 1);

    }

    void Walk(KeyCode key, byte stat)
    {
        float x = transform.position.x, y = transform.position.y, z = transform.position.z;
        if (key == KeyCode.D && stat == 0)
        {
            x += WalkSpeedForward * Time.deltaTime;
        }
        else if (key == KeyCode.A && stat == 0)
        {
            x -= WalkSpeedBack * Time.deltaTime;
        }

        transform.position = new Vector3(x, y, z);
    }

    //void Jump(KeyCode key, byte stat)
    //{

    //    if (key == KeyCode.W && stat == 1 && rigi.IsTouchingLayers())
    //    {
    //        rigi.AddForce(new Vector2(0, JumpValue), ForceMode2D.Impulse);
    //    }
    //}
}
