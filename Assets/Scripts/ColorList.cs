using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MonoBehaviour
{

    [SerializeField] private List<Color> colorList = new List<Color>();
    [SerializeField] private List<RobbieTDAController> robbieList = new List<RobbieTDAController>();

    // Start is called before the first frame update
    void Start()
    {

        colorList.Add(Color.red);
        colorList.Add(Color.blue);
        colorList.Add(Color.green);



        Debug.Log("There are " + colorList.Count + " colors in the list. \n");
        Debug.Log("Los colores son: ");

        for(int i =0; i<robbieList.Count; i++)
        {
            var robbieLight = robbieList[i].GetComponent<Light>();
            robbieLight.color = colorList[i];
            Debug.Log(colorList[i]);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
