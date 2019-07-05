using UnityEngine.Networking;
using System.Runtime.CompilerServices;

namespace TEA.Example.HTTP
{
  static class UnityWebRequestAsyncOperationExtension
  {
    public static UnityWebRequestAsyncOperationAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOperation)
    {
      return new UnityWebRequestAsyncOperationAwaiter(asyncOperation);
    }
  }

  class UnityWebRequestAsyncOperationAwaiter : INotifyCompletion
  {
    UnityWebRequestAsyncOperation asyncOperation;

    public bool IsCompleted
    {
      get => asyncOperation.isDone;
    }

    public UnityWebRequestAsyncOperationAwaiter(UnityWebRequestAsyncOperation asyncOperation)
    {
      this.asyncOperation = asyncOperation;
    }

    public void GetResult()
    {

    }

    public void OnCompleted(System.Action continuation)
    {
      asyncOperation.completed += _ => continuation();
    }
  }
}