using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Animator characterAnimator;
    private AbstractLocationProvider _locationProvider = null;
    private Vector2d prevLocation;


    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        if (null == _locationProvider)
        {
            _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }
    }

    private void Update()
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
                if(currLoc.LatitudeLongitude.Equals(Vector2d.zero))
                {
                    return;
                }
                else
                {
                    if(prevLocation != currLoc.LatitudeLongitude)
                    {
                        prevLocation = currLoc.LatitudeLongitude;
                        characterAnimator.SetBool("Walking", true);
                    }
                    else
                    {
                        characterAnimator.SetBool("Walking", false);
                    }
                }
            }
        }
    }
}
