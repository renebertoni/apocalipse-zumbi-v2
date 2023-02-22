using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SpawnStorage : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _gameObjects = new List<GameObject>();

    public GameObject GetObject( string objectName ){
        return _gameObjects.Where( obj => obj.name == objectName ).SingleOrDefault();
    }
}
