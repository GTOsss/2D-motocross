using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class Main : MonoBehaviour {
    public bool EnableInRedactor = false;

    public GameObject GroopTerrain;
    public GameObject GroopTerrainDesign;
    public GameObject SecondPlanes;
    public GameObject ThirdPlanes;
    public GameObject FourthPlanes;
    public GameObject Backgrounds;

    public List<GameObject> Terrains = new List<GameObject>();
    public float TerrainsSpeed = 0f;

    public List<GameObject> terrainsDesigns = new List<GameObject>();
    public float terrainsDesignsSpeed = 0f;

    public List<GameObject> secondPlanes = new List<GameObject>();
    public float secondPlanesSpeed = 8f;

    public List<GameObject> thirdPlanes = new List<GameObject>();
    public float thirdPlanesSpeed = 10f;

    public List<GameObject> fourthPlanes = new List<GameObject>();
    public float fourthPlaneSpeed = 14f;

    public List<GameObject> brnds = new List<GameObject>();
    public float backgroundSpeed = 5f;


    public float OverviewX = 450;
    public float OverviewY = 300;

    public float BrndWidth = 1000;
    float xB = 0;
    float LastCamPosX = 0;
    float CamPosX = 0;
    float PlayerSpeed = 0;

    Transform MainCamera;

    static Main example;
    public static Main main { get { return example; } }

    void Awake()
    {
        example = this;
    }

    void Start ()
    {
        MainCamera = CameraScroll.cameraScroll.gameObject.transform;
    }

    void Update ()
    {
        if (EnableInRedactor)
        {
            Terrains.Clear();
            terrainsDesigns.Clear();
            secondPlanes.Clear();
            thirdPlanes.Clear();
            fourthPlanes.Clear();
            brnds.Clear();

            List<Transform> trnsfrms = new List<Transform>(GroopTerrain.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != GroopTerrain.name)
                    Terrains.Add(item.gameObject);
            }

            trnsfrms.Clear();
            trnsfrms.AddRange(GroopTerrainDesign.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != GroopTerrainDesign.name)
                    terrainsDesigns.Add(item.gameObject);
            }

            trnsfrms.Clear();
            trnsfrms.AddRange(SecondPlanes.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != SecondPlanes.name)
                    secondPlanes.Add(item.gameObject);
            }

            trnsfrms.Clear();
            trnsfrms.AddRange(ThirdPlanes.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != ThirdPlanes.name)
                    thirdPlanes.Add(item.gameObject);
            }

            trnsfrms.Clear();
            trnsfrms.AddRange(FourthPlanes.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != FourthPlanes.name)
                    fourthPlanes.Add(item.gameObject);
            }

            trnsfrms.Clear();
            trnsfrms.AddRange(Backgrounds.GetComponentsInChildren<Transform>());
            foreach (var item in trnsfrms)
            {
                if (item.name != Backgrounds.name)
                    brnds.Add(item.gameObject);
            }

            EnableInRedactor = false;
        }

        CamPosX = MainCamera.position.x;
        PlayerSpeed = (LastCamPosX - CamPosX) / Time.deltaTime;

        GenerateVectorPlanes(brnds, backgroundSpeed);
        GenerateVectorPlanes(secondPlanes, secondPlanesSpeed);
        GenerateVectorPlanes(thirdPlanes, thirdPlanesSpeed);
        GenerateVectorPlanes(fourthPlanes, fourthPlaneSpeed);
        GenerateVectorPlanes(Terrains, TerrainsSpeed);
        GenerateVectorPlanes(terrainsDesigns, terrainsDesignsSpeed);

        LastCamPosX = CamPosX;
    }


    //void GenerateVectorPlanes(List<GameObject> list, float speed)
    //{
    //    BrndWidth = 1000;

    //    float MinCamX = CamPosX - OverviewX, MaxCamX = CamPosX + OverviewX;
    //    float PosPlus = CamPosX / speed;

    //    list = Sort(list);

    //    if (CamPosX > LastCamPosX)
    //    {
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            list = Sort(list);

    //            float CoifWidth = (Mathf.Floor((CamPosX + OverviewX - PosPlus) / BrndWidth + i - 1));
    //            xB = BrndWidth * CoifWidth + PosPlus;

    //            list[i].transform.position = new Vector3(xB, list[i].transform.position.y, list[i].transform.position.z);
    //        }
    //    }
    //    else if (CamPosX < LastCamPosX)
    //    {
    //        for (int i = list.Count - 1; i >= 0; i--)
    //        {
    //            list = Sort(list);

    //            float CoifWidth = (Mathf.Floor((CamPosX + OverviewX - PosPlus) / BrndWidth + i - 1));
    //            xB = BrndWidth * CoifWidth + PosPlus;

    //            list[i].transform.position = new Vector3(xB, list[i].transform.position.y, list[i].transform.position.z);
    //        }
    //    }
    //}

    void GenerateVectorPlanes(List<GameObject> list, float speed)
    {
        float MinCamX = CamPosX - OverviewX, MaxCamX = CamPosX + OverviewX;
        float Znak = 0;
        GetZnak(ref speed, ref Znak);
        list = Sort(list);

        for (int i = 0; i < list.Count; i++)
        {
            xB = list[i].transform.position.x + (speed * Time.deltaTime * Znak);
            list[i].transform.position = new Vector3(xB, list[i].transform.position.y, list[i].transform.position.z);
        }

        list = Sort(list);
        if (CamPosX > LastCamPosX && MaxCamX > list[list.Count - 1].transform.position.x + BrndWidth)
        {
            xB = list[list.Count-1].transform.position.x + BrndWidth;
            list[0].transform.position = new Vector3(xB, list[0].transform.position.y, list[0].transform.position.z);
        }
        else if (CamPosX < LastCamPosX && MinCamX < list[0].transform.position.x)
        {
            xB = list[0].transform.position.x - BrndWidth;
            list[list.Count - 1].transform.position = new Vector3(xB, list[list.Count - 1].transform.position.y, list[list.Count - 1].transform.position.z);
        }
    }

    void GetZnak(ref float speed, ref float Znak)
    {
        if (CamPosX > LastCamPosX)
        {
            speed = PlayerSpeed / 100 * speed;
            Znak = 1;
        }
        else if (CamPosX < LastCamPosX)
        {
            speed = PlayerSpeed / 100 * speed * -1;
            Znak = -1;
        }
    }

    List<GameObject> Sort(List<GameObject> list)
    {
        GameObject temp;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i].transform.position.x > list[j].transform.position.x)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
        return list;
    }

}
