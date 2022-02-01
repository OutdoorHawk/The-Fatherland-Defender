
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[][] points;
   

    [SerializeField] private Transform[] _pathsParent;



    private void Awake()
    {

        for (int j = 0; j < _pathsParent.Length; j++)
        {
            points = new Transform[_pathsParent.Length][];

        }


      


        for (int i = 0; i < _pathsParent.Length; i++)
        {

            points[i] = new Transform[_pathsParent[i].childCount];
            
            for (int k = 0; k < _pathsParent[i].childCount; k++)
            {
                

                points[i][k] = _pathsParent[i].GetChild(k);

               
                
            }
            
        }
        
       


       
    }

    //private void Awake()
    //{

    //    for (int j = 0; j < _paths.Length; j++)
    //    {
    //        points = new Transform[_paths.Length, _paths[j].childCount];
    //    }





    //    for (int i = 0; i < _paths.Length; i++)
    //    {
    //        for (int k = 0; k < _paths[i].childCount; k++)
    //        {
    //            points[i, k] = _paths[i].GetChild(k);

    //        }

    //    }





    //}


}



