﻿using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour
{
    private AbstractObjects [] m_roomsObjects;

    private Player [] m_players;
    public Player m_prefabPlayer;

    private Light [] m_roomLights;
    private Light [] m_windowsLights;


    private void Awake()
    {
        loadScene();
        initPlayers();
    }

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Hello World!");
	}


    void loadScene()
    {
        // Get all elements from the scene
        m_roomsObjects = GameObject.FindObjectsOfType<AbstractObjects>();

        initLights();
    }

    void initLights()
    {
        // Room lights
        GameObject[] roomLightsGO = GameObject.FindGameObjectsWithTag("RoomLight");
        m_roomLights = new Light[roomLightsGO.Length];

        for(int i = 0; i < roomLightsGO.Length; i++)
            m_roomLights.SetValue(roomLightsGO[i].GetComponent<Light>(),i);


        // Windows lights
        GameObject[] windowsLightsGO = GameObject.FindGameObjectsWithTag("WindowLight");
        m_windowsLights = new Light[windowsLightsGO.Length];

        for(int i = 0; i < windowsLightsGO.Length; i++)
            m_windowsLights.SetValue(windowsLightsGO[i].GetComponent<Light>(),i);
    }

    void initPlayers()
    {
        int gamepadNb = Input.GetJoystickNames().Length;
        m_players = new Player[gamepadNb];

        for(int i=0; i<gamepadNb; i++)
        {
            Player player = m_players[i];
            player = Instantiate(m_prefabPlayer) as Player;//"Player" + i.ToString()).AddComponent<Player>();

            Pad pad = new Pad();
            pad.joystickNumber = i+1;
            player.m_controller = pad;
        }
    }    
}