using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[ExecuteInEditMode]
public class ButtonMenu : MonoBehaviour
{
[DropDownAttribute]
public int Selected = 0;


private void Start() {
GetComponent<Button>().onClick.AddListener(()=>ShowPanel());

}

public void ShowPanel(){
    var options = UIManager.Instance.UInames();
    UIManager.Instance.ShowPanelByName(options[Selected]);

}

}
