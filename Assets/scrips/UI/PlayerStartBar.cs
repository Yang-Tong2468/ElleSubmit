using UnityEngine;
using UnityEngine.UI;

public class PlayerStartBar : MonoBehaviour
{
    public Image bloodImage;

    public Image bloodDelayImage;

    public void OnBloodChange(float persentage){
        bloodImage.fillAmount = persentage;
    }
}
