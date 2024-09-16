using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Home_UI_Anim : MonoBehaviour
{
    [SerializeField] private RectTransform Img_Logo;
    [SerializeField] private Transform[] List_Btn;
    [SerializeField] private RectTransform Img_LogoSB;
    [SerializeField] private RectTransform Btn_In4;
    [SerializeField] private GameObject Frm_In4;
    [SerializeField] private GameObject[] Btn_Select;
    [SerializeField] private GameObject[] Img_Success;
    [SerializeField] private Audio_Manager Audio_Manager;
    private void Awake()
    {
        
        var Sqc = DOTween.Sequence();
        Sqc.Append(Anim_Rect(Img_Logo, new Vector2(0, 1000), 0.4f));
        Sqc.Append(Anim_Button());
        Sqc.Join(Anim_Rect(Img_LogoSB, new Vector2(-500, 0), 0.5f));
        Sqc.Join(Anim_Rect(Btn_In4, new Vector2(500, 0), 0.3f));
        Sqc.OnComplete(() =>
        {
            Check_Select();
            Frm_In(Frm_In4);
        });
        Audio_Manager.Player_Music(Audio_Manager.Music_Clip);
        
    }

    private Sequence Anim_Rect(RectTransform rect, Vector2 Vt2_AnimPos, float Time_Anim)
    {
        var Sqc = DOTween.Sequence();
        if (rect == null)
            return Sqc;
        var OriginalPos = rect.anchoredPosition;
        var Anim_TargerPos = OriginalPos + Vt2_AnimPos;
        rect.anchoredPosition = Anim_TargerPos;
        var TweenAnim = rect.DOAnchorPos(OriginalPos, Time_Anim);
        Sqc.Append(TweenAnim);
        return Sqc;
       
    }  
    
    private Sequence Anim_Button()
    {
        var Sqc = DOTween.Sequence();
        if(List_Btn == null || List_Btn.Length <= 0)
            return Sqc;
        for(int i = 0; i < List_Btn.Length; i++)
        {
            var Btn = List_Btn[i];
            if (Btn == null) continue;
            Btn.localScale = Vector3.zero;
            var Btn_DotWeen = Btn.DOScale(1f, 0.2f);
            Sqc.Append(Btn_DotWeen);
        }
        return Sqc;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    public void Load_Scene(string Name)
    {
        SceneManager.LoadScene(Name);
    }    

    public void Frm_In(GameObject frm)
    {
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
        LeanTween.scale(frm, new Vector3(1f, 1f, 1f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    public void Frm_Out(GameObject frm)
    {
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
        LeanTween.scale(frm, new Vector3(0f, 0f, 0f), 0.2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    public void Select_Character(int i)
    {
        PlayerPrefs.SetInt("Character", i);
        Check_Select();
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
    }

    private void Check_Select()
    {
        int i = PlayerPrefs.GetInt("Character");
        for (int j = 0; j < 4; j++)
        {
            if (i == j)
            {
                Btn_Select[j].SetActive(false);
                Img_Success[j].SetActive(true);
            }
            else
            {
                Btn_Select[j].SetActive(true);
                Img_Success[j].SetActive(false);
            }
        }
    }

    public void Btn_Exit()
    {
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
        Application.Quit();
    }
}
