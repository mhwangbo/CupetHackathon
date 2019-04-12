using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;
    private AbstractLocationProvider _locationProvider = null;
    private bool locationFound;
    public Transform target;

    void Start()
    {
        if (null == _locationProvider)
        {
            _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Location currLoc = _locationProvider.CurrentLocation;
        if (currLoc.IsLocationServiceInitializing)
        {
            return;
        }
        else
        {
            if (!currLoc.IsLocationServiceEnabled)
            {
                return;
            }
            else
            {
                if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
                {
                    return;
                }
                else
                {
                    if (!locationFound)
                    {
                        locationFound = true;
                        GameObject animal = Instantiate(animalPrefab);
                        animal.transform.position = new Vector3(target.position.x - 1.0f, target.position.y, target.position.z - 1.0f);
                    }
                }
            }
        }
    }
}
