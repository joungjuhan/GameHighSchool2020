﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총을 구현한다
public class Gun : MonoBehaviour {
    // 총의 상태를 표현하는데 사용할 타입을 선언한다
    public enum State {
        Ready, // 발사 준비됨
        Empty, // 탄창이 빔
        Reloading // 재장전 중
    }

    public State state { get; private set; } // 현재 총의 상태

    public Transform fireTransform; // 총알이 발사될 위치

    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출 효과

    private LineRenderer bulletLineRenderer; // 총알 궤적을 그리기 위한 렌더러

    private AudioSource gunAudioPlayer; // 총 소리 재생기
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    public float damage = 25; // 공격력
    private float fireDistance = 50f; // 사정거리

    public int ammoRemain = 100; // 남은 전체 탄약
    public int magCapacity = 25; // 탄창 용량
    public int magAmmo; // 현재 탄창에 남아있는 탄약


    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
    private float lastFireTime; // 총을 마지막으로 발사한 시점

    
    private void Awake() {
        // 사용할 컴포넌트들의 참조를 가져오기
        bulletLineRenderer = GetComponent<LineRenderer>();
        gunAudioPlayer = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        // 총 상태 초기화
    }

    // 발사 시도
    public void Fire() {
        //마지막으로 총을 쏜시간 + 공격 딜레이보디 현재시간이 더오래 되었으면 
        if(lastFireTime + timeBetFire<= Time.time)
        {
            Shot();
            //마지막으로 총을 쏜시간은 현재.
            lastFireTime = Time.time;
        }
    }

    // 실제 발사 처리
    private void Shot() {
        RaycastHit hitInfo;
     bool isHit = Physics.Raycast(fireTransform.position, fireTransform.forward,out hitInfo, fireDistance);

        Vector3 hitPosition;
        if(isHit)
        {
            hitPosition = hitInfo.point;
        }
        else
        {
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;

        }
        StartCoroutine(ShotEffect(hitPosition));
    }

    // 발사 이펙트와 소리를 재생하고 총알 궤적을 그린다
    private IEnumerator ShotEffect(Vector3 hitPosition) {

        List<Vector3> linepoint = new List<Vector3>();
        linepoint.Add(fireTransform.position);
        linepoint.Add(hitPosition);


        bulletLineRenderer.SetPositions(linepoint.ToArray());

        //Vector3[] linePoint = new Vector3[2];
        //linepoint[0] = fireTransform.position;
        //linepoint[1] = hitPosition;
        //bulletLineRenderer.SetPositions(linepoint);
        
        //총구에서 화염과 슈팅소리가 난다.
        muzzleFlashEffect.Play();
        gunAudioPlayer.clip = shotClip;
        gunAudioPlayer.Play();

        // 라인 렌더러를 활성화하여 총알 궤적을 그린다
        bulletLineRenderer.enabled = true;

        // 0.03초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(0.03f);

        //탄피 배출
        shellEjectEffect.Play();

        // 라인 렌더러를 비활성화하여 총알 궤적을 지운다
        bulletLineRenderer.enabled = false;
    }

    // 재장전 시도
    public bool Reload() {
        return false;
    }

    // 실제 재장전 처리를 진행
    private IEnumerator ReloadRoutine() {
        // 현재 상태를 재장전 중 상태로 전환
        state = State.Reloading;
        
        // 재장전 소요 시간 만큼 처리를 쉬기
        yield return new WaitForSeconds(reloadTime);

        // 총의 현재 상태를 발사 준비된 상태로 변경
        state = State.Ready;
    }
}