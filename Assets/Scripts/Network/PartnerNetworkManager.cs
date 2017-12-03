using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Barebones.MasterServer;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PartnerNetworkManager : NetworkManager {

    public UnetGameRoom GameRoom;

    void Awake()
    {
        if (GameRoom == null)
        {
            Debug.LogError("Game Room property is not set on NetworkManager");
            return;
        }

        // Subscribe to events
        GameRoom.PlayerJoined += OnPlayerJoined;
        GameRoom.PlayerLeft += OnPlayerLeft;
    }

    /// <summary>
    /// Regular Unet method, which get's called when client disconnects from game server
    /// </summary>
    /// <param name="conn"></param>
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);

        // Don't forget to notify the room that a player disconnected
        GameRoom.ClientDisconnected(conn);
    }

    /// <summary>
    /// Invoked, when client provides a successful access token and enters the room
    /// </summary>
    /// <param name="player"></param>
    private void OnPlayerJoined(UnetMsfPlayer player)
    {
        // -----------------------------------
        // IF all you want to do is spawn a player:
        //
        // MiniNetworkManager.SpawnPlayer(player.Connection, player.Username, "carrot");
        // return;

        // -----------------------------------
        // If you want to use player profile

        // Create an "empty" (default) player profile
        var defaultProfile = PlayerProfile.CreateProfileInServer(player.Username);

        // Get coins property from profile
        var coinsProperty = defaultProfile.GetProperty<ObservableInt>(PlayerProfile.CoinsKey);
        var completedChambers = defaultProfile.GetProperty<ObservableInt>(PlayerProfile.CompletedChambersKey);
        // Fill the profile with values from master server
        Msf.Server.Profiles.FillProfileValues(defaultProfile, (successful, error) =>
        {
            if (!successful)
                Logs.Error("Failed to retrieve profile values: " + error);

            // We can still allow players to play with default profile ^_^

            // Let's spawn the player character
            //var playerObject = SpawnPlayer(player.Connection, player.Username, "carrot");
            var playerObject = Instantiate(this.playerPrefab, GetStartPosition());
            // Set coins value from profile
            //playerObject.Coins = coinsProperty.Value;

            //playerObject.CoinsChanged += () =>
            //{
                // Every time player coins change, update the profile with new value
            //    coinsProperty.Set(playerObject.Coins);
            //};
        });
    }

    private void OnPlayerLeft(UnetMsfPlayer player)
    {

    }

}
