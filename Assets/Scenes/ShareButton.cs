using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShareButton : MonoBehaviour
{
    void OnMouseDown()
    {

        //Vuforia.Instance.Pause();
        ScreenCapture.CaptureScreenshot("SomeLevel");
    }
}
