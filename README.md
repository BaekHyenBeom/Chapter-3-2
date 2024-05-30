# Chapter-3-2
스파르타 코딩 클럽 유니티 숙련 주차 개인과제

## 목차
  - [개요](#개요)
  - [폴더 구조](#폴더_구조)
  - [구현한 기능](#구현한_기능)

## 개요
- 개발 기간: 2024/05/27~2024/05/30
- 개발 엔진 및 언어: Unity, C#

## 폴더_구조
  - 추후에 반영 바람

## 구현한_기능
- 필수 요구 사항 1~6, 선택 요구 사항 1, 2, 3, 7, 8, 9

### 기본 조작키 (필수 1)
- **이동** - W, A, S, D
- **점프** - SpaceBar (스테미너 요구)
- **대쉬** - 이동 중에 LeftShift (스테미너 요구)
  - ![Movie_007](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/08df1243-fd75-4649-8d27-39123331eb58)

### 추가적인 조작키 (필수 5, 6, 선택 2, +@)
- **인칭 변환** - 5번 키
  - ![Movie_006](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/293e405e-4414-4c5b-b322-299462433b6e)
- **아이템 수집 및 상호작용**- E키
- **현재 물악 슬록 사용** - R키
- **물약 슬롯 변경** - 마우스 휠(위, 아래)
  - ![Movie_005](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/02e15cc7-7b6d-421b-8f7a-7a1457c43b2d)

### UI 요소 (필수 3, 선택 1, 8)
![Image Sequence_001_0000](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/d92a3d8d-1c07-4910-8092-923d13e4e3e6)
- 인벤토리 칸과 지속 효과 표시칸
![Image Sequence_002_0000](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/ed8505cd-6291-435a-a78d-131d5d62d2d6)

### 각종 상호작용 오브젝트
![스크린샷 2024-05-30 193433](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/eb1e75a6-5f22-432c-9e18-64f086123a16)
![스크린샷 2024-05-30 193831](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/1e02ed8e-eaaa-4ae6-8bb6-afbd3efd6f2d)
#### 점프대 (필수 4)
![Movie_010](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/4a77e5ae-b15b-4734-be55-8f9541270d3a)
#### 움직이는 플랫폼 (선택 3)
![Movie_011](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/9ef79795-362c-418c-b384-3bb67c82cf28)
- Recorder 문제로 매우 느리게 출력됨
#### 레이저 트랩 (선택 7)
![Movie_012](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/25e22a62-5690-4f71-977b-f305c991022c)
#### 플랫폼 발사기 (선택 9)
![Movie_013](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/7a496845-b35f-4f0e-89ae-bb6eb2362df0)
#### 물약
![스크린샷 2024-05-30 194121](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/4c7c832d-2b8b-4a0e-9cee-0badc2b516ec)
- 현재 속도 물약만 기능이 구현됨 (이동 속도와 대쉬 증가)
- 나머지는 Debug.Log로만 소모되었다는 사실만 알림
#### 물약 생성기
![Movie_014](https://github.com/BaekHyenBeom/Chapter-3-2/assets/167046656/077c01e7-ca4d-410d-b8ea-bb7bcde366ff)

