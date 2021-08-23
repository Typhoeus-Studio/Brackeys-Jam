using System;
using System.Collections;
using System.Collections.Generic;
using CustomFeatures;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int damage;
    private float _liveTime = 3f;
    private float _currentLiveTime = 3f;

    private bool _active;


    public void Initialize(Transform transf, float bulletForce)
    {
        bulletSpeed = bulletForce;
        transform.position = transf.position + transf.forward;
        gameObject.SetActive(true);
        _currentLiveTime = _liveTime;
        _active = true;
        rb.AddForce(transf.forward * bulletSpeed, ForceMode.Impulse);
    }


    public void Dispose()
    {
        _active = false;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_active) return;
        _currentLiveTime -= Time.deltaTime;
        if (_currentLiveTime <= 0)
            Dispose();
    }

  

    private void OnCollisionEnter(Collision other)
    {
        if (other.HasComponent<Enemy>())
        {
            //Bullet splash anim
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}