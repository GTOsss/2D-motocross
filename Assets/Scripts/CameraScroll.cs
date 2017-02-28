
using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {

    public float PlusCamPos = 500;
    public float OverviewCamY = 301;

    Main mainScr;
    Transform Player;

    static CameraScroll example;
    public static CameraScroll cameraScroll { get { return example; } }

    void Awake()
    {
        example = this;
    }

    void Start ()
    {
        if(MotoController.motoController != null)
            Player = MotoController.motoController.gameObject.transform;
        else if(ScrollPlayerMenu.scrollPlayerMenu != null)
            Player = ScrollPlayerMenu.scrollPlayerMenu.gameObject.transform;

        mainScr = Main.main;
	}
	
	void Update ()
    {
        float PosPlayerX = Player.position.x, PosPlayerY = Player.position.y, PosPlayerZ = Player.position.z;
        float CamPosX = transform.position.x, CamPosY = transform.position.y, CamPosZ = transform.position.z;

        CamPosX = PosPlayerX + PlusCamPos;
        CamPosY = Mathf.Clamp(PosPlayerY, -700 + OverviewCamY, 0 - OverviewCamY );
        this.transform.position = new Vector3(CamPosX, CamPosY, CamPosZ);

    }
}
