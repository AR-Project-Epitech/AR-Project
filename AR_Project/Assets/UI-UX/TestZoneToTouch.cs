using UnityEngine;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class TestZoneToTouch : MonoBehaviour
{

    public GameObject particle;
    public GameObject clone;

    public GameObject pause;
    public GameObject option;

    public static int i = 0;

    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && GameStats.nbArrows != 0 && !pause.activeInHierarchy && !option.activeInHierarchy)
                {
                    Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    Vector3 pos;
                    pos.z = 12;
                    pos.x = Input.touches[0].position.x / 100 - pos.z/2;
                    pos.y = Input.touches[0].position.y / 100 - pos.z/2;
                  //  Debug.Log("pos x: " + pos.x + " ; " + pos.y);
                    clone = Instantiate(particle, pos, transform.rotation) as GameObject;
                    if (GameStats.nbArrows != 0)
                        GameStats.setArrows(GameStats.nbArrows - 1);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && GameStats.nbArrows != 0 && !pause.activeInHierarchy && !option.activeInHierarchy)
                {
                    Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;

                    Vector3 pos;
                    pos.z = 12;
                    pos.x = Input.mousePosition.x / 100 - pos.z/2;
                    pos.y = Input.mousePosition.y / 100 - pos.z/2;
                   // Debug.Log("pos x: " + pos.x + " ; " + pos.y);
                    clone = Instantiate(particle, pos, transform.rotation) as GameObject;
                    if (GameStats.nbArrows != 0)
                        GameStats.setArrows(GameStats.nbArrows - 1);
                }
            }
        }
    }
}
