using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class FrameWork : MonoBehaviour
{
    public EnvChanger EnvController;
    public GameConfigCtrl GamePopUp;
    public TheaterConfigCtrl TheaterPopUp;

    private string UserLocation = "0";
    Thread mThread;
    int connectionPort = 25001;
    TcpListener listener;
    TcpClient client;

    bool running;

    private void Update()
    {
        UserLocation = EnvController.location;
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    void GetInfo()
    {
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        Debug.Log("Waiting for framework connection...");

        client = listener.AcceptTcpClient();
        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---Getting Ping msg in Bytes from Python----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); 
        string Alert = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if(string.Compare(Alert, "-1") == 0){
            print("Closing connection with python.");
            running = false;
            return;
        }


        //---finding and Sending the location of user----
        byte[] location = Encoding.ASCII.GetBytes(UserLocation);
        nwStream.Write(location, 0, location.Length); 


        //---Receiving config from Python----
        int Config = nwStream.Read(buffer, 0, client.ReceiveBufferSize); 
        string configRecieved = Encoding.UTF8.GetString(buffer, 0, Config);

        string[] datarecieved = configRecieved.Split("$");
        
        //---Activating the respective config----
        if(string.Compare(UserLocation, "0") == 0){
            GamePopUp.config = System.Int16.Parse(datarecieved[0]);
            GamePopUp.AlertTitle = datarecieved[1];
            GamePopUp.AlertMessage = datarecieved[2];
        }else{
            TheaterPopUp.config = System.Int16.Parse(datarecieved[0]);
            TheaterPopUp.AlertTitle = datarecieved[1];
            TheaterPopUp.AlertMessage = datarecieved[2];
            
        }
    }
}