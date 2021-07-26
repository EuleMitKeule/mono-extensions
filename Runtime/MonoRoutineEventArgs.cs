namespace UnityExtensions.Runtime
{
    public class MonoRoutineEventArgs
    {
        public bool IsForced { get; }

        public MonoRoutineEventArgs(bool isForced) => IsForced = isForced;
    }
}