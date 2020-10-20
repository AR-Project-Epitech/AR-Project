using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Fire : MonoBehaviour {
	public Button yourButton;
    public GameObject player;
    private Rigidbody rb;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(FireStart);
        rb = player.GetComponent<Rigidbody>();
	}

	void FireStart(){
		Debug.Log ("You have clicked the button!");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
        rb.AddForce(rb.transform.forward * 1000);
		//rb.transform.position += transform.forward * Time.deltaTime * 1000;
	}
}