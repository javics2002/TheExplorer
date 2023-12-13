using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class ChangeMusicPropierties : MonoBehaviour
{
    public void EnterCave() {
		GameManager.Instance.ambience.adjustEQINCave(true);
	}

	public void ExitCave() {
		GameManager.Instance.ambience.adjustEQINCave(false);
	}
}
