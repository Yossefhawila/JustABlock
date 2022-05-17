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


       SetUiBody(YesNoUiBody);

    }
    protected override void showUi()
    {
        UiBody.SetActive(true);
    }
    private void OnMouseDown()
    {
        showUi();
    }
}
