using System.Threading.Tasks;

namespace RequestBusPoc.Domain.RequestBusModel
{
    public interface IRequestBus
    {
        TResponse ProcessRequest<TRequest, TResponse>(TRequest request);
    }
}