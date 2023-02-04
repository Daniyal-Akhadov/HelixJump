using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    public interface IGameFactory : IService
    {
        GameObject CreateTower();
        GameObject CreateBall(Vector3 initialBallPosition);
    }
}