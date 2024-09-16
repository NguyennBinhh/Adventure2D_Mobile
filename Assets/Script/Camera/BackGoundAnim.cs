using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGoundAnim : MonoBehaviour
{
    [SerializeField] private GameObject Back1;
    [SerializeField] private GameObject Back2;
    [SerializeField] private float Speed;
    [SerializeField] private Transform Check;
    private Vector3 Start_Post;

    private void Start()
    {
        Start_Post = Back2.transform.position;
    }

    private void Update()
    {
        Vector3 Direction = Vector3.right;
        Back1.transform.position += Speed * Time.deltaTime * Direction;
        Back2.transform.position += Speed * Time.deltaTime * Direction;
        if(Back1.transform.position.x >= Check.position.x)
            Back1.transform.position = Start_Post;
        if (Back2.transform.position.x >= Check.position.x)
            Back2.transform.position = Start_Post;

    }
}
