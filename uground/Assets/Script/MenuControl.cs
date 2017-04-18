using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class MenuControl : MonoBehaviour {

	public void StartLocalGame()
	{

        //    StartCoroutine(checkRoom());
        //}

        //   IEnumerator checkRoom()
        //   {
        //       int roomid = 0;
        //       int.TryParse(hostNameInput.text,out roomid);

        //       if(roomid != 0)
        //       {
        //           string ip = LocalIPAddress();
        //           string url = "59.111.96.26/host.php?ip="+ ip +"&roomid="+ roomid;
        //           Debug.Log(url);
        //           WWW www = new WWW(url);
        //           yield return www;
        //           Debug.Log(www.text);
        //       }
        //       yield return 0;
        GameManager.Instance.myclient = NetworkManager.singleton.StartHost();
        GameManager.Instance.ID = 1;
    }


    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                if (ip.ToString().StartsWith("192.") || ip.ToString().StartsWith("10.") || ip.ToString().StartsWith("127."))
                    return ip.ToString();

                localIP = ip.ToString();
            }
        }

        return localIP;
    }

    public void JoinLocalGame()
	{
		if (hostNameInput.text != "Hostname")
		{
            if (LocalIPAddress() == hostNameInput.text)
                hostNameInput.text = "127.0.0.1";
            GameManager.Instance.ServerIP = hostNameInput.text;

            NetworkManager.singleton.networkAddress = hostNameInput.text;
		}
        GameManager.Instance.myclient = NetworkManager.singleton.StartClient();
        GameManager.Instance.ID = 2;
    }
	
	public void StartMatchMaker()
	{
		NetworkManager.singleton.StartMatchMaker();
	}
	
	public UnityEngine.UI.Text hostNameInput;


	void Start()
	{
        hostNameInput.GetComponent<InputField>().text = GameManager.Instance.ServerIP;
    }
	
}
