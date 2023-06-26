# Unity Prefab(프리팹) 오버라이드 - 프리팹의 한 인스턴스만 변경하기

한 프리팹 인스턴스의 프로퍼티를 변경하게 되면 이 프로퍼티를 **오버라이드**라고 부르는데, 기본 프리팹 설정을 오버라이드하기 때문이다. 인스펙터 창에서 오버라이드를 쉽게 추적할 수 있다.

오버라이드는 프리팹 배리에이션을 한 번에 하나씩 만들거나, 여러 게임 오브젝트에 적용하기 전에 변경 사항을 테스트하려는 경우에 유용하다.

오버라이드를 사용하여 프리팹 인스턴스의 배리에이션을 만드는 방법은 다음과 같다.

<br>

1. 씬 뷰에서 BouncyBall 프리팹 인스턴스 중 하나를 선택한다.

   이 오브젝트가 선택되어 있는 동안 인스펙터 창의 상단을 살펴보면, 프리팹 작업을 수행하는 데 사용할 수 있는 컨트롤이 포함된 **Prefab** 추가 섹션이 있다. 여기서 **Open** 버튼을 사용해 프리팹 모드로 들어가 프리팹을 편집할 수 있다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/0490b81a-3f42-4a29-ba85-36fb774bbfc2)

<br>

2. 인스펙터의 Transform 컴포넌트를 사용하여 이 BouncyBall의 x, y 및 z축 **Scale**을 변경한다.

   인스펙터의 왼쪽 여백에 있는 파란색 선은 **Scale** 프로퍼티가 기본 프리팹과 다르다는 것을 나타낸다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/64a443a8-6a50-488e-9f45-4831afc45069)

<br>

3. 인스펙터에서 Sphere Collider 컴포넌트를 사용하여 원 아이콘을 선택하고 물리 머티리얼을 **None**으로 설정하면 이 물체는 지면에 닿아도 튀어 오르지 않게 된다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/e7562114-a13f-4019-815a-ee2e86b4fd29)

<br>

4. 이 게임 오브젝트에 다른 머티리얼을 적용하여 다른 게임 오브젝트와 시각적으로 다르게 보이게 만든다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/b331f29d-84f2-4fed-8103-ccf183263f02)

<br>

5. 애플리케이션을 실행해보면, 편집한 구체만 머티리얼이 다르며 튀어 오르지 않는 것을 확인할 수 있다. 이러한 변경 사항을 이 프리팹의 모든 인스턴스에 적용하려면 기본 프리팹에 적용해야 한다.

   이제 스케일, 물리 머티리얼, 일반 머티리얼에 해당하는 세 가지 프로퍼티를 오버라이드했다. 다음 단계에서는 각 프로퍼티를 사용하여 다른 작업을 수행한다.

<br>

6. 인스펙터 상단의 **Prefab** 컨트롤로 **Overrides**를 선택하여 프리팹과 다른 컴포넌트 목록을 확인한다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/a122d38a-44cc-43d8-a275-df87915f97a2)

<br>

7. Bouncy** 물리 머티리얼을 제거하려던 생각이 바뀌었다면, **Overrides** 리스트에서 Sphere Collider 컴포넌트를 선택하여 두 개의 컴포넌트 버전, 즉 **Prefab Source**와 **Override**를 확인한다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/a6c83914-9e03-4a9f-9fb4-60e9a445ad12)

<br>

8. Sphere Collider를 원래 설정으로 되돌리려면 컴포넌트의 **Override** 버전 상단에 있는 **Revert**를 선택한다. 그러면 공이 다시 Bouncy 물리 머티리얼을 사용하도록 변경된다.

<br>

9. 모든 탱탱볼의 크기를 이 공의 크기로 만들려는 상황을 가정해 본다.

   Transform 컴포넌트의 오버라이드를 기본 프리팹에 적용하려면 **Overrides** 드롭다운으로 되돌아가서 **Transform** > **Apply** > **Apply to Prefab “BouncyBall”**을 선택한다. 그러면 모든 공의 크기가 변경된다.

   ![image](https://github.com/SShinMJ/TIL/assets/82142527/c970e0c5-2c51-42fa-932b-a63b9a94348a)
