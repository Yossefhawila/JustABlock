using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class BaseUi : MonoBehaviour
{
    protected string NameTitle;
    protected string description;
    protected GameObject UiBody;
    private Text NameText;
    private Text DescriptionText;


    protected virtual void SetUiBody(GameObject Body )
    {
        
        UiBody = Body;
        NameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
        DescriptionText = GameObject.FindGameObjectWithTag("DescriptionText").GetComponent<Text>();
        Invoke("HideUi",0.01f);
    }
    protected virtual void UiSetName(string NameTitle)
    {
        this.NameTitle = NameTitle;
        NameText.text = NameTitle;
    }

    protected virtual void UiSetDescription(string description)
    {
        this.description = description;
        DescriptionText.text = description;
    }

    protected  void showUi()
    {
        UiSetName("Name");
        UiSetDescription("Description");
        UiBody.SetActive(true);
        Invoke("HideUi", 2.1f);

    }

    // Start is called before the first frame update
    private void Awake()
    {
        SetUiBody(GameObject.FindGameObjectWithTag("InfoUi"));
    }
    private void HideUi()
    {
        UiBody.SetActive(false);
    }


}
