﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Player : MonoBehaviour
{

	public Text scoreText;
	public Text winText;
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	public float cityMapWidth = 100f;
	public int pickUpsCount;

	private int score;
	private float time = 0f;

	void Start ()
	{
		Reset ();
	}

	void Update ()
	{
		time += Time.deltaTime;

		float horizontal = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
		transform.RotateAround (transform.position, Vector3.up, horizontal);

		float vertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (0, 0, vertical);

		SetScoreText ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			score += 1;
			SetScoreText ();
		}
	}

	public void Reset ()
	{
		score = 0;
		time = 0f;
		SetScoreText ();
		SetWinText ("");
		transform.position = new Vector3 (cityMapWidth / 2, 1f, -10f);
		transform.rotation = Quaternion.identity;
	}

	private void SetScoreText()
	{
		scoreText.text = "Time: " + time.ToString("0.00") 
			+ "\nScore: " + score.ToString ();
		if (score >= pickUpsCount) {
			SetWinText ("You Win!\nTime: " + time.ToString("0.00"));
		}
	}

	private void SetWinText(string text)
	{
		winText.text = text;
	}

}
