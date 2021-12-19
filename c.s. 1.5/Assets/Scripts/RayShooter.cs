using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class RayShooter : MonoBehaviour
{
    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
       
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 pixels = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(pixels);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject enemy = hit.transform.gameObject;
                ReactiveTarget target = enemy.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(CreateSphere(hit.point));
                }
                
            }
        }
    }


    private IEnumerator CreateSphere(Vector3 point)
    {
        GameObject Go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Go.transform.position = point;
        yield return new WaitForSeconds(1);
        Destroy(Go);
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
