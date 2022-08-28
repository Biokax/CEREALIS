using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using RestSharp;
using TMPro;

public class registrateProspect : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField userMail;

    public void auth()
    {
        //string name = "test";
        //string mail = "test.test@gmail.com";
        string name = userName.text;
        string mail = userMail.text;

        Debug.Log("nom/mail : " + name + " / " + mail);

        StartCoroutine(CallApi(name,mail));
    }

    IEnumerator CallApi(string name, string mail)
    {
        var client = new RestClient("https://api.hubapi.com/crm/v3/objects/contacts");
        var request = new RestRequest();
        request.Method = Method.Post;
        request.AddHeader("accept", "application/json");
        request.AddHeader("content-type", "application/json");
        // this is a test api for a school project we don't care about the bearer token been leaked
        request.AddHeader("authorization", "Bearer pat-eu1-288a140d-3998-4efd-826b-83b5cc0a69fe");
        request.AddParameter("application/json", "{\"properties\":{\"email\":\"" + mail+ "\",\"lastname\":\"" + name+ "\"}}", ParameterType.RequestBody);
        RestResponse response = client.Execute(request);

        Debug.Log("Status Code: " + response.StatusCode);
        Debug.Log("Content: " + response.Content);

        string status = response.StatusCode.ToString();

        yield return status;
    }
}

//https://api.scrapestack.com/scrape?access_key=c9b0848b308efec47d76f40c3d7b297e&url=