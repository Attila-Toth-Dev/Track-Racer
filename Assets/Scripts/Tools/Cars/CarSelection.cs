using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
	[SerializeField] private Button nextButton;
	[SerializeField] private Button prevButton;

	[SerializeField] private GameSceneManager gsManager;

	private int currentCar;

	private void Awake()
	{
		SelectCar(0);
	}

	public void Play()
	{
		string sceneName = PlayerPrefs.GetString("Track");
		PlayerPrefs.SetInt("Car", currentCar);
		
		gsManager.ChangeScene(sceneName);
	}
	
	public void SelectCar(int _index)
	{
		prevButton.interactable = (_index != 0);
		nextButton.interactable = (_index != transform.childCount - 1);
		
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(i == _index);
		}
	}

	public void ChangeCar(int _change)
	{
		currentCar += _change;
		SelectCar(currentCar);
	}
}
