using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectLV_Anim : MonoBehaviour
{
    [SerializeField] private GameObject Frm_SelectLV;
    [SerializeField] private GameObject[] Btn_Lv;
    [SerializeField] private Button[] List_BtnLV;
    [SerializeField] private GameObject[] Pn_Lock;

    private void Start()
    {
        Select_LVIn();
        Star();
    }

    private void Select_LVIn()
    {
        LeanTween.moveLocal(Frm_SelectLV, new Vector3(0f, 160f, 51437f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(Ui_LV);
        
    }    
    private void Ui_LV()
    {
        float n = 0.5f;
        for (int i = 0; i < Btn_Lv.Length; i++)
        {
            LeanTween.scale(Btn_Lv[i], new Vector3(1f, 1f, 1f), 1.5f).setDelay(n).setEase(LeanTweenType.easeOutElastic);
            n = n + 0.2f;
        }
    }

    public void Select_LVOut()
    {
        LeanTween.moveLocal(Frm_SelectLV, new Vector3(0f, 1080f, 51437f), 0.5f).setDelay(.0f).setEase(LeanTweenType.easeOutCubic).setOnComplete(Ui_LV);
    }
    [SerializeField] private GameObject[] Star_Lv1;
    [SerializeField] private GameObject[] Star_Lv2;
    [SerializeField] private GameObject[] Star_Lv3;
    private void Star()
    {
        int a = PlayerPrefs.GetInt("StarLV1");
        int b = PlayerPrefs.GetInt("StarLV2");
        int c = PlayerPrefs.GetInt("StarLV3");
        for (int i = 0; i < a; i++)
        {
            Star_Lv1[i].SetActive(true);
        }
        for (int i = 0; i < b; i++)
        {
            Star_Lv2[i].SetActive(true);
        }
        for (int i = 0; i < c; i++)
        {
            Star_Lv3[i].SetActive(true);
        }
    }
        
}
