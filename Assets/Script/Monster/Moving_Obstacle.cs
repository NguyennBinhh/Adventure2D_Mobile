using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_O : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject Ways;
    [SerializeField]
    private Transform[] Way_Points;
    Vector3 Target_Pos;
    int Point_Index;
    int Point_Count;
    int Direction = 1;
    [SerializeField]
    private float Wait_Duration;
    int Speed_Multiplier = 1;
    private void Awake()
    {
        Way_Points = new Transform[Ways.transform.childCount];
        for (int i = 0; i < Ways.gameObject.transform.childCount; i++)
        { 
            Way_Points[i] = Ways.transform.GetChild(i).gameObject.transform;
        }

    }

    private void Start()
    {
        Point_Count = Way_Points.Length;
        Point_Index = 1;
        Target_Pos = Way_Points[Point_Index].transform.position;
    }

    private void Update()
    {
        var Step = Speed_Multiplier * Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Target_Pos, Step); 
        if (transform.position == Target_Pos)
        {
           Next_Point();
        }
    
    }

    void Next_Point()
    {
        if(Point_Index == Point_Count - 1)
        {
            Direction = -1;
        }
        if(Point_Index == 0)
        {
            Direction = 1;
        }
        Point_Index += Direction;
        Target_Pos = Way_Points[Point_Index].transform.position;
        StartCoroutine(Wait_NextPoint());
    } 

    IEnumerator Wait_NextPoint()
    {
        Speed_Multiplier = 0;
        yield return new WaitForSeconds(Wait_Duration);
        Speed_Multiplier = 1;
    }    
}
