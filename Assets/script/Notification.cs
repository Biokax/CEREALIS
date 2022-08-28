using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    public TMP_Text notificationText;

    public void clickButton()
    {
        StartCoroutine(sendNotification("Enregistrement terminé", 3));
    }

    IEnumerator sendNotification(string text, int time)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
}
