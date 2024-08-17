using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private GameObject dataStorageObject;
    public DataStorage dataStorage;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        dataStorage = dataStorageObject.GetComponent<DataStorage>();
        dataStorage.volume = slider.value;
    }

    public void SetVolume()
    {
        Debug.Log(slider.value);
        dataStorage.volume = slider.value;
    }
}
