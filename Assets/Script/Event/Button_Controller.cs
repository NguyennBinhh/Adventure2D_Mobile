using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Frm_Pause;  
    private Level_UI_Anim Level_UI_Anim;
    private RectTransform Frm_PauseRect;
    [SerializeField] private Audio_Manager audio_Manager;
    private void Awake()
    {
        Level_UI_Anim = GetComponent<Level_UI_Anim>();
    }
    public void Btn_Pause()
    {
        Frm_Pause.SetActive(true);
        Time.timeScale = 0;
        Level_UI_Anim.Frm_PauseIn();
        audio_Manager.Play_SFX(audio_Manager.Click_Button);
    } 
    
    public async void Btn_Resume()
    {
        Time.timeScale = 1;
        await Wait_FrmPause();
        Frm_Pause.SetActive(false);
        
    }  

    public void Btn_Restart(int i)
    {
        SceneManager.LoadScene("Level_" + i);
        audio_Manager.Play_SFX(audio_Manager.Click_Button);
        Time.timeScale = 1;
    } 
    
       
       
    public void Btn_Home()
    {
        audio_Manager.Play_SFX(audio_Manager.Click_Button);
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

    public void Btn_ListLV()
    {
        audio_Manager.Play_SFX(audio_Manager.Click_Button);
        SceneManager.LoadScene("ListLevel");
        Time.timeScale = 1;
    }

    async Task Wait_FrmPause()
    {
        audio_Manager.Play_SFX(audio_Manager.Click_Button);
        await Level_UI_Anim.Frm_PauseRect.DOAnchorPosY(800, 0.2f).SetUpdate(true).AsyncWaitForCompletion();
        Level_UI_Anim.Frm_PauseOut();
    }
}
