using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class Level_UI_Anim : MonoBehaviour
{
    public RectTransform Frm_PauseRect;
    public RectTransform Btn_Input;
    public RectTransform Btn_Pause;
    public RectTransform Fruit;
    
    public void Frm_PauseIn()
    {
        Frm_PauseRect.DOAnchorPosY(0, 0.3f).SetUpdate(true);
        Btn_Input.DOAnchorPosY(-400, 0.2f).SetUpdate(true);
        Btn_Pause.DOAnchorPosX(1050, 0.2f).SetUpdate(true);
        Fruit.DOAnchorPosY(150, 0.2f).SetUpdate(true);
        
    }  
    public void Frm_PauseOut()
    {
        Btn_Input.DOAnchorPosY(0, 0.2f).SetUpdate(true);
        Btn_Pause.DOAnchorPosX(852, 0.2f).SetUpdate(true);
        Fruit.DOAnchorPosY(0, 0.2f).SetUpdate(true);
    }    
    
      
    

}
