using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Redactor2D : MonoBehaviour {

    [SerializeField]
    private bool uniform = true;
    [SerializeField]
    private bool autoSetUniform = false;

    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        cam.orthographic = true;

        if (uniform)
            SetUniform();
    }
    private void LateUpdate()
    {
        if (autoSetUniform && uniform)
            SetUniform();
    }
    private void SetUniform()
    {
        transform.position = new Vector3(Screen.width/2, Screen.height/2 * -1, 0);

        float orthographicSize = cam.pixelHeight / 2;
        if (orthographicSize != cam.orthographicSize)
            cam.orthographicSize = orthographicSize;
    }
}
