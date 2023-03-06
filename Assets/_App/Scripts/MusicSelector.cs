using nhacdongvat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelector : MonoBehaviour
{
    public int currentMusic;

    public GameObject popupUnlock;
    public Button yesBtn, noBtn;


    public MusicItem[] musicItems;
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; //todo delete
    public TextMeshProUGUI diamonds;
    public GameObject inApp;

    void Start()
    {
        for (int i = 0; i < musicItems.Length; i++)
        {
            musicItems[i].Init(gameData.songSo.GetSongWithID(i).icon, i, this, gameData.songSo.GetSongWithID(i).name);

            if (playerData.listSongs[i])
            {
                musicItems[i].Unlock();
            }
        }

        noBtn.onClick.AddListener(() => { popupUnlock.SetActive(false); });

        yesBtn.onClick.AddListener(() => { popupUnlock.SetActive(false); });
    }

    void OnEnable()
    {
        /////////////////////////////////////////////////////////////////////////
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;
        /////////////////////////////////////////////////////////////////////////
        diamonds.text = "" + playerData.coinCount;
        currentMusic = playerData.currentSong;
        if (currentMusic > -1)
        {
            musicItems[currentMusic].Choose();
            AudioManager.Instance.PlaySong(currentMusic);
            AudioManager.Instance.Play();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void ChooseMusic(int index)
    {
        if (currentMusic == index)
        {
            return;
        }

        if (playerData.listSongs[index] == false)
        {
            if (!playerData.CheckCanUnlock())
            {
                inApp.SetActive(true);
                return;
            }

            popupUnlock.SetActive(true);

            yesBtn.onClick.AddListener(() =>
            {
                UnlockSkin(index);
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => { popupUnlock.SetActive(false); });
            });

            return;
        }

        if (currentMusic > -1)
        {
            musicItems[currentMusic].UnChoose();
        }

        musicItems[index].Choose();
        currentMusic = index;
        playerData.ChooseSong(currentMusic);

        AudioManager.Instance.PlaySong(currentMusic);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void AddDiamonds(int value)
    {
        IAPManagerSingleton.OnPurchaseThanhCong = () =>
        {
            playerData.PlusCoins(value);

            diamonds.text = playerData.coinCount.ToString();
        };

        switch (value)
        {
            case 100:
                IAPManagerSingleton.Instance.BuyProductWithID(IAPKeyConstant.PACK1);
                break;
            case 200:
                IAPManagerSingleton.Instance.BuyProductWithID(IAPKeyConstant.PACK2);
                break;
            case 500:
                IAPManagerSingleton.Instance.BuyProductWithID(IAPKeyConstant.PACK3);
                break;
            case 1000:
                IAPManagerSingleton.Instance.BuyProductWithID(IAPKeyConstant.PACK4);
                break;
        }
    }

    public void UnlockSkin(int index)
    {
        if (!playerData.listSongs[index])
        {
            playerData.SubDiamond(Constant.PRICE_UNLOCK_SONG);
        }

        diamonds.text = playerData.coinCount.ToString();
        musicItems[index].Unlock();
        playerData.listSongs[index] = true;
    }
}