using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    private Player_Input Player_Input;
    private Player_Movement Player_Movement;
    private Player_Animation Player_Animation;
    private Player_Collider Player_Collider;
    [SerializeField] private LVComplete_UI LVComplete_UI;
    [SerializeField] private GameObject Player_GO;

    // Double Jump
    [SerializeField] private Transform Tf_isGround;
    [SerializeField] private LayerMask Lm_Ground;
    private bool Check_IsGround;
    private bool Can_DoubleJump;

    // Va cham voi nguoi choi
    private int Count_Fruit;
    [SerializeReference] private TextMeshProUGUI Txt_Fruit;
    [SerializeReference] private TextMeshProUGUI Txt_Score;

    // Am thanh
    [SerializeField] private Audio_Manager Audio_Manager;


    [SerializeField] private PhysicsMaterial2D PhysicsMaterial;
    [SerializeField] private Transform isWall;
    
    private void Awake()
    {
        Player_Input = GetComponent<Player_Input>();
        Player_Movement = GetComponent<Player_Movement>();
        Player_Animation = GetComponent<Player_Animation>();
        Player_Collider = GetComponent<Player_Collider>();
        Count_Fruit = 0;
        Txt_Fruit.text = "0";
        Audio_Manager.Player_Music(Audio_Manager.Music_Clip);
    }

    private void Update()
    {
        Ctrl_MovePl();
        Ctrl_JumpPl();
        Ctrl_CldFruit();
        Ctrl_CldEnd();
        Ctrl_CldMonster();
        
    }
    private void Ctrl_MovePl()
    {
        if (Player_Input.Check_MoveLeft)
        {
            Player_Movement.Moving_Left();
            Player_Animation.Anim_MovePl(1);
        }
        else if (Player_Input.Check_MoveRight)
        {
            Player_Movement.Moving_Right();
            Player_Animation.Anim_MovePl(1);
        }
        else
        {
            Player_Movement.Player_Idle();
            Player_Animation.Anim_MovePl(0);
        }
    }

    private void Check_Wall()
    {
        bool Check_Plw = Physics2D.OverlapCapsule(isWall.position, new Vector2(0.02f, 0.1f), CapsuleDirection2D.Vertical, 0f, Lm_Ground);
        if (Check_Plw)
            PhysicsMaterial.friction = 0f;
        else
            PhysicsMaterial.friction = 0.4f;
    }

    private void Ctrl_JumpPl()
    {
        Check_IsGround = Physics2D.OverlapCircle(Tf_isGround.position, 0.05f, Lm_Ground);
        Player_Animation.Anim_Jump(Check_IsGround);
        Player_Movement.Player_FallDown();
        if (Check_IsGround)
        {
            Player_Animation.Anim_2Jump(false);
            Player_Animation.Anim_JumpDown(false);
        }
        else if (Check_IsGround == false && Player_Movement.Check_PlDown)
            Player_Animation.Anim_JumpDown(true);
        if (Check_IsGround && Player_Input.Check_Jump)
        {
            Player_Movement.Jump1_Player();
            Can_DoubleJump = true;
            Player_Input.Check_Jump = false;
            Audio_Manager.Play_SFX(Audio_Manager.Jump_Clip);
        }
        else if (Can_DoubleJump && Player_Input.Check_Jump)
        {
            Player_Movement.Jump2_Player();
            Can_DoubleJump = false;
            Player_Animation.Anim_2Jump(true);
            Audio_Manager.Play_SFX(Audio_Manager.Jump_Clip);
        }
    }

    private void Ctrl_CldFruit()
    {
        if(Player_Collider.Check_CldFruit)
        {
            Count_Fruit++;
            Txt_Fruit.text = Count_Fruit.ToString();
            Player_Collider.Check_CldFruit = false;
            Audio_Manager.Play_SFX(Audio_Manager.Fruit_Clip);
        } 
            
    } 

    private void Ctrl_CldMonster()
    {
        if (Player_Collider.Check_CldMonster)
        {
            Player_Collider.Check_CldMonster = false;
            Audio_Manager.Play_SFX(Audio_Manager.Fall_Clip);
        }
    }    
    
    private void Ctrl_CldEnd()
    {
        if(Player_Collider.Check_CldEnd)
        {
            int PL_Score = Count_Fruit * 100;
            int Star;
            if (PL_Score <= 2000)
                Star = 1;
            else if (PL_Score > 2000 && PL_Score <= 3000)
                Star = 2;
            else
                Star = 3;
            Txt_Score.text = PL_Score.ToString();
            PlayerPrefs.SetInt("StarLVNow" + (SceneManager.GetActiveScene().buildIndex - 1), Star);
            int Check_Star = PlayerPrefs.GetInt("StarLV" + (SceneManager.GetActiveScene().buildIndex - 1));
            if (Check_Star < Star)
                PlayerPrefs.SetInt("StarLV" + (SceneManager.GetActiveScene().buildIndex - 1), Star);
            Player_GO.SetActive(false);
            Audio_Manager.Play_SFX(Audio_Manager.LvComplete_Clip);
        }    
    }    
    
}
