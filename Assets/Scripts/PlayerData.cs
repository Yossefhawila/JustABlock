using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

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

    private double _playerMoneyValue=100000000;
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
        instance = this;
        PlayerMoneyTextInUi = gameObject.GetComponent<Text>();  
    }


}
