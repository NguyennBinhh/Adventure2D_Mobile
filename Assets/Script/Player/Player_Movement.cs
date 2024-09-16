using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D Rb_Pl;
    private SpriteRenderer Sr_Play;
    [SerializeField] private float Speed_Pl;
    [HideInInspector] public bool Check_PlDown;

    private void Awake()
    {
        Speed_Pl = 1f;
        Rb_Pl = GetComponent<Rigidbody2D>();
        Sr_Play = GetComponent<SpriteRenderer>();
    }

    public void Moving_Left()
    {
        Rb_Pl.velocity = new Vector2(-1 * Speed_Pl, Rb_Pl.velocity.y);
        Sr_Play.flipX = true;
    }

    public void Moving_Right()
    {
        Rb_Pl.velocity = new Vector2(1 * Speed_Pl, Rb_Pl.velocity.y);
        Sr_Play.flipX = false;
    }

    public void Player_Idle()
    {
        Rb_Pl.velocity = new Vector2(0, Rb_Pl.velocity.y);
    }

    public void Jump1_Player()
    {
        Rb_Pl.velocity = new Vector2(Rb_Pl.velocity.x, 2.3f);
    }

    public void Jump2_Player()
    {
        Rb_Pl.velocity = new Vector2(Rb_Pl.velocity.x, 2.8f);
    }

    public void Player_FallDown()
    {
        if(Rb_Pl.velocity.y < 0)
            Check_PlDown = true;
        else
            Check_PlDown = false;
    }
}