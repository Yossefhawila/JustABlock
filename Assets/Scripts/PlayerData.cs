using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class PlayerData : MonoBehaviour

{
    public static PlayerData instance { get; private set; }

    public double MaterialValue;
    public double MaterialValueUpgrade=20000;
    public double SellPrice;
    public double SellMultiplier;
    public double SellMultiplierUpgrade=500;
    public double BuyPrice;
    public double BuyPriceMultiplier;
    public double BuyPriceMultiplierUpgrade=1000;
    public double ClickMultiplier;
    public double ClickMultiplierupgrade=100;


    private double _playerMoneyValue=0;
    public double PlayerMoneyValue 
    { 
        get 
        {
            return _playerMoneyValue; 
        } 
        set
        {
            if (value < 0)
            {
                Debug.LogError("Player Money Can't be negative! ");
            }
            else
            {
                _playerMoneyValue = value;

            }    
        }
   
    }

    private Text PlayerMoneyTextInUi;
    
    public void ADDMoney(double Amount)
    {
        SaveData();
        PlayerMoneyValue += Amount;
        PlayerMoneyTextInUi.text = getMoneyText(PlayerMoneyValue);
    }
    public string getMoneyText(double MOneyhere)
    {
        string sympol = "";

        string[] MoneySympols = { "K", "M", "B", "p", "a", "s", "q", "d", "f", "g", "h", "i", "l", "z", "x" };


        double MoneyVAL = MOneyhere;

        int x = -1;

        while (MoneyVAL > 1000)
        {
            if (MoneyVAL > 1000)
            {
                MoneyVAL /= 1000;
                x += 1;
            }
            if (x >= MoneySympols.Length - 1)
            {
                sympol += "x";
                x = -1;


            }

        }



        if (x == -1)
        {
            return MoneyVAL.ToString("0.#") + new string(sympol.ToCharArray().Reverse().ToArray());
        }
        else
        {
            sympol += MoneySympols[x];
            return MoneyVAL.ToString("0.#") + new string(sympol.ToCharArray().Reverse().ToArray());
        }

    }

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/jsonData.json"))
        {
            LoadData();
        }
        instance = this;
        PlayerMoneyTextInUi = gameObject.GetComponent<Text>();
        PlayerMoneyTextInUi.text = getMoneyText(PlayerMoneyValue);
    }

    [SerializeField]
    class PlayerGameData 
    {
        public double MaterialValue;
        public double MaterialValueUpgrade = 20000;
        public double SellPrice;
        public double SellMultiplier;
        public double SellMultiplierUpgrade = 500;
        public double BuyPrice;
        public double BuyPriceMultiplier;
        public double BuyPriceMultiplierUpgrade = 1000;
        public double ClickMultiplier;
        public double ClickMultiplierupgrade = 100;
        public double PlayerMoney;
    }
    private void SaveData()
    {
        PlayerGameData data = new PlayerGameData();
        data.MaterialValue = MaterialValue;
        data.MaterialValueUpgrade = MaterialValueUpgrade;
        data.SellPrice = SellPrice;
        data.SellMultiplier = SellMultiplier;
        data.SellMultiplierUpgrade = SellMultiplierUpgrade;
        data.BuyPrice = BuyPrice;
        data.BuyPriceMultiplier = BuyPriceMultiplier;
        data.BuyPriceMultiplierUpgrade = BuyPriceMultiplierUpgrade;
        data.ClickMultiplier = ClickMultiplier;
        data.ClickMultiplierupgrade = ClickMultiplierupgrade;
        data.PlayerMoney = PlayerMoneyValue;
        
        string JsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/jsonData.json", JsonData);

    }
    
    private void LoadData()
    {
        PlayerGameData data = new PlayerGameData();
        string json = File.ReadAllText(Application.persistentDataPath + "/jsonData.json");
        data = JsonUtility.FromJson<PlayerGameData>(json);
        MaterialValue = data.MaterialValue;
        MaterialValueUpgrade = data.MaterialValueUpgrade;
        SellPrice = data.SellPrice;
        SellMultiplier = data.SellMultiplier;
        SellMultiplierUpgrade= data.SellMultiplierUpgrade;
        BuyPrice = data.BuyPrice;
        BuyPriceMultiplier= data.BuyPriceMultiplier;
        BuyPriceMultiplierUpgrade = data.BuyPriceMultiplierUpgrade;
        ClickMultiplier = data.ClickMultiplier;
        ClickMultiplierupgrade = data.ClickMultiplierupgrade;
        PlayerMoneyValue = data.PlayerMoney;

    }



}
