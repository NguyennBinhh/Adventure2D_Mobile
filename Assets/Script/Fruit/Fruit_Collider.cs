using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fruit_Collider : MonoBehaviour
{
    private int Count_Fruit;
    [SerializeReference]
    private TextMeshProUGUI Txt_Fruit;

    private void Start()
    {
        Count_Fruit = 0;
        Txt_Fruit.text = "0";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Count_Fruit++;
            Txt_Fruit.text = Count_Fruit.ToString();
            gameObject.SetActive(false);
        }    
    }
}
