using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    public BoxCollider2D SnackPoit;
    private List<Transform> _segment = new List<Transform>();
 
    public Transform segmentPrefab;

    private void Start()
    {
        SnakePositionStart();
        _segment.Add(transform);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            _direction = Vector2.up;
        }
         else if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A)))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D)))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            _direction = Vector2.down;
        }

        
    }

    private void FixedUpdate()
    {

        for (int i = _segment.Count-1; i >0; i--)
        {
            _segment[i].position = _segment[i-1].position;
        }
        transform.position = new Vector2((Mathf.Round(transform.position.x + _direction.x)), (Mathf.Round(transform.position.y + _direction.y)));
    }
    private void SnakePositionStart()
    {
        Bounds bounds = SnackPoit.bounds;
        float x =Random.Range(bounds.min.x,bounds.max.x);
        float y =Random.Range(bounds.min.y,bounds.max.y);
        transform.position = new Vector3( Mathf.Round( x),Mathf.Round( y), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Wall")
        //{
        //    //SnakePositionStart();
            
        //}
        
        if (collision.tag == "Food")
        {
            Grow();
        }
    }
    private void Grow()
    {
     Transform segment =  Instantiate(this.segmentPrefab);
        segment.position = _segment[_segment.Count-1].position;
        _segment.Add(segment);
    }
  

}