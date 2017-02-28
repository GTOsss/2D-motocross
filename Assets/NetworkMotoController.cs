using UnityEngine;
using System.Collections;

public class NetworkMotoController : MonoBehaviour {

    float timer = 0;
    float startTime = 0;
    Vector3 vector3B;
    Quaternion quaternionB;

    static NetworkMotoController nmc;
    static public NetworkMotoController networkMotoController { get { return nmc; } }

    void Awake()
    {
        nmc = this;
    }

    void Start ()
    {
        vector3B = MotoController.motoController.gameObject.transform.position;
        startTime = Time.time;
	}

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, vector3B, (Vector3.Distance(transform.position, vector3B) * 4) * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternionB, Time.deltaTime * 10);
    }

    void Update ()
    {

    }

    string TransformToString(Vector3 pos, Quaternion rot)
    {
        return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, rot.w);
    }

    public void SendTransform(Vector3 pos, Quaternion rot)
    {
        //Application.ExternalCall("SendTransform", TransformToString(pos, rot));
        //_SetTransform(TransformToString(pos, rot));
    }

    public void _SetTransform(string str)
    {
        startTime = Time.time;
        string[] sp = str.Split(',');
        vector3B = new Vector3(float.Parse(sp[0]), float.Parse(sp[1]), float.Parse(sp[2]) + 10);
        quaternionB = new Quaternion(float.Parse(sp[3]), float.Parse(sp[4]), float.Parse(sp[5]), float.Parse(sp[6]));
    }

    public void _SetNastart(string str)
    {
        if (str == "0")
        {
            Finish.IsFinish = false;
            UINastart.uiNastart.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            UINastart.uiNastart.SetText(str);
            MotoController.motoController.Stop();
            Finish.IsFinish = true;
        }
    }

}
