using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RocketController : MonoBehaviour 
{
	public GameObject rocketPrefab;
    public Camera theCamera;
    public GameObject[] rocketHills;

	public CameraShake cameraShakeScript;



    public AudioClip explosionSound;

    int[] rocketCounts;

    public Text[] counttexts;

    public followmouse crosshairScript;
    public DigitalRuby.PyroParticles.MakeExplosion explosionScript;

    void Start()
    {
       
        rocketCounts = new int[3];
        rocketCounts[0] = rocketCounts[1] = rocketCounts[2] = 15;
    }

    public bool OutOfRockets()
    {
        if (rocketCounts[0] == rocketCounts[1] && rocketCounts[1] == rocketCounts[2] && rocketCounts[2] == 0)
        {
            return true;
        }
        return false;
    }

	void Update () 
    {
		if (Input.GetMouseButtonDown(0)) 
		{
            //rotation x=15 position y=2.5
            crosshairScript.PlaceMarker();
            theCamera.transform.position = new Vector3( 0.0f,0.0f,-10.0f);
            theCamera.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f,0.0f);

            DecideWhichSilo();
            
            theCamera.transform.position = new Vector3(0.0f, 2.5f, -10.0f);
            theCamera.transform.rotation = Quaternion.AngleAxis(15.0f, new Vector3(1.0f, 0.0f, 0.0f));
		}

        
        UpdateRocketCounts();
        //ReloadLevel();
	}

    void ReloadLevel()
    {
        if (rocketCounts[0] == rocketCounts[1] && rocketCounts[1] == rocketCounts[2] && rocketCounts [2]== 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void UpdateRocketCounts()
    {
        for (int i = 0; i < 3; i++)
        {
            if (counttexts[i] != null)
                if (rocketCounts[i] > 0)
                    counttexts[i].text = rocketCounts[i].ToString() + " Left";
                else
                    counttexts[i].text = "Out!";
        }

    }




    void DecideWhichSilo()
    {
        //-4 and +4

        Vector3 clickposition = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -0.5f));
        clickposition.z = -0.5f;
        Debug.Log("mouse x and y: " + clickposition);


        if (clickposition.y > -1.3f && clickposition.y <=5.0f)
        {
            if (clickposition.x > -8.8 && clickposition.x < 8.8)
            {
                if (clickposition.x < -4)//Click is on the left side
                {
                    if (rocketCounts[0] > 0)
                        StartCoroutine(FireRocket(rocketHills[0], rocketHills[0].transform, clickposition, 1.0f));
                    else if (rocketCounts[1] > 0)
                        StartCoroutine(FireRocket(rocketHills[1], rocketHills[1].transform, clickposition, 1.0f));
                    else if (rocketCounts[2] > 0)
                        StartCoroutine(FireRocket(rocketHills[2], rocketHills[2].transform, clickposition, 1.0f));
                }
                else if (clickposition.x > -4 && clickposition.x < 4)//Click is in the middle
                {
                    if (rocketCounts[1] > 0)
                        StartCoroutine(FireRocket(rocketHills[1], rocketHills[1].transform, clickposition, 1.0f));
                    else if (rocketCounts[2] > 0 && clickposition.x > 0)
                        StartCoroutine(FireRocket(rocketHills[2], rocketHills[2].transform, clickposition, 1.0f));
                    else if (rocketCounts[0] > 0)
                        StartCoroutine(FireRocket(rocketHills[0], rocketHills[0].transform, clickposition, 1.0f));

                }
                else if (clickposition.x > 4)//Click is in the missle
                {
                    if (rocketCounts[2] > 0)//Fire from right
                        StartCoroutine(FireRocket(rocketHills[2], rocketHills[2].transform, clickposition, 1.0f));
                    else if (rocketCounts[1] > 0)//Fire from middle
                        StartCoroutine(FireRocket(rocketHills[1], rocketHills[1].transform, clickposition, 1.0f));
                    else if (rocketCounts[0] > 0)//Fire from left
                        StartCoroutine(FireRocket(rocketHills[0], rocketHills[0].transform, clickposition, 1.0f));
                }
            }
                
        }
    }

    IEnumerator FireRocket(GameObject rocketHill, Transform startMarker, Vector3 endMarker, float speed = 1.0F)
    {
        cameraShakeScript.shake = 1.0f;
        GameObject rocket = Instantiate(rocketPrefab, new Vector3(0.0f, 0.0f, -0.5f), Quaternion.identity) as GameObject;
        
        float totalDistance;
        float t = 0.0f;

        totalDistance = Vector3.Distance(startMarker.position, endMarker);

        for (int i = 0; i < 3; i++)
            if (rocketHill == rocketHills[i])
                rocketCounts[i]--;

        explosionScript.CreateExplosion(startMarker.position);

        while (t <= 1.0f&& rocket!=null)
        {
            t += Time.deltaTime * (Time.timeScale / speed);
            rocket.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker, (float)t);

            rocket.transform.LookAt(endMarker, new Vector3(0f, 0f, 1f));

            if (rocket.transform.position == endMarker)
            {
                

                explosionScript.CreateExplosion(endMarker);
                rocket.GetComponent<AudioSource>().clip=explosionSound;
                rocket.GetComponent<AudioSource>().Play();
                crosshairScript.DeleteMarker(rocket.transform.position);
                Debug.Log("Got To point(" + rocket.transform.position + ")");
            }

            yield return 0;
        }
    }


    public void DestroySilo(GameObject theSilo)
    {
        Debug.Log("Rocket Hill Hit!");

        for(int i=0;i<3;i++)
        {
            if (theSilo == rocketHills[i])
            {
                Debug.Log("Rocket Hill " + i + " Hit!");
                rocketCounts[i] = 0;
            }
        }
    }

    public void HitSilo(GameObject theSilo)
    {
        Debug.Log("Rocket Hill Hit!");

        for (int i = 0; i < 3; i++)
        {
            if (theSilo == rocketHills[i])
            {
                rocketCounts[i] /= 2;
            }
        }
    }
}