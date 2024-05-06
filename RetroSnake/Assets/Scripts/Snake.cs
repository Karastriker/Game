using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segementPrefab;
    public float increaseTimescale = 1.1f;

    public int initialSize = 4;

    public GameOver gameOver;
    int maxPlatform;

    public int maxHealth = 100;
    public int currentHealth;

    public SnakeGauge snakeGauge;

    private bool snakeMoveEnable = true;

    private void Start()
    {
        currentHealth = maxHealth;
        snakeGauge.SetMaxHealth(maxHealth);
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != -Vector2.up)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != -Vector2.down)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != -Vector2.left)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != -Vector2.right)
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (snakeMoveEnable)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + _direction.x,
                Mathf.Round(this.transform.position.y) + _direction.y,
                0.0f);
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segementPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segementPrefab));
        }
        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            Time.timeScale *= increaseTimescale;
            Score.instance.AddPoint();
            TakeFood(10);
        }
        else if (other.tag == "Obstacle")
        {
            StartCoroutine(ReduceSnake());
        }
    }

    private IEnumerator ReduceSnake()
    {
        if(!snakeMoveEnable) yield break;

        snakeMoveEnable = false;

        for (int i = _segments.Count - 1; i >= 1; i--)
        {
            Destroy(_segments[i].gameObject);
            _segments.RemoveAt(i);
            yield return new WaitForSeconds(0.2f);
        }
        ResetState();
        gameOver.GameOverScreen(maxPlatform);
        if (snakeMoveEnable)
        {
            Score.instance.ResetScore();
        }
        Time.timeScale = 0.4f;
        snakeMoveEnable = true;
    }

    public void TakeFood(int food)
    {
        currentHealth -= food;
        snakeGauge.SetHealth(currentHealth);
    }
}
