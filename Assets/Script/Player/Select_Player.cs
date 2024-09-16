using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Player : MonoBehaviour
{
    [SerializeField] private GameObject[] Player;

    private void Awake()
    {
        for (int i = 0; i < Player.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("Character"))
            {
                Player[i].SetActive(true);
            }
            else
                Player[i].SetActive(false);
        }
    }
}
