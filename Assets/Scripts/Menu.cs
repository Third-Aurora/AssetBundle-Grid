using UnityEngine;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    public API api;

    public GameObject Scrollmenu;
    public GameObject MenuButton;

    public GameObject ButtonPrefab;
    public GameObject ButtonParent;

    void Start() {
        ActivateMenu(false);
    }

    public void ActivateMenu(bool active) {

        if (active) {
            LoadMenuItems();
        }

        MenuButton.SetActive(!active);
        Scrollmenu.SetActive(active);
    }

    void LoadMenuItems() {
        api.GetItemList(OnMenuItemsLoaded);
    }

    void OnMenuItemsLoaded(List<string> itemList) {

    }
}
