using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boss))]
[RequireComponent(typeof(BossMover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class BossDeath : MonoBehaviour
{
    [SerializeField] private string _animationName;
    [SerializeField] private Sprite _deadBossSprite;
    [SerializeField] private float _deathDuration;
    [SerializeField] private GameObject _finishPanelTemplate;
    [SerializeField] private GameObject _finishPanelPlace;
    [SerializeField] private ParticleSystem _particleSystem;

    private Boss _boss;
    private SpriteRenderer _SpriteRenderer;
    private BossMover _bossMover;
    private PlayerInput _playerInput;
    private PlayerMover _playerMover;
    private Animator _animator;
    private WaitForSeconds _playAnimationTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        _boss = GetComponent<Boss>();
        _boss.Died += OnDead;

        _bossMover = GetComponent<BossMover>();

        _playerInput = _boss.Target.gameObject.GetComponent<PlayerInput>();
        _playerMover = _boss.Target.gameObject.GetComponent<PlayerMover>();

        _playAnimationTime = new WaitForSeconds(_deathDuration);
    }

    private void OnEnable()
    {
        if (_boss != null)
            _boss.Died += OnDead;
    }

    private void OnDisable()
    {
        _boss.Died -= OnDead;
    }
    
    private void OnDead()
    {
        if (TryGetComponent(out BossDropper bossDropper))
            bossDropper.enabled = false;

        _playerMover.Stop();
        _playerInput.enabled = false;

        _boss.Target.enabled = false;
        _boss.enabled = false;
        _bossMover.enabled = false;

        _particleSystem.Play();
        _animator.Play(_animationName);
        _SpriteRenderer.sprite = _deadBossSprite;
        StartCoroutine(PlayDeathAnimation());
    }

    private IEnumerator PlayDeathAnimation()
    {
        yield return _playAnimationTime;
        Instantiate(_finishPanelTemplate, _finishPanelPlace.transform);
    }
}
