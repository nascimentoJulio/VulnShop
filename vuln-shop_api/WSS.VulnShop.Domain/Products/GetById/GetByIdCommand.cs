using MediatR;
using WSS.VulnShop.Domain.Products.GetById;

namespace WSS.VulnShop.Domain.Products.NovaPasta
{
    public class GetByIdCommand : BaseRequest, IRequest<GetByIdCommandResult>
    {
        public int Id { get; set; }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}
