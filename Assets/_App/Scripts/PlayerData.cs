namespace nhacdongvat
{
    using UnityEngine;

    public class Constant
    {
        public static int COUNT_SONG = 18;
        public static int PRICE_UNLOCK_SONG = 100;
        public static string DataKeyPlayer = "player_data";
    }

    public class PlayerData : BaseData
    {
        public int coinCount;
        public int currentSong;
        public bool[] listSongs;
        public bool isUnlock;

        public override void Init()
        {
            prefString = Constant.DataKeyPlayer;
            if (PlayerPrefs.GetString(prefString).Equals(""))
            {
                ResetData();
            }

            base.Init();
        }

        public void PlusCoins(int a)
        {
            coinCount += a;
            /////////////////////////////////////////////////////////////////////////
            Save();
        }

        public bool CheckCanUnlock()
        {
            /////////////////////////////////////////////////////////////////////////
            return coinCount >= Constant.PRICE_UNLOCK_SONG;
        }

        public bool CheckLock(int id)
        {
            return this.listSongs[id];
        }


        public override void ResetData()
        {
            coinCount = 0;
            currentSong = 0;
            listSongs = new bool[Constant.COUNT_SONG];
            isUnlock = false;

            for (int i = 0; i < 8; i++)
            {
                listSongs[i] = true;
            }

            Save();
        }


        public void SubDiamond(int a)
        {
            coinCount -= a;

            if (coinCount < 0)
            {
                coinCount = 0;
            }

            Save();
        }

        public void ChooseSong(int i)
        {
            currentSong = i;
            Save();
        }

        public void Unlock(int id)
        {
            /////////////////////////////////////////////////////////////////////////
            if (!listSongs[id])
            {
                listSongs[id] = true;
            }

            Save();
        }


        public void UnlockPack()
        {
            isUnlock = true;
            Save();
        }
    }
}