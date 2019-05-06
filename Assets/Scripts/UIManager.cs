using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

public class UIManager : Singleton<UIManager>
{



    [ReorderableList]
    public List<OpenPanel> Panels;

    [System.Serializable]
    public class OpenPanel
    {
        public string Name;
        public List<GameObject> Pages;
        public AudioClip Sound;
        public string AnimationName;
        public Animator Animator;
        public UnityEvent OnOpen;

        public ClosePanel Close;

    }
    public List<string> UInames()
    {
        var st = new List<string>();
        foreach (var panel in UIManager.Instance.Panels)
        {
            st.Add(panel.Name);
        }
        return st;
    }

    [System.Serializable]
    public class ClosePanel
    {
        public AudioClip Sound;
        public List<GameObject> Pages;
        public UnityEvent OnClose;
    }



    public void ShowPanelByName(string _name)
    {
        ShowPanel(Panels.Where((x) => x.Name == _name).FirstOrDefault());
    }
    public void HidePanelByName(string _name)
    {
        HidePanel(Panels.Where((x) => x.Name == _name).FirstOrDefault());
    }

    /// <summary>
    /// نمایش پنل
    /// </summary>
    /// <param name="Panel"></param>
    public void ShowPanel(OpenPanel Panel)
    {
        foreach (var page in Panel.Pages)
        {
            page.SetActive(true);
        }
        if (Panel.Animator != null)
        {
            Panel.Animator.SetBool(Panel.AnimationName, true);
            // TODO Add Sound
            Wait(AnimationTime.Time(Panel.Animator, Panel.AnimationName),Panel.OnOpen);
        }
        else
        {
            Panel.OnOpen.Invoke();
        }
    }

    /// <summary>
    /// بستن تمام پنل ها
    /// </summary>
    public void HideAllPanels()
    {
        foreach (var panel in Panels)
        {
            HidePanel(panel);
        }
    }

    public void Wait(float second, Action action)
    {
        StartCoroutine(DoWait(second, action));
    }
    public IEnumerator DoWait(float second, Action action)
    {
        yield return new WaitForSeconds(second);
        action();
    }

    public void Wait(float second, UnityEvent afterWait)
    {
        StartCoroutine(DoWait(second, afterWait));
    }
    public IEnumerator DoWait(float second, UnityEvent afterWait)
    {
        yield return new WaitForSeconds(second);
        afterWait.Invoke();
    }

    public void HidePanel(OpenPanel Panel)
    {


        if (Panel.Animator != null)
        {
            Panel.Animator.SetBool(Panel.AnimationName, false);
            // Wait(AnimationTime.Time(Panel.Animator, Panel.AnimationName), () =>
            // {
            //     foreach (var page in Panel.Close.Pages)
            //     {
            //         page.SetActive(false);
            //     }
            // });
            Wait(AnimationTime.Time(Panel.Animator, Panel.AnimationName), Panel.Close.OnClose);
            }
        else
        {
            foreach (var page in Panel.Close.Pages)
            {
                page.SetActive(false);
            }
            Panel.Close.OnClose.Invoke();
        }

        // TODO Add Sound
    }


}
