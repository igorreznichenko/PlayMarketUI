using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrossScrollRectangle : ScrollRect
{
   
    public ScrollRect MainScrollRect;
    bool changeOnParent = false;
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x))
            changeOnParent = true;
        if (changeOnParent)
            MainScrollRect.OnBeginDrag(eventData);
        else
            base.OnBeginDrag(eventData);
            
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (changeOnParent)
            MainScrollRect.OnDrag(eventData);
        else
            base.OnDrag(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (changeOnParent)
        {
            MainScrollRect.OnEndDrag(eventData);
            changeOnParent = false;
        }
        else
            base.OnEndDrag(eventData);
    }
}
[CustomEditor(typeof(CrossScrollRectangle))]
class CrossScrollRectngleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CrossScrollRectangle scrollRectangle = (CrossScrollRectangle)target;
        scrollRectangle.MainScrollRect = (ScrollRect)EditorGUILayout.ObjectField("Main scroll rectangle",scrollRectangle.MainScrollRect, typeof(ScrollRect), true);
        base.OnInspectorGUI();
    }
}