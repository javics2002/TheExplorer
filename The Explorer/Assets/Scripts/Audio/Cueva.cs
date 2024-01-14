using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cueva : MonoBehaviour
{
	public void adjustEQINCave(bool isInCave) {
		GameManager.Instance.ambience.adjustEQINCave(isInCave);
	}
}
