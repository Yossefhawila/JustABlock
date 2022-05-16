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
        UiBody.SetActive(true);
        Invoke("HideUi", 2);

    }

    // Start is called before the first frame update
    private void Awake()
    {
        SetUiBody(UiBody);
        UiSetName("Name");
        UiSetDescription("Description");
        UiBody.SetActive(false);


    }
    private void HideUi()
    {
        UiBody.SetActive(false);
    }


}
