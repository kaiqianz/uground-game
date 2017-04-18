using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine.Networking;
class GameManager
{
    private GameManager()
    {
        ;
    }

    private static GameManager gamemanager;
    public static GameManager Instance
    {
        get {
            if (gamemanager == null)
                gamemanager = new GameManager();
            return gamemanager; }
    }

    public NetworkClient myclient;
    public int ID;
    public string ServerIP = "localhost";

}

