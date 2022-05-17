using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoUi : BaseUi
{
    [SerializeField]
    private GameObject YesNoUiBody; 

    [SerializeField]
    private Text YesNoUiTitleName;
    [SerializeField]
    private Text YesNoUiDiscription;

    [SerializeField]
    private Button YesButton;
    [SerializeField]
    private Button NoButton;
    [SerializeField]
    private string PowerUpType;

   
    protected override void SetUiBody(GameObject Body)
    {
        UiBody = YesNoUiBody;
        NameText = YesNoUiTitleName;
        DescriptionText = YesNoUiDiscription;
        Invoke("HideUi", 0.01f);
    }
    protected override void Awake()
    {
        YesNoUiBody = GameObject.FindGameObjectWithTag("YesNoUi");
        YesNoUiTitleName = GameObject.FindGameObjectWithTag("YesNameText").GetComponent<Text>();
        YesNoUiDiscription = GameObject.FindGameObjectWithTag("YesDiscriptionText").GetComponent<Text>();
        YesButton = GameObject.FindGameObjectWithTag("YesButton").GetComponent<Button>();
        NoButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        YesButton.onClick.AddListener(onYesButtonClicked);
        NoButton.onClick.AddListener(onNoButtonClicked);


       SetUiBody(YesNoUiBody);

    }
    protected override void showUi()
    {
        UiBody.SetActive(true);
    }
    private void OnMouseDown()
    {
        Invoke(PowerUpType + "0", 0);
        showUi();

    }
    private void onYesButtonClicked()
    {
        
        Invoke(PowerUpType,0.1f);
    }
    private void onNoButtonClicked()
    {
       
        HideUi();
    }

    private void MaterialValueUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue * 100);
        YesNoUiDiscription.text = $"Increase Material value from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue * 100)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValueUpgrade)}";
    }
    private void SellMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier + 1);
        YesNoUiDiscription.text = $"Increase sell price from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier + 2)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplierUpgrade)}";
    }

    private void BuyPriceMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(1/(PlayerData.instance.BuyPriceMultiplier * 0.5f));
        YesNoUiDiscription.text = $"Decrease price Multiplier from " +
            $"x{PlayerData.instance.getMoneyText(1/PlayerData.instance.BuyPriceMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(1 / (PlayerData.instance.BuyPriceMultiplier * 0.5f))} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.BuyPriceMultiplierUpgrade)}";
    }
    private void ClickMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier * 1.1f);
        YesNoUiDiscription.text = $"Increase click Multiplier from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier *1.1f)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplierupgrade)}";
    }


    private void MaterialValueUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue>PlayerData.instance.MaterialValueUpgrade) 
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.BuyPriceMultiplierUpgrade);
            PlayerData.instance.MaterialValue *= 100;
            PlayerData.instance.MaterialValueUpgrade *= 100;
            IncreasBuyPrice(20);
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();

        }
    }
    private void IncreasBuyPrice(double IncreaseBy)
    {
        PlayerData.instance.BuyPrice *= IncreaseBy;
    }

    private void SellMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue > PlayerData.instance.SellMultiplierUpgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.SellMultiplierUpgrade);
            PlayerData.instance.SellMultiplier += 1;
            PlayerData.instance.SellMultiplierUpgrade *= 2;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();


        }
    }
    private void BuyPriceMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue > PlayerData.instance.BuyPriceMultiplierUpgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.BuyPriceMultiplierUpgrade);
            PlayerData.instance.BuyPriceMultiplier *= 0.5f;
            PlayerData.instance.BuyPriceMultiplierUpgrade *= 2;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();

        }
    }
    
    private void ClickMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue > PlayerData.instance.ClickMultiplierupgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.ClickMultiplierupgrade);
            PlayerData.instance.ClickMultiplier *= 1.1f;
            PlayerData.instance.ClickMultiplierupgrade *= 1.1f;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();

        }
    }
    private void GetMoney()
    {
        
    }






}
