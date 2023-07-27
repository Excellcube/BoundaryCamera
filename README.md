# Boundary Camera
큰 숫자를 축약하여 화면에 표시할 때 사용하는 모듈입니다. `1,234,567,000`과 같이 큰 숫자를 한국 숫자 단위(`12억 3456만`)로 변환하거나 AA notation(`1.23B`)으로 축약 변환할 수 있습니다. 기본 자료형으로 `double`을 사용하고 있기 때문에 숫자의 정밀도는 double 타입과 같습니다. (15~17자리)

## 설치 방법
### Package Manger를 이용한 설치
1. Window > Package Manager 클릭
1. 왼쪽 상단의 '+' 버튼 클릭 후 `Add Package from git URL` 클릭
1. `https://github.com/Excellcube/BigNum.git` 입력 후 add 버튼 클릭

## 사용 방법
`BigNum`을 사용하는 코드에 다음과 같이 namespace를 추가합니다.

```csharp
using Excellcube

/* 코드 작성 */
```

### 초기화
```csharp
// 숫자 할당
BigNum num1 = 123123123;

// 문자열 할당
BigNum num2 = "123123123";
```

### 사칙 연산
```csharp
// 더하기 연산
BigNum num1 = 100000000000000;
BigNum num2 = 20000;
BigNum result =  num1 + num2;  // 100000000020000

// 빼기 연산
BigNum num1 = 100000000000000;
int num2 = 20000;  // 기존 자료형 호환
BigNum result = num1 - num2;  // 99999999980000

// 곱하기 연산
BigNum num1 = 1000000000000;
float num2 = 200;
BigNum result = num1 * num2;  // 200000000000000

// 나누기 연산
BigNum num1 = 2000000000000;
double num2 = 200;
BigNum result = num1 / num2;  // 10000000000
```

### 문자열 변환
```csharp
BigNum num = 12345678912345;
string numStr = num.ToString("N0");  // "12,345,678,912,345"
```

### 축약형 변환
```csharp
// 영어 축약형 (aa notation)
BigNum num = "123023456789";
string numStr = num.ToShortForm();      // "123B"

// 한글 축약형
BigNum num = "123023456789";
string numStr = num.ToShortForm("ko");  // "1230억 2345만"
```

### 영어 축약형 자릿수
* AA notation 사용 시 최대 세 자리의 숫자만 표기하고 있습니다. (ex. `4321` -> `4.32K`, `54321` -> `54.3K`)

## License
* MIT

## Contact
* QUVE ([Blog](https://quve.tistory.com/))