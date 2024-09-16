
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [HideInInspector] public bool Check_MoveLeft;
    [HideInInspector] public bool Check_MoveRight;
    [HideInInspector] public bool Check_BtnMoveUp;
    [HideInInspector] public bool Check_Jump;

    public void Btn_LeftDown()
    {
        Check_MoveLeft = true;
    }

    public void Btn_RightDown()
    {

        Check_MoveRight = true;
    }

    public void Btn_MoveUp()
    {
        Check_MoveLeft = false;
        Check_MoveRight = false;
    }

    public void Btn_JumpDown()
    {
       
        Check_Jump = true;
    }
    public void Btn_JumpUp()
    {
        Check_Jump = false;
    }
}
