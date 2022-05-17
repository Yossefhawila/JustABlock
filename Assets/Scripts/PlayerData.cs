using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour

{
    public PlayerData instance { get; private set; }

    public float SellMultiplier { get; private set; }
    public float BuyMultiplier { get; private set; }
    public float ClickMultiplier { get; private set; }
    public float PriceForClick { get; private set; }
    private double _playerMoneyValue;
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
    private string PlayerMoneyTextInUi;
    
    
    

    private string getMoneyText(double MOneyhere)
    {
        string sympol = "";

        string[] MoneySympols = { "K", "M", "B", "p", "o", "O", "a", "s", "q", "d", "f", "g", "h", "i", "l", "z", "x" };


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

 

}
