using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Instantation : MonoBehaviour
{
    public GameObject spherePoint;

    public float radius = 5f;
    private int zaxis = 10;
    private int xaxis = 10;
    private int t = 0;
    private int p = 0;

    public GameObject receiveObj;
    private UDPReceive receive;
    private byte[] bringData;

    Color[] colors = { new Color32(255, 0, 0, 128), new Color32(255, 54, 0, 128), new Color32(255, 107, 0, 128),
            new Color32(255, 161, 0, 128), new Color32(255, 214, 0, 128), new Color32(242, 255, 0, 128),
            new Color32(188, 255, 0, 128), new Color32(134, 255, 0, 128), new Color32(81, 255, 0, 128),
            new Color32(27, 255, 0, 128), new Color32(0, 255, 27, 128), new Color32(43, 255, 81, 128),
            new Color32(0, 255, 134, 128), new Color32(0, 255, 188, 128), new Color32(0, 255, 242, 128),
            new Color32(0, 215, 255, 128), new Color32(0, 161, 255, 128), new Color32(0, 107, 255, 128),
            new Color32(0, 54, 255, 128), new Color32(0, 0, 255, 128)};




    // Start is called before the first frame update
    void Start()
    {
        // t for theta, p for phi
        //GameObject data = GameObject.Find("")
        Color red = new Color(255, 0, 0);
        Renderer pointRenderer;
        int j = 0;

        receiveObj = GameObject.Find("Receive");
        //sphere = GameObject.Find("point" + t + "-" + p);
        // change color of points according to the byte value
        //sphere.GetComponent<Renderer>().material.color = colors[-byteValue];

        //grid = getCSVGrid("./tdesign_120_spherical.csv");

        using (var reader = new StreamReader("C:\\Users\\soundlab\\Desktop\\AR\\zed_ar\\Assets\\Scripts\\tdesign_120_spherical.csv"))
        {
            //List<string> listA = new List<string>();
            //List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                //listA.Add(values[0]);
                //print(values[0]);
                //listB.Add(values[1]);
                //print(values[1]);

                float theta = float.Parse(values[0]);
                float phi = float.Parse(values[1]);

                float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
                float y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
                float z = radius * Mathf.Cos(phi);

                Vector3 pos = new Vector3(x, y + (float)0.5, z);

                GameObject Point = Instantiate(spherePoint, pos, Quaternion.identity);
                Point.name = "point" + j;
                j++;
            }
        }

        // uniform distribution

        /*
        for (int t = 0; t < zaxis; t++)
        {

            float theta = t * Mathf.PI / (zaxis - 1);
            //should i subtract 1?
            //should i subtract 1?
            for (int p = 0; p < xaxis; p++)
            {

                float phi = p * Mathf.PI * 2 / (xaxis - 1);

                float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
                float y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
                float z = radius * Mathf.Cos(phi);

                Vector3 pos = new Vector3(x, y + (float)0.5, z);

                GameObject Point = Instantiate(spherePoint, pos, Quaternion.identity);
                Point.name = "point" + t + "-" + p;
            }
        }
        */

    }


    // Update is called once per frame
    void Update()
    {

        receive = receiveObj.GetComponent<UDPReceive>();
        bringData = receive.AccessData();

        //print("Empty");
        //Debug.log("Hello");
        //print(bringData[0]); // what I want to print

        // uniform distribution
        /*
        t = 0;

        int j = 0;
        for (int t = 0; t < zaxis; t++)
        {
            for (int p = 0; p < xaxis; p++)
            {
                GameObject Point = GameObject.Find("point" + t + "-" + p);
                //if (bringData[j] == 0)
                //{
                //    print("hi bbt ");
                //}
                print(bringData[j]);
                bringData = receive.AccessData();
                Point.GetComponent<Renderer>().material.color = colors[bringData[j]];
                // red blue - inverse
                //pointRenderer = Point.transform.GetComponent<Renderer>();

                //pointRenderer.material.color = Color.red;
                j++;
            }
        }*/

        // t-design
        for (int i = 0; i < 120; i++)
        {
            GameObject Point = GameObject.Find("point" + i);

            //print(bringData[j]);
            bringData = receive.AccessData();
            Point.GetComponent<Renderer>().material.color = colors[bringData[i]];
        }


    }

}
