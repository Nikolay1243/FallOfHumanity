using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class followmouse : MonoBehaviour {

    public Camera mouseCam;
    public Vector3 mousepos;
    public List<GameObject> markers;
    public GameObject markerPrefab;

    void Start()
    {
        
    }
	void Update () 
    {
       
        Cursor.visible = false;

        mousepos = mouseCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

        ConstrainCrosshair();
         
        this.transform.position = mousepos;

        Vector3 thislocpos = this.transform.localPosition;       
        transform.localPosition = new Vector3(thislocpos.x, thislocpos.y, 0f);
	}

    void ConstrainCrosshair()
    {
        if (mousepos.y < 1.0f)
            mousepos = new Vector3(mousepos.x, 1.0f, mousepos.z);
        if (mousepos.y > 7.5f)
            mousepos = new Vector3(mousepos.x, 7.5f, mousepos.z);



        if (mousepos.x > 8.9)
            mousepos = new Vector3(8.9f, mousepos.y, mousepos.z);

        if (mousepos.x < -8.9f)
            mousepos = new Vector3(-8.9f, mousepos.y, mousepos.z);
    }

    public void PlaceMarker()
    {
        GameObject newmarker=(GameObject)Instantiate(markerPrefab, transform.position, Quaternion.identity);
        
        newmarker.transform.SetParent(this.transform.parent,false);
        newmarker.transform.position = transform.position;
        Debug.Log("Marker: " + newmarker.transform.position);
        markers.Add(newmarker);

    }
    public void DeleteMarker(Vector3 rocketpos)
    {
        Vector3 correctedRocketPos=new Vector3(rocketpos.x,rocketpos.y + 2.1f,-0.5f);
        Debug.Log("Corrected " + correctedRocketPos);
        foreach(GameObject curmarker in markers)
        {
            if(curmarker!=null)
            {
                if(curmarker.transform.position==correctedRocketPos)
                {
                    markers.Remove(curmarker);
                    Destroy(curmarker);
                }
            }
        }
    }



}
