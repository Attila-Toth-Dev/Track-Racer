using Managers;

using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Tools.Cars
{
	public class CarSelection : MonoBehaviour
	{
		[SerializeField] private Button nextButton;
		[SerializeField] private Button prevButton;

		[SerializeField] private TextMeshProUGUI carName;
		[SerializeField] private TextMeshProUGUI carDesc;

		[SerializeField] private TextMeshProUGUI carSpeed;
		[SerializeField] private TextMeshProUGUI carAccel;
		[SerializeField] private TextMeshProUGUI carHandling;

		[SerializeField] private List<Car> cars;

		private GameSceneManager gsManager;

		private int currentCar;
		private int currentIndex;

		private void Awake()
		{
			gsManager = FindObjectOfType<GameSceneManager>();
			if(gsManager == null)
				Debug.LogWarning("CAR SELECTION: Game Scene Manager is NULL");
			
			SelectCar(0);
		}

		public void Play()
		{
			string sceneName = PlayerPrefs.GetString("Track");
			PlayerPrefs.SetInt("Car", currentCar);
			
			PlayerPrefs.SetFloat("Speed", cars[currentCar].speed);
			PlayerPrefs.SetFloat("Acceleration", cars[currentCar].acceleration);
			PlayerPrefs.SetFloat("Handling", cars[currentCar].handling);
			
			gsManager.ChangeScene(sceneName);
		}
		
		public void SelectCar(int _index)
		{
			prevButton.interactable = (_index != 0);
			nextButton.interactable = (_index != transform.childCount - 1);
			
			carName.text = cars[currentCar].carName;
			carName.color = Color.white;
				
			carDesc.text = cars[currentCar].carDescription;

			carSpeed.text = $"- {cars[currentCar].speed.ToString()} KM/PH";
			carAccel.text = $"- {cars[currentCar].acceleration.ToString()}";
			carHandling.text = $"- {cars[currentCar].acceleration.ToString()}";
			
			for(int i = 0; i < transform.childCount; i++)
				transform.GetChild(i).gameObject.SetActive(i == _index);
		}

		public void ChangeCar(int _change)
		{
			currentCar += _change;
			SelectCar(currentCar);
		}
	}
}

