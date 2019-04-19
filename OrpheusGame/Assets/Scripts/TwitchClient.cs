using System.Collections;
using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;

public class TwitchClient : MonoBehaviour
{

    public Client client;
    private string channel_name = "Bob_Jone";
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;

        //set up bot and tell it which channel to join
        ConnectionCredentials credentials = new ConnectionCredentials("persephone_bot", Secrets.bot_access_token);
        client = new Client();
        client.Initialize(credentials, channel_name);

        //get bot to subscribe to events to listen to here later
        client.OnMessageReceived += MessageTestFunction;
        client.OnConnected += Client_OnConnected;


        //connect bot
        client.Connect();
    }

    private void Client_OnConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
    {
        client.SendMessage(client.JoinedChannels[0], "Welcome to the underworld. Try typing 'faster' or 'slower' to alter the tempo of the game.");
        Debug.Log("conncted to " + client.JoinedChannels[0]);
    }

    private void MessageTestFunction(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {

        Debug.Log(sender);

        if (e.ChatMessage.Message == "faster" || e.ChatMessage.Message == "!faster")
        {
            Globals.tempo += 5;
            client.SendMessage(client.JoinedChannels[0], e.ChatMessage.Username + " sent 'faster' command. Current tempo is " + Globals.tempo);
        }
        if (e.ChatMessage.Message == "slower" || e.ChatMessage.Message == "!slower")
        {
            Globals.tempo -= 5;
            client.SendMessage(client.JoinedChannels[0], e.ChatMessage.Username + " sent 'slower' command. Current tempo is " + Globals.tempo);
        }
        if (e.ChatMessage.Message == "help" || e.ChatMessage.Message == "!help")
        {
            client.SendMessage(client.JoinedChannels[0], "Hey, " + e.ChatMessage.Username + ". I'm persephone bot. Try typing 'faster' or 'slower' in the chat.");
        }
    }

    void ChordPickup()
    {
        client.SendMessage(client.JoinedChannels[0], "Placeholder message for chord pickup!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            client.SendMessage(client.JoinedChannels[0], "someone pressed 'B'");
        }
    }
}
