using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Player_Collider Checkpoint;
    [SerializeField] private Transform Repawn_Point;
    [SerializeField] private GameObject Flag_Idle;
    private Collider2D Cld_CheckPoint;
    [SerializeField] private Audio_Manager Audio_Manager;
    private void Start()
    {
        Cld_CheckPoint = GetComponent<Collider2D>();
        Checkpoint = GameObject.FindWithTag("Player").GetComponent<Player_Collider>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Checkpoint.Update_Checkpoint(Repawn_Point.position);
            Flag_Idle.SetActive(true);
            Cld_CheckPoint.enabled = false;
            Audio_Manager.Play_SFX(Audio_Manager.CheckPoint_Clip);
        }
    }
    
}
