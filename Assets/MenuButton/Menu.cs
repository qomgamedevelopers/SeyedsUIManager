using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Menu : MonoBehaviour
{
[DropDownAttribute]
public int Selected = 0;

public void ShowPanel(){
    var options = UIManager.Instance.UInames();
    UIManager.Instance.ShowPanelByName(options[Selected]);
}

public void HidePanel(){
    var options = UIManager.Instance.UInames();
    UIManager.Instance.HidePanelByName(options[Selected]);
}
}
