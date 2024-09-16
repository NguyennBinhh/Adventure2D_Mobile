using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator At_Player;
    private void Awake()
    {
        At_Player = GetComponent<Animator>();
    }
    public void Anim_MovePl(int n)
    {
        At_Player.SetFloat("Player_Move", n);
    }

    public void Anim_Jump(bool Check)
    {
        At_Player.SetBool("Player_Jump", Check);
    }

    public void Anim_2Jump(bool Check)
    {
        At_Player.SetBool("Player_2Jump", Check);
    }

    public void Anim_JumpDown(bool Check) 
    {
        At_Player.SetBool("Player_Down", Check);
    }

    public void Anim_Die()
    {
        At_Player.SetTrigger("PLDie");
    }    
}
