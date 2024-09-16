using UnityEngine;

public class SprikedBall : MonoBehaviour
{
    [SerializeField] private Transform Pivot;
    [SerializeField] private float Length;
    [SerializeField] private float BDG;
    [SerializeField] private float Speed;
    [SerializeField] private Transform[] Chain_Links;
    [SerializeField] private float KC;
    private float Current_Angle;

    private void Awake()
    {
        KC = 0.07f;
        Length = 0.7f;
        BDG = 45f;
        Speed = 1f;
    }
    void Start()
    {
        Current_Angle = BDG;
    }
    void Update()
    {
        Current_Angle = BDG * Mathf.Sin(Time.time * Speed);
        float x = Length * Mathf.Sin(Current_Angle * Mathf.Deg2Rad);
        float y = -Length * Mathf.Cos(Current_Angle * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, 0) + Pivot.position;
        Vector3 previousPosition = Pivot.position;
        for (int i = 0; i < Chain_Links.Length; i++)
        {
            Vector3 directionToBall = transform.position - previousPosition;
            directionToBall = directionToBall.normalized * KC;
            Chain_Links[i].position = previousPosition + directionToBall;
            Chain_Links[i].up = directionToBall;
            previousPosition = Chain_Links[i].position;
        }
        transform.position = previousPosition;
    }
        
}
