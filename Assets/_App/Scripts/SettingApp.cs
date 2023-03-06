using UnityEngine;

public class SettingApp : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void OnClickRateUs()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void OnClickPrivacy()
    {
        Application.OpenURL("");
    }

}