using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RocketController : MonoBehaviour 
{
	
	public GameObject rocketPrefab;
    public Camera theCamera;
    public GameObject[] rocketHills;
    public Text scoreText;
    public Text highScoreText;
	public CameraShake cameraShakeScript;

    int score;
    int highscore;

    public AudioClip explosionSound;

    void Start()
    {
        scoreText.text = "0";
        highscore = PlayerPrefs.GetInt("HighScore");
        
    }

	void Update () 
    {
		if (Input.GetMouseButtonDown(0)) 
		{

            //rotation x=15 position y=2.5
            
            theCamera.transform.position = new Vector3( 0.0f,0.0f,-10.0f);
            theCamera.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f,0.0f);

            DecideWhichSilo();
            
            theCamera.transform.position = new Vector3(0.0f, 2.5f, -10.0f);
            theCamera.transform.rotation = Quaternion.AngleAxis(15.0f, new Vector3(1.0f, 0.0f, 0.0f));
		}

        UpdateHighScore();
	}

    void UpdateHighScore()
    {
        if (score > highscore)
            highscore = score;

        PlayerPrefs.SetInt("HighScore", highscore);

        highScoreText.text = highscore.ToString();
    }


    void DecideWhichSilo()
    {
        //-4 and +4

        Vector3 clickposition = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -0.5f));
        clickposition.z = -0.5f;
        Debug.Log("mouse x and y: " + clickposition);


        if (clickposition.y >= -1.5f)
        {
			cameraShakeScript.shake = 1.0f;
            if (clickposition.x < -4)
                StartCoroutine(FireRocket(rocketHills[0], rocketHills[0].transform, clickposition, 1.0f));
            else if (clickposition.x > -4 && clickposition.x < 4)
                StartCoroutine(FireRocket(rocketHills[1], rocketHills[1].transform, clickposition, 1.0f));
            else if (clickposition.x > 4)
                StartCoroutine(FireRocket(rocketHills[2], rocketHills[2].transform, clickposition, 1.0f));
        }


       

    }

    IEnumerator FireRocket(GameObject rocketHill, Transform startMarker, Vector3 endMarker, float speed = 1.0F)
    {
        GameObject rocket = Instantiate(rocketPrefab, new Vector3(0.0f, 0.0f, -0.5f), Quaternion.identity) as GameObject;
        
        float totalDistance;
        float t = 0.0f;

        totalDistance = Vector3.Distance(startMarker.position, endMarker);
        while (t <= 1.0f&& rocket!=null)
        {
            t += Time.deltaTime * (Time.timeScale / speed);
            rocket.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker, (float)t);

            rocket.transform.LookAt(endMarker, new Vector3(0f, 0f, 1f));

            if (rocket.transform.position == endMarker)
            {
                score += 10;
                scoreText.text = score.ToString();

                rocket.GetComponent<AudioSource>().clip=explosionSound;
                rocket.GetComponent<AudioSource>().Play();


                Debug.Log("Got To point(" + rocket.transform.position + ")");
            }

            yield return 0;
        }
    }
}