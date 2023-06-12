using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class BannerSpawner : MonoBehaviour
{
    [SerializeField] private int _mistakesToSpawnBanner = 3;
    
    private VisualElement _root;
    private Vector2Int _screenSize;
    private RuleBannerWithTimer _ruleBanner;
    private int _mistakes;
    private List<DefaultBanner> _banners = new List<DefaultBanner>();

    public UnityEvent OnSpawnBanner;
    public UnityEvent OnSpawnRuleBanner;

    private void Start()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;

        _ruleBanner = new RuleBannerWithTimer(ReturnAction);
        _ruleBanner.SetActive(false);
        _ruleBanner.Resize(400, 300);
        _root.Add(_ruleBanner);

        _screenSize = new Vector2Int(Screen.width, Screen.height);
    }

    public void SpawnBanner(int amount)
    {
        if (amount >= 0) return;
        _mistakes -= amount;
        
        if (_mistakes < _mistakesToSpawnBanner) return;
        _mistakes %= _mistakesToSpawnBanner;
        
        DefaultBanner banner = new DefaultBanner(ReturnAction);
        
        Vector2Int rad = RandomPos(Vector2Int.zero, _ruleBanner.Size() / 2);
        Vector3 nRad = new Vector3(rad.x, rad.y, 0);
        float angel = Random.Range(0, 360);
        nRad = Quaternion.AngleAxis(angel, Vector3.forward) * nRad;
        rad = new Vector2Int((int)nRad.x, (int)nRad.y) + _ruleBanner.Position();
        rad.Clamp(Vector2Int.zero, _screenSize - banner.Size());

        banner.Reposition(rad);
        banner.Resize(400, 300);
        
        StopAllCoroutines();
        _root.Add(banner);
        _banners.Add(banner);
        
        OnSpawnBanner?.Invoke();
    }

    public IBanner Preload => new DefaultBanner(ReturnAction);
    
    public void GetAction(IBanner banner) => banner.SetActive(true);
    public void ReturnAction(IBanner banner) => banner.SetActive(false);

    public void SpawnRuleBanner(InputRule rule, int ruleTime)
    {
        Vector2Int oldPos = _ruleBanner.Position();
        
        _ruleBanner.SetRule(rule, ruleTime);
        _ruleBanner.SetActive(true);
        SetRandomBannerPos(_ruleBanner);

        StartCoroutine(ReposBanners(_ruleBanner.Position() - oldPos));

        OnSpawnRuleBanner?.Invoke();
    }

    private IEnumerator ReposBanners(Vector2Int delta)
    {
        foreach (var bn in _banners)
        {
            Vector2Int newPos = bn.Position() + delta;
            newPos.Clamp(Vector2Int.zero, _screenSize - bn.Size());
            bn.Reposition(newPos);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetRandomBannerPos(IBanner banner)
    {
        Vector2Int randomPos = RandomPos(Vector2Int.zero, _screenSize - banner.Size());
        banner.Reposition(randomPos);
    }

    private Vector2Int RandomPos(Vector2Int min, Vector2Int max)
    {
        int x = Random.Range(min.x, max.x);
        int y = Random.Range(min.y, max.y);
        return new Vector2Int(x, y);
    }
}
