using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayMarketUI.SafeArea
{
    public class SafeArea : MonoBehaviour
    {
        
        RectTransform _rectTransform;
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
           
        
        private void SetupSafeArea()
        {
            Rect saveArea = Screen.safeArea;
            float xMin = saveArea.xMin;
            float yMin = saveArea.yMin;

            float xMax = saveArea.xMax;
            float yMax = saveArea.yMax;

            float anchorMinX = xMin / Screen.width;
            float anchorMinY = yMin / Screen.height;

            float anchorMaxX = xMax / Screen.width;
            float anchorMaxY = yMax / Screen.height;
            _rectTransform.anchorMin = new Vector2(anchorMinX, anchorMinY);
            _rectTransform.anchorMax = new Vector2(anchorMaxX, anchorMaxY);
        }
        private void Update()
        {
            SetupSafeArea();
        }

    }
}