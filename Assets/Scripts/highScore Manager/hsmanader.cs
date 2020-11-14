using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hsmanader : MonoBehaviour
{
    public Text list;
    public Text listTittle;
    public Button showList;
    public LogPlugin Logger;

    private void Start()
    {
        showList.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
        listTittle.gameObject.SetActive(true);
        listTittle.text = "Show list";
    }

    public void ShowList()
    {
        listTittle.text = "Hide list";
        list.gameObject.SetActive(true);
        UpdateList();
    }

    public void HideList()
    {
        listTittle.text = "Show list";
        list.gameObject.SetActive(false);
    }

    private void UpdateList()
    {
        //list.text = Logger.getLog();
    }
}
