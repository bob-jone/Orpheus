using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Api.Models.Undocumented.Chatters;

public class TwitchAPI : MonoBehaviour
{

    public Api api;

    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        api = new Api();
        api.Settings.AccessToken = Secrets.bot_access_token;
        api.Settings.ClientId = Secrets.client_id;
    }

    private void GetChattersListCallback(List<ChatterFormatted> listOfChatters)
    {
        Debug.Log("List of " + listOfChatters.Count + " Viewers ");
        foreach (var chatterObject in listOfChatters)
        {
            Debug.Log(chatterObject.Username);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
             api.Invoke(api.Undocumented.GetChattersAsync("bob_jone"), GetChattersListCallback);
        }
    }
}
