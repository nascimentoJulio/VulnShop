using MediatR;

namespace WSS.VulnShop.Domain
{
    public class BaseRequest<res> : IRequest<res>
    {

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
