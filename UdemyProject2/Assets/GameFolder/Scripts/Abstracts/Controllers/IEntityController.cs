using UnityEngine;

namespace UdemyProject2.Abstracts.Controllers
{
    public interface IEntityController 
    {
        Transform transform { get; }
        
        float MoveSpeed { get; }
        float MoveBoundary { get; }
    }
}