using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    int currentMenu = 1;
    [SerializeField]
    private GameObject Mainmenu;
    [SerializeField]
    private GameObject ShopMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        MenuAutoChangerByClick();
    }

    private void SelectMenu(int menuIndex)
    {
        if(menuIndex == 0)
        {
            Mainmenu.SetActive(true);
            ShopMenu.SetActive(false);
            currentMenu = 0;
        }
        else
        {
            ShopMenu.SetActive(true);
            Mainmenu.SetActive(false);
            currentMenu = 1;
        }
    }
    public void MenuAutoChangerByClick()
    {
        if (currentMenu == 0)
        {
            SelectMenu(1);
        }
        else
        {
            SelectMenu(0);
        }
    }
}
