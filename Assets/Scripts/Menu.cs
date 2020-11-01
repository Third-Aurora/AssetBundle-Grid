using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public API api;
    public ContentController contentController;

    public GameObject Scrollmenu;
    public GameObject MenuButton;

    public GameObject ButtonPrefab;
    public Transform ButtonParent;

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

    void DestroyAllButtons() {
        foreach (Transform child in ButtonParent) {
            Destroy(child.gameObject);
        }
    }

    void LoadMenuItems() {
        DestroyAllButtons();
        api.GetItemList(OnMenuItemsLoaded);
    }

    void OnMenuItemsLoaded(List<string> itemList) {
        foreach (string item in itemList) {
            //load button prefab into scene
            GameObject buttonObject = Instantiate(ButtonPrefab, ButtonParent);
            //set button text
            ButtonBehavior buttonBehavior = buttonObject.GetComponent<ButtonBehavior>();
            buttonBehavior.Init(item);
            //set button action
            Button uiButton = buttonObject.GetComponent<Button>();
            uiButton.onClick.AddListener(() => {
                ActivateMenu(false);
                contentController.LoadContent(item);
            });
        }
    }
}
