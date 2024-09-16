using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;



public class Player_Collider : MonoBehaviour
{
    private Vector2 Repawn_Postion;
    private Rigidbody2D Rb_Player;
    [SerializeField] private GameObject Trail;
    [HideInInspector] public bool Check_CldFruit;
    [HideInInspector] public bool Check_CldMonster;
    [HideInInspector] public bool Check_CldEnd;
    [SerializeField] private LVComplete_UI LVComplete_UI;
    

    private void Start()
    {
      
        Rb_Player = GetComponent<Rigidbody2D>();
        Repawn_Postion = transform.position;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Player_Die();
            Check_CldMonster = true;
        }
        if (collision.CompareTag("Fruit"))
        {
            collision.gameObject.SetActive(false);
            Check_CldFruit = true;
        }
        if(collision.CompareTag("End"))
        {
            Check_CldEnd = true;
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Index"))
            {
                PlayerPrefs.SetInt("Index", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockLV", PlayerPrefs.GetInt("UnlockLV", 1) + 1);
                PlayerPrefs.Save();
            }
            LVComplete_UI.Level_ComplIn();
        }
        
    }

      
    public void Update_Checkpoint(Vector2 Checkpoint)
    {
        Repawn_Postion = Checkpoint;
    }    
    private void Player_Die()
    {
        StartCoroutine(Player_Repawn(0.3f));
    }    
    IEnumerator Player_Repawn(float Time_Repawn)
    {
        Rb_Player.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        Trail.SetActive(false);
        yield return new WaitForSeconds(Time_Repawn);
        transform.position = Repawn_Postion;
        Rb_Player.simulated = true;
        transform.localScale = new Vector3(1, 1, 1);
        Trail.SetActive(true);
        
    }    
}
