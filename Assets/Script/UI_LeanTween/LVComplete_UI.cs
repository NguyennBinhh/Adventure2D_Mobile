
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVComplete_UI : MonoBehaviour
{
    [SerializeField] private GameObject Title_LVcomplete;
    [SerializeField] private GameObject Back_Gr;
    [SerializeField] private GameObject Img_Start1;
    [SerializeField] private GameObject Img_Start2;
    [SerializeField] private GameObject Img_Start3;
    [SerializeField] private GameObject Btn_Home;
    [SerializeField] private GameObject Btn_Replay;
    [SerializeField] private GameObject Btn_ListLV;
    [SerializeField] private GameObject Btn_NextLV;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject Banner;
    

    public void Level_ComplIn()
    {
        LeanTween.scale(Banner, new Vector3(1f, 1f, 1f), 0.1f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alphaCanvas(Banner.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(0.1f);
        LeanTween.scale(Title_LVcomplete, new Vector3(1.5f, 1.5f, 1.5f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(Title_LVcomplete, new Vector3(0f, 278f, 0f), .4f).setDelay(2f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(Title_LVcomplete, new Vector3(1f, 1f, 1f), 1.5f).setDelay(1.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(Btn_In);
    }
    public void Btn_In()
    {
        LeanTween.moveLocal(Back_Gr, new Vector3(0f, -26f, 0f), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutCirc).setOnComplete(Star_Anim);
        LeanTween.scale(Btn_Home, new Vector3(1f, 1f, 1f), 2f).setDelay(.7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Btn_ListLV, new Vector3(1f, 1f, 1f), 2f).setDelay(.8f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Btn_Replay, new Vector3(1f, 1f, 1f), 2f).setDelay(.9f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Btn_NextLV, new Vector3(1f, 1f, 1f), 2f).setDelay(.9f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alphaCanvas(Score.GetComponent<CanvasGroup>(), 1f, .5f).setDelay(0.5f);
    }    
    public void Star_Anim()
    {
        int i = PlayerPrefs.GetInt("StarLVNow" + (SceneManager.GetActiveScene().buildIndex - 1));
        if (i == 1)
            LeanTween.scale(Img_Start1, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        else if (i == 2)
        {
            LeanTween.scale(Img_Start1, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Img_Start2, new Vector3(1f, 1f, 1f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        }
        else if (i == 3)
        {
            LeanTween.scale(Img_Start1, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Img_Start2, new Vector3(1f, 1f, 1f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Img_Start3, new Vector3(1f, 1f, 1f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        }
    }
        
}
