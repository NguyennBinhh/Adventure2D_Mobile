using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform[] Player;
    private Vector3 Velocity = Vector3.zero;
    [SerializeField]
    private Vector3 Position_OffSet;

    [Header("Camera Limit")]
    public Vector2 CamX_Limit;
    public Vector2 CamY_Limid;

    private void LateUpdate()
    {
        Vector3 Vt3_PlPosstion = Player[PlayerPrefs.GetInt("Character")].position + Position_OffSet;
        Vt3_PlPosstion = new Vector3(Mathf.Clamp(Vt3_PlPosstion.x, CamX_Limit.x, CamX_Limit.y), Mathf.Clamp(Vt3_PlPosstion.y, CamY_Limid.x, CamY_Limid.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, Vt3_PlPosstion, ref Velocity, 0);  
    }
}
