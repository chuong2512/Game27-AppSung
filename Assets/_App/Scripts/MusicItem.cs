using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicItem : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameTMP;
    public Button button;
    public GameObject lockObj, chooseObj;

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void Init(Sprite sprite, int id, MusicSelector musicSelector, string name)
    {
        iconImage.sprite = sprite;
        nameTMP.SetText(name);
        button.onClick.AddListener(() => { musicSelector.ChooseMusic(id); });
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void Choose()
    {
        chooseObj.SetActive(true);
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void UnChoose()
    {
        chooseObj.SetActive(false);
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void Unlock()
    {
        lockObj.SetActive(false);
    }
}