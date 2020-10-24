using UnityEngine;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class TestZoneToTouch : MonoBehaviour {

    public GameObject particle;
    public GameObject clone;

    public GameObject pause;
    public GameObject option;

    public static int i = 0;

    void Update () {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay (Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit)) {
                if (hit.collider != null && GameStats.nbArrows != 0 && !pause.activeInHierarchy && !option.activeInHierarchy) {
                    Color newColor = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), 1.0f);
                    hit.collider.GetComponent<MeshRenderer> ().material.color = newColor;
                    
                    clone = Instantiate (particle, hit.point, transform.rotation) as GameObject;
                    GameStats.setScore(GameStats.scoreValue + 1);
                }
            }
            
            if (GameStats.nbArrows != 0)
                GameStats.setArrows (GameStats.nbArrows - 1);
        }
        if (Input.GetMouseButtonDown (0)) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit)) {
                if (hit.collider != null && GameStats.nbArrows != 0 && !pause.activeInHierarchy && !option.activeInHierarchy) {
                    Color newColor = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), 1.0f);
                    hit.collider.GetComponent<MeshRenderer> ().material.color = newColor;
                    
                    clone = Instantiate (particle, hit.point, transform.rotation) as GameObject;
                    GameStats.setScore(GameStats.scoreValue + 1);
                }
            }
            
            if (GameStats.nbArrows != 0)
                GameStats.setArrows (GameStats.nbArrows - 1);
        }
    }
}