>
> 💡 사용 시 어려움이나 문제가 있으시면 이슈를 남겨주세요. 한 시간 안에 답변을 달도록 하겠습니다.
>

# Boundary Camera
Unity에서 카메라의 이동 범위를 제한할 때 사용할 수 있는 에셋입니다. 카메라의 화면이 `Boundary`라는 이름의 BoxCollider 내의 영역에만 보여주도록 합니다.

<img width="511" src="https://user-images.githubusercontent.com/104705295/256589742-9756e41d-9a2c-4163-8ec0-8a97bfd3b5bb.gif"/>

## 설치 방법
### Package Manger를 이용한 설치
1. Window > Package Manager 클릭
1. 왼쪽 상단의 '+' 버튼 클릭 후 `Add Package from git URL` 클릭
1. `https://github.com/Excellcube/BoundaryCamera.git` 입력 후 add 버튼 클릭

## 사용 방법
### 카메라 설정
* Boundary Camera 효과를 주고 싶은 카메라에 `BoundaryCamera`라는 이름의 컴포넌트를 추가합니다.

  <img width="511" src="https://user-images.githubusercontent.com/104705295/256683024-3ff1d2be-6ba8-4dfb-827e-eb0d60a974c1.jpg"/>

### 카메라 렌더링 영역 설정
* `BoundaryCamera > Prefabs > CameraBoundary.prefab`을 Scene에 추가한 뒤 원하는 크기에 맞춰 CameraBoundary 내의 BoxCollider 크기를 적당히 조절합니다.

  <img width="511" src="https://user-images.githubusercontent.com/104705295/256683036-6ddb613a-5c38-48da-993a-61264b7334dc.jpg"/>

  <img width="511" src="https://user-images.githubusercontent.com/104705295/256683037-0ce04628-ec98-462a-b7e3-347d90086916.jpg"/>

## License
* MIT

## Contact
* QUVE ([Blog](https://quve.tistory.com/))