using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text win;
	public Transform pickups;

	private int _count;

	void Start()
	{
		_count = 0;
		win.gameObject.SetActive (false);
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		var movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "PickUp") {
			other.gameObject.SetActive(false);
			_count += 1;
			if(pickups.childCount == _count)
			{
				win.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
			SetCountText();
		}
	}
	
	void SetCountText ()
	{
		countText.text = _count.ToString ();
	}
}
