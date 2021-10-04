using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum STATE
    {
        IDLE, ATTACK
    };
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT _stage;
    protected GameObject _npc;
    protected Animator _anim;
    protected Transform _player;
    protected GameObject _bullet;
    protected State _nextState;

    private float _attackDistance = 10.0f;
    public State(GameObject npc, Animator anim, Transform player, GameObject bullet)
    {
        _npc = npc;
        _anim = anim;
        _player = player;
        _bullet = bullet;
    }
    public virtual void Enter() { _stage = EVENT.UPDATE; }
    public virtual void Update() { _stage = EVENT.UPDATE; }
    public virtual void Exit() { _stage = EVENT.EXIT; }
    public State Process()
    {
        if (_stage == EVENT.ENTER) Enter();
        if (_stage == EVENT.UPDATE) Update();
        if (_stage == EVENT.EXIT)
        {
            Exit();
            return _nextState;
        }
        return this;
    }
    public bool CanAttackPlayer()
    {
        if (Vector3.Distance(_npc.transform.position, _player.position) <= _attackDistance)
        {
            return true;
        }
        return false;
    }
}
public class Idle : State
{
    public Idle(GameObject npc, Animator anim, Transform player, GameObject bullet) : base(npc, anim, player, bullet)
    {
        name = STATE.IDLE;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        if (CanAttackPlayer())
        {
            _nextState = new NpcAttack(_npc, _anim, _player, _bullet);
            _stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
public class NpcAttack : State
{
    public NpcAttack(GameObject npc, Animator anim, Transform player, GameObject bullet) : base(npc, anim, player, bullet)
    {
        name = STATE.ATTACK;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        Vector3 relativePos = Vector3.RotateTowards(_npc.transform.forward, (_player.position - _npc.transform.position), 100.0f * Time.deltaTime ,0.0f);
        _npc.transform.rotation = Quaternion.LookRotation(relativePos);
        Debug.DrawRay(_npc.transform.position, relativePos, Color.red);
        {
            _nextState = new Idle(_npc, _anim, _player, _bullet);
            _stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

}