using System;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Graphs
{
    public class GraphContainer : MonoBehaviour
    {
        [SerializeField] private Sprite _circleSprite;
        [SerializeField] private RectTransform _rectTransform;

        private List<int> _graphs = new List<int>() { 83, 76, 66, 40, 20, 35, 66, 80, 83, 83, 85, 25 };

        private void Awake()
        {
            ShowGraph(_graphs);
        }

        private void ShowGraph(List<int> values)
        {
            float graphHeight = _rectTransform.sizeDelta.y;
            float maxY = 100f;
            float stepX = 30f;
            RectTransform lastRectTransform = null;

            for (int i = 0; i < values.Count; i++)
            {
                float xPos = 8.5f + stepX * i;
                float yPos = (values[i] / maxY) * graphHeight;
                GameObject circle = CreateCircle(new Vector2(xPos, yPos));
                
                if (lastRectTransform != null)
                {
                    CreateDotConnection(lastRectTransform, circle.GetComponent<RectTransform>());
                }

                lastRectTransform = circle.GetComponent<RectTransform>();
            }
        }

        private GameObject CreateCircle(Vector2 position)
        {
            GameObject circle = new GameObject("circle", typeof(Image));
            circle.transform.SetParent(this.transform, false);
            circle.GetComponent<Image>().sprite = _circleSprite;
            RectTransform rectOfCircle = circle.GetComponent<RectTransform>();
            rectOfCircle.anchoredPosition = position;
            rectOfCircle.sizeDelta = new Vector2(5, 5);
            rectOfCircle.anchorMax = new Vector2(0, 0);
            rectOfCircle.anchorMin = new Vector2(0, 0);
            return circle;
        }

        private void CreateDotConnection(RectTransform firstPoint, RectTransform secondPoint)
        {
            GameObject connection = new GameObject("connection", typeof(Image));
            RectTransform rectTransform = connection.GetComponent<RectTransform>();
            connection.transform.SetParent(this.transform, false);

            Vector2 direction = (secondPoint.anchoredPosition - firstPoint.anchoredPosition).normalized;
            float distance = Vector2.Distance(firstPoint.anchoredPosition, secondPoint.anchoredPosition);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchoredPosition = firstPoint.anchoredPosition + direction * distance * 0.5f;
            Debug.Log("direction " + direction);
            Debug.Log("distance " + distance);
            Debug.Log(direction * distance * 0.5f);
            rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVector(direction));
        }
    }
}
