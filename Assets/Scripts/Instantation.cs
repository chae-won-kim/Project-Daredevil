using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;




public class Instantation : MonoBehaviour
{
    public GameObject spherePoint;
    public GameObject sphere;


    public float radius = 0.3f;
    private int zaxis = 36 ;
    private int xaxis = 72;
    private int t = 0;
    private int p = 0;

    public GameObject receiveObj;
    private UDPReceive receive;
    public GameObject ZEDTracker;
    private byte[] bringData = new byte[600];

    Color[] colors0 = { new Color32(255, 0, 0, 128), new Color32(255, 54, 0, 128), new Color32(255, 107, 0, 128),
            new Color32(255, 161, 0, 128), new Color32(255, 214, 0, 128), new Color32(242, 255, 0, 128),
            new Color32(188, 255, 0, 128), new Color32(134, 255, 0, 128), new Color32(81, 255, 0, 128),
            new Color32(27, 255, 0, 128), new Color32(0, 255, 27, 128), new Color32(43, 255, 81, 128),
            new Color32(0, 255, 134, 128), new Color32(0, 255, 188, 128), new Color32(0, 255, 242, 128),
            new Color32(0, 215, 255, 128), new Color32(0, 161, 255, 128), new Color32(0, 107, 255, 128),
            new Color32(0, 54, 255, 128), new Color32(0, 0, 255, 128)};

    private MeshFilter viewedModelFilter;
    private Mesh sphereMesh;
    public Vector3[] vertices;
    public Color[] colors2;



    // Start is called before the first frame update
    void Start()
    {
        // t for theta, p for phi
        //GameObject data = GameObject.Find("")
        Renderer pointRenderer;
        int j = 0;

        receiveObj = GameObject.Find("Receive");
        ZEDTracker = GameObject.Find("ZEDTracker");


        sphere = GameObject.Find("Sphere");


        for (int i = 0; i < 20; i++)
        {
            if (i < 6)
            {
                colors0[i].a = .8f;

            }
            else if (i < 13)
            {
                colors0[i].a = .5f;
            } else
            {
                colors0[i].a = .3f;
            }
        }


        viewedModelFilter = (MeshFilter)sphere.GetComponent("MeshFilter");
        sphereMesh = viewedModelFilter.mesh;

        sphereMesh.triangles = sphereMesh.triangles.Reverse().ToArray();

        vertices = sphereMesh.vertices;

        // create new colors array where the colors will be created.
        //print("vertices.Length: " + vertices.Length);
        colors2 = new Color[vertices.Length];

        //string filePath = "C:\\Users\\soundlab\\Desktop\\AR\\zed_ar\\Assets\\Scripts\\spherepoint.csv";

        //StreamWriter writer = new StreamWriter(filePath);

        //writer.WriteLine("data");




        for (int i = 0; i < vertices.Length; i++)
        {
            //if (i < 100)
            //{
            //    colors[i] = Color.green;
            //}
            //else if (i < 200)
            //{
            //    colors[i] = Color.red;
            //}
            //else if (i < 300)
            //{
            //    colors[i] = Color.blue;
            //}
            //else if (i < 400)
            //{
            //    colors[i] = Color.black;
            //}
            //else
            //{
            //    colors[i] = Color.white;
            //}
            //colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);

            colors2[i] = Color.white;
            colors2[i].a = .1f;

            //datosCSV = vertices[i].ToString() + System.Enviroment.NewLine;
            //writer.WriteLine(vertices[i]);

        }

        //// assign the array of colors to the Mesh.
        //sphereMesh.colors = colors2;

        receive = receiveObj.GetComponent<UDPReceive>();


        //writer.Flush();
        //writer.Close();

        // change color of points according to the byte value

        //grid = getCSVGrid("./tdesign_120_spherical.csv");

       /*
        using (var reader = new StreamReader("C:\\Users\\soundlab\\Desktop\\AR\\zed_ar\\Assets\\Scripts\\tdesign_120_spherical.csv"))
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>(); 

            //t design spherical distribution

    
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

                Vector3 pos = new Vector3(x, y, z);

                GameObject Point = Instantiate(spherePoint, transform.position + pos, Quaternion.identity);

                //Point.transform.SetParent(ZEDTracker.transform);
                Point.transform.parent = gameObject.transform;
                Point.name = "point" + j;
                j++;
            }
        }*/
        
        // uniform distribution


        //for (int t = 0; t < zaxis; t++)
        //{

        //    float theta = t * Mathf.PI / (zaxis - 1);
        //    //should i subtract 1?
        //    //should i subtract 1?
        //    for (int p = 0; p < xaxis; p++)
        //    {

        //        float phi = p * Mathf.PI * 2 / (xaxis - 1);

        //        float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
        //        float y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
        //        float z = radius * Mathf.Cos(phi);

        //        Vector3 pos = new Vector3(x, y, z);

        //        GameObject Point = Instantiate(spherePoint, transform.position + pos, Quaternion.identity);
        //        Point.transform.parent = gameObject.transform;

        //        Point.name = "point" + t + "-" + p;
        //    }
        //}

    }


    // Update is called once per frame
    void Update()
    {

        //bringData = receive.AccessData();


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
                //print(bringData[j]);
                //bringData = receive.AccessData();
                //Point.GetComponent<Renderer>().material.color = colors[bringData[j]];
                //Point.GetComponent<Renderer>().material.color = colors[0];
                // red blue - inverse
                //pointRenderer = Point.transform.GetComponent<Renderer>();

                //pointRenderer.material.color = Color.red;
                j++;
            }
        }*/
        //print("vertex: " + vertices.Length);


        // Mesh Vertex coloring

        for (int i = 0; i < 499; i++)
        {

            //print("i: " + i);
            //print("data value: " + bringData[i]);
            bringData = receive.AccessData();
            colors2[i] = colors0[19 - bringData[i]];

        }

        sphereMesh.colors = colors2;

        // t-design

        //for (int i = 0; i < 120; i++)
        //{
        //    GameObject Point = GameObject.Find("point" + i);

        //    //print(bringData[j]);
        //    bringData = receive.AccessData();
        //    Point.GetComponent<Renderer>().material.color = colors0[bringData[i]];
        //}

        
    }

}
