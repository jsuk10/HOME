using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton
{
    void init();
}

public abstract class Singleton<T> : MonoBehaviour, ISingleton where T : Singleton<T>
{
    public abstract void init();

    protected static T _instance;

    public static T Instance => _instance != null ? _instance : GetInstanceObject();

    protected static T GetInstanceObject()
    {
        if (_instance != null) return _instance;

        _instance = FindObjectOfType<T>();

        var _singleton = _instance as Singleton<T>;

        _singleton.init();

        return _instance;
    }

    protected void Awake()
    {
        _instance = GetInstanceObject();
    }

}