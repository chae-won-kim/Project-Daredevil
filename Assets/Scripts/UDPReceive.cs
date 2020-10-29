using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{

    // receiving Thread
    Thread receiveThread;

    // udpclient object
    UdpClient client;

    // public
    public string IP = "143.248.158.30";
    public int port; // define > init

    // infos
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; // clean up this from time to time!

    private static byte[] data = new byte[121];


    // start from shell
    private static void Main()
    {
        UDPReceive receiveObj = new UDPReceive();
        receiveObj.init();

        for (int i = 0; i < 101; i++)
        {
            data[i] = 0x01;
        }

        string text = "";
        do
        {
            text = Console.ReadLine();
        }
        while (!text.Equals("exit"));
    }
    // start from unity3d
    public void Start()
    {

        init();
    }

    // OnGUI
    void OnGUI()
    {
        Rect rectObj = new Rect(40, 10, 200, 400);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj, "# UDPReceive\n143.248.158.30 " + port + " #\n"
                    + "shell> nc -u 143.248.158.30 : " + port + " \n"
                    + "\nLast Packet: \n" + lastReceivedUDPPacket
                    + "\n\nAll Messages: \n" + allReceivedUDPPackets
                , style);
    }

  

    public byte[] AccessData()
    {
        return data;
    }

    // init
    private void init()
    {
        print("UDPSend.init()");

        // define port
        port = 8051;
        //port = 8000;

        // status
        print("Sending to 143.248.158.30 : " + port);
        print("Test-Sending to this Port: nc -u 143.248.158.30  " + port + "");



        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    public void ReceiveData()
    {
        int w = 10;
        int h = 10;
        int t = 0;
        int p = 0;

        GameObject sphere;
        Color red = new Color(255, 0, 0);
        // 20 color range
        Color[] colors = { new Color32(255, 0, 0, 128), new Color32(255, 54, 0, 128), new Color32(255, 107, 0, 128),
            new Color32(255, 161, 0, 128), new Color32(255, 214, 0, 128), new Color32(242, 255, 0, 128), 
            new Color32(188, 255, 0, 128), new Color32(134, 255, 0, 128), new Color32(81, 255, 0, 128),
            new Color32(27, 255, 0, 128), new Color32(0, 255, 27, 128), new Color32(43, 255, 81, 128),
            new Color32(0, 255, 134, 128), new Color32(0, 255, 188, 128), new Color32(0, 255, 242, 128),
            new Color32(0, 215, 255, 128), new Color32(0, 161, 255, 128), new Color32(0, 107, 255, 128), 
            new Color32(0, 54, 255, 128), new Color32(0, 0, 255, 128)};

        client = new UdpClient(port);
        while (true)
        {

            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                data = client.Receive(ref anyIP);

                

                string text = Encoding.UTF8.GetString(data);
                string text2 = Encoding.ASCII.GetString(data, 0, data.Length);
                int n = 0;

                print(">> " + text);

                /*
                foreach (sbyte byteValue in data)
                {
                    if (t < w)
                    {
                        if (p < h)
                        {
                            print("point" + t + "-" + p + ": " + byteValue.ToString());
                            //sphere = GameObject.Find("point" + t + "-" + p);
                            // change color of points according to the byte value
                            //sphere.GetComponent<Renderer>().material.color = colors[-byteValue];

                            p++;
                
                        } else
                        {
                            print("point" + t + "-" + p + ": " + byteValue.ToString());
                            //sphere = GameObject.Find("point" + t + "-" + p);
                            // change color of points according to the byte value
                            //sphere.GetComponent<Renderer>().material.color = colors[-byteValue];
                            p = 0;
                            t++;
                        }
                        
                    } 
                    
                }*/

                


                //n = BitConverter.ToInt32(data, 0);
                //print(">> " + n);


                // latest UDPpacket
                //lastReceivedUDPPacket = n.ToString();

                // ....
                //allReceivedUDPPackets = allReceivedUDPPackets + n.ToString();

            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }


    // getLatestUDPPacket
    // cleans up the rest
    public string getLatestUDPPacket()
    {
        allReceivedUDPPackets = "";
        return lastReceivedUDPPacket;
    }
}
