using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}