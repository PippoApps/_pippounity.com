using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] public float _refreshTime = 0.02f;
    [SerializeField] public string _cameraTag;
    private Camera _camera;
    private WaitForSecondsRealtime _waitFractionOfSecond;
    private bool _active = true;
    private SystemPippoUnity _system;
    // Delegates
    public delegate void CollidedGameObject(GameObject obj);
    public static event CollidedGameObject collidedGameObjectListeners;

    // Start is called before the first frame update
    void Start()
    {
        _system = new SystemPippoUnity("FollowCamera:" + _cameraTag);
        _waitFractionOfSecond = new WaitForSecondsRealtime(_refreshTime);
        _system.L("Finding Camera: " + _cameraTag);
        _camera = GameObject.FindWithTag(_cameraTag).GetComponent < Camera > ();
        if (!_camera)
        {
            _system.E("Camera not found!");
            return;
        }
        StartCoroutine(PositionToCamera());
        //Make ObjectA's position match objectB
        

        //Now parent the object so it is always there
        //transform.parent = _camera;
    }

    IEnumerator PositionToCamera()
    {
        while (_active)
        {
            //_system.L("Following Camera: " + this.name);
            transform.position = _camera.transform.position;

          //+= 10;
            yield return _waitFractionOfSecond;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //AudioLoader audioLoader = other.gameObject.GetComponent<AudioLoader>();
        //if (audioLoader)
        //{
            _system.L("Collided GameObject " + other.gameObject);
            if (collidedGameObjectListeners != null)
            {
                collidedGameObjectListeners(other.gameObject);
            }
        //}
        //Debug.Log(audioLoader.ID);
        //Debug.LogWarning($"{gameObject.name} is colliding with {other.name}, {other.transform.parent.gameObject}");

    }



     

    // Update is called once per frame
    void Update()
    {
        
    }


}
