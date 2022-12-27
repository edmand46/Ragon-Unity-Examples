using System;
using System.Collections.Generic;
using Ragon.Client;
using Ragon.Examples.Tanks;
using Tanks.Scripts.Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tanks.Scripts
{
  public class Network : MonoBehaviour, IRagonListener
  {
    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
      var entityManager = GetComponent<RagonEntityManager>();

      RagonNetwork.Event.Register<FireEvent>();
       
      RagonNetwork.AddListener(this);
      RagonNetwork.SetManager(entityManager);
      RagonNetwork.Connect();
    }

    public void OnAuthorized(string playerId, string playerName)
    {
      Debug.Log("Authorized!");
      RagonNetwork.Session.CreateOrJoin("Example", 1, 2);
    }

    public void OnJoined()
    {
      var randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)];
      RagonNetwork.Room.CreateEntity(_tankPrefab, new TankPayload() { Position = randomPoint.position });
    }

    public void OnFailed(string message)
    {
    }

    public void OnLeaved()
    {
    }

    public void OnConnected()
    {
      Debug.Log("Connected!");
      var randomName = $"Player {Random.Range(100, 999)}";
      RagonNetwork.Session.AuthorizeWithKey("defaultkey", randomName, Array.Empty<byte>());
    }

    public void OnDisconnected()
    {
    }

    public void OnPlayerJoined(RagonPlayer player)
    {
    }

    public void OnPlayerLeft(RagonPlayer player)
    {
    }

    public void OnOwnershipChanged(RagonPlayer player)
    {
    }

    public void OnLevel(string sceneName)
    {
      Debug.Log("Level " + sceneName);
      RagonNetwork.Room.SceneLoaded();
    }
  }
}