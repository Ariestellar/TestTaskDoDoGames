using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AspectRatioInstaller : MonoBehaviour
{
    [SerializeField] private CanvasScaler _canvasScaler;
    [SerializeField] private Camera _camera;    

    private void Start()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        
        if (windowAspect > 1)
        {
            _camera.orthographicSize /= 2;

            if (Screen.height <= 480)
            {
                _canvasScaler.scaleFactor = 1;
            }
            else if (Screen.height <= 780)
            {
                _canvasScaler.scaleFactor = 2f;
            }
            else if (Screen.height <= 1080)
            {
                _canvasScaler.scaleFactor = 3f;
            }
        }
        else
        {
            if (Screen.width <= 480)
            {
                _canvasScaler.scaleFactor = 1;
            }
            else if (Screen.width <= 780)
            {
                _canvasScaler.scaleFactor = 1.8f;
            }
            else if (Screen.width <= 1080)
            {
                _canvasScaler.scaleFactor = 2.5f;
            }
        }       
    }
}