using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock : MonoBehaviour
{
    protected float MaterialValue=10;
    protected float BuyPrice=0;
    protected float SellPrice=1;
    protected float NowSellPrice;
    protected float SellMultiplier;
    protected float BuyMultiplier;
    protected float ClickMultiplier;
    protected float PriceForClick;

    

    protected virtual float GetAmount()
    {
        float amount =MaterialValue*ClickMultiplier;
        return amount;
    } 
    protected virtual void IncreasePrice(float Amout)
    {
        NowSellPrice += Amout;
    }
    protected virtual void sellBlock(float Amount)
    {

    }
}
