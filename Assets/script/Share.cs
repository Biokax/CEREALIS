using UnityEngine;
using UnityEngine.UI;

// Generate a screenshot and save to disk with the name SomeLevel.png.

public class Share : MonoBehaviour
{
    public Button btnClick;
    public bool isClicked = false;

    public void Start()
    {
        btnClick.onClick.AddListener(ClickedButton);
    }

    public void ClickedButton()
    {
        isClicked = true;
    }

    public void Update()
    {
        if (isClicked == true)
        {
            /*-------------------------CAPTURE-------------------------*/
            string folderPath = "Assets/Screenshots/";

            if (!System.IO.Directory.Exists(folderPath)) // if this path does not exist yet
                System.IO.Directory.CreateDirectory(folderPath);  // it will get created

            var screenshotName = "Screenshot_" +
                                System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                ".png";
            ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName), 2);
            Debug.Log(folderPath + screenshotName);

            /*-------------------------TWITTER-------------------------*/
            //string nameParameter = "My new Drawing";
            Application.OpenURL("https://twitter.com/intent/tweet?text=My+new+drawing+!!&hashtags=CEREALIS,Drawing");
            isClicked = false;
        }
    }
}