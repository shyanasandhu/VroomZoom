using UnityEngine.Events;

public static class EventManager{

    public static event UnityAction TimerStart;
    public static event UnityAction TimerStop;

    public static void onTimerStart() => TimerStart?.Invoke();
    public static void onTimerStop() => TimerStop?.Invoke();

}
