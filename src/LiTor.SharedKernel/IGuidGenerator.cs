namespace LiTor.SharedKernel;
/// <summary>
/// Defines abstractions for GUID creation
/// </summary>
public interface IGuidGenerator
{
  Guid Generate();
}
