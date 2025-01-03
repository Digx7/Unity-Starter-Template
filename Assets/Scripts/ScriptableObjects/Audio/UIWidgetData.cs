using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewUIWidgetData", menuName = "ScriptableObjects/UI/WidgetData", order = 1)]
public class UIWidgetData : ScriptableObject
{
    public GameObject widgetPrefab;

    private GameObject instantiatedWidget;

    public GameObject GetInstantiatedWidget()
    {
        return instantiatedWidget;
    }

    public void SpawnWidget(Transform parent = null)
    {
        instantiatedWidget = Instantiate(widgetPrefab);

        if(parent != null)
        {
            instantiatedWidget.transform.SetParent(parent);
        }

        UIWidget uIWidget = instantiatedWidget.GetComponent<UIWidget>();
        uIWidget.Setup();
    }

    public void DespawnWidget()
    {
        UIWidget uIWidget = instantiatedWidget.GetComponent<UIWidget>();
        uIWidget.Teardown();
    }
}