using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera _camera;
	private GameObject scrollingBg;
	private float bgTileHeight;

	public GameObject player;
	public GameObject backgroundPrefab;

	// Use this for initialization
	void Start () {
		// Cover background with background sprite
		//var bg = Instantiate(background);
		_camera = GetComponent<Camera>();

		bgTileHeight = backgroundPrefab.GetComponent<SpriteRenderer> ().sprite.bounds.size.y;

		scrollingBg = new GameObject();
		for (int i = 0; i < 4; i++) {
			var bgTile = Instantiate (backgroundPrefab, Vector3.zero, Quaternion.identity);
			bgTile.transform.parent = scrollingBg.transform;
			bgTile.transform.position = new Vector3 (0, -1 * bgTileHeight * i, 0);
		}


	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			transform.position.x, 
			player.gameObject.transform.position.y,
			transform.position.z
		);

		var diff = scrollingBg.transform.position.y - gameObject.transform.position.y;
		//Debug.Log (scrollingBg.transform.position);

		if (diff >= bgTileHeight * 2) {
			scrollingBg.transform.position = new Vector3 (
				scrollingBg.transform.position.x,
				scrollingBg.transform.position.y - bgTileHeight,
				scrollingBg.transform.position.z
			);
		}
		// Make sure background is visible
		//Debug.Log(background.bounds);
	}
}
