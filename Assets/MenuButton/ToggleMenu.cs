using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
[ExecuteInEditMode]
public class ToggleMenu : MonoBehaviour
{
[DropDownAttribute]
public int Selected = 0;

private void Awake() {
GetComponent<Toggle>().onValueChanged.AddListener((value)=> ShowPanel(value));

}
public void ShowPanel(bool isOn){
    var options = UIManager.Instance.UInames();
    if(isOn){
    UIManager.Instance.ShowPanelByName(options[Selected]);
    }else{
    UIManager.Instance.HidePanelByName(options[Selected]);
    }
}

}
