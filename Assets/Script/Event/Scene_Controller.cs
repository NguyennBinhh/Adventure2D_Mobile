using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Globalization;


public class Scene_Controller : MonoBehaviour
{
    private SelectLV_Anim SelectLV_Anim;
    [SerializeField] private Audio_Manager Audio_Manager;

    private void Start()
    {
        SelectLV_Anim = GetComponent<SelectLV_Anim>();
    }
    public void Load_Scene(string Name)
    {
        SceneManager.LoadScene(Name);
    } 
    
    public void Load_Level(int i)
    {
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
        StartCoroutine(Load_LVAnim(i));
    }    

    public void Btn_Home()
    {
        Audio_Manager.Play_SFX(Audio_Manager.Click_Button);
        SceneManager.LoadScene("Home");
    }

    IEnumerator Load_LVAnim(int i)
    {
        SelectLV_Anim.Select_LVOut();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Level_" + i);
    }    

    
    
}
