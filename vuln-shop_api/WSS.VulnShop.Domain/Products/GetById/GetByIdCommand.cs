﻿using MediatR;
using WSS.VulnShop.Domain.Products.GetById;

namespace WSS.VulnShop.Domain.Products.GetById
{
    public class GetByIdCommand : BaseRequest<GetByIdCommandResult>
    {
        public int Id { get; set; }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}
