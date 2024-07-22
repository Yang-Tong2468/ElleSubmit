using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DementorAI : MonoBehaviour
{
    public float rotationSpeed = 10f;

    //记录蝙蝠的初始位置
    Vector2 spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初始化蝙蝠的初始位置
        spawnPoint = transform.position;
    }

    Collider2D[] GetNearbyPlayers()
    {
        List<Collider2D> players = new();
        foreach (var maybePlayer in Physics2D.OverlapCircleAll(transform.position, 10f))
        {
            if (maybePlayer.CompareTag("Player"))
            {
                players.Add(maybePlayer);
            }
        }
        return players.ToArray();
    }

    //锁定的玩家对象
    private GameObject playerLocked = null;

    //锁定玩家的位置
    private Vector2 playerLockedPosition = new(0, 0);

    //锁定玩家最后一次移动的时间
    private float playerLockedLastMovingTime = 0;

    private float lastFlyAround = -666;

    // Update is called once per frame
    void Update()
    {
        if (lastFlyAround + 2f <= Time.time)
        {
            Collider2D[] players = GetNearbyPlayers();
            if (players.Length == 0)
            {
                StartCoroutine(FlyAround(spawnPoint));
            }
            else
            {
                if (playerLocked == null)
                {
                    playerLocked = players[0].gameObject;
                }

                Vector2 playerLoca = players[0].transform.position;
                if (!playerLocked.transform.position.Equals(playerLockedPosition))
                {
                    playerLockedPosition = playerLoca;
                    playerLockedLastMovingTime = Time.time;

                    StartCoroutine(FlyAround(playerLoca));
                }
                else
                {
                    if (playerLockedLastMovingTime + 2f <= Time.time)
                    {
                        StartCoroutine(DashDowngrade());
                    }
                }
            }
        }
    }

    IEnumerator FlyAround(Vector2 point)
    {
        lastFlyAround = Time.time;

        var self = GetComponent<Rigidbody2D>();
        self.velocity = new Vector2(point.x - 20f, self.velocityY) - new Vector2(point.x, self.velocityY);
        yield return new WaitForSeconds(0.5f);
        self.velocity = new Vector2(point.x, self.velocityY) - new Vector2(point.x, self.velocityY);
        yield return new WaitForSeconds(0.5f);
        self.velocity = new Vector2(point.x + 20f, self.velocityY) - new Vector2(point.x, self.velocityY);
        yield return new WaitForSeconds(0.5f);
        self.velocity = new Vector2(point.x, self.velocityY) - new Vector2(point.x, self.velocityY);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator DashDowngrade()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        var self = GetComponent<Rigidbody2D>();
        self.velocity = (playerLocked.transform.position - transform.position) * 3;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        self.velocity = (spawnPoint - (Vector2)transform.position) * 6;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FlyAround(spawnPoint));
    }
}
