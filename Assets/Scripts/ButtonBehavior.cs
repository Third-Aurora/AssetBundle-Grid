using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {

    public Text buttonText;

    public void Init(string name) {
        buttonText.text = name;
        gameObject.name = name;
    }
}
